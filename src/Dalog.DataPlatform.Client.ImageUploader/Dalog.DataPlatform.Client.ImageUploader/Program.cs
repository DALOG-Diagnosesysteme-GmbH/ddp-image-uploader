// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Net;
using Dalog.DataPlatform.Client.ImageUploader.Controllers;
using Dalog.DataPlatform.Client.ImageUploader.Forms;
using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Dalog.DataPlatform.Client.ImageUploader.Schema;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Dalog.DataPlatform.Client.ImageUploader;

/// <summary>
/// The program class.
/// </summary>
internal static class Program
{
    /// <summary>
    /// The environment name
    /// </summary>
    private static readonly string env = Environments.Development;

    /// <summary>
    /// Creates a host builder
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns>The host builder.</returns>
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureDefaults(args)
            .UseEnvironment(env)
            .ConfigureServices((context, services) =>
            {
                services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
                services.Configure<ImagesUploadEndpoints>(context.Configuration.GetSection(nameof(ImagesUploadEndpoints)));
                services.AddHttpClient("DdpClient", options =>
                {
                    var appsettings = context.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
                    options.BaseAddress = new Uri(appsettings!.BaseUrl);
                    options.Timeout = TimeSpan.FromSeconds(UserSettings.Default.Timeout);
                })
                .SetHandlerLifetime(TimeSpan.FromSeconds(1))
                .ConfigurePrimaryHttpMessageHandler(provider =>
                {
                    var uploadSettings = UserSettings.Default;
                    var handler = new HttpClientHandler();
                    if (uploadSettings.DisableSslChecks)
                    {
                        handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                        handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => { return true; };
                    }
                    if (uploadSettings.UseProxy)
                    {
                        handler.UseProxy = uploadSettings.UseProxy;
                        try
                        {
                            handler.Proxy = new WebProxy
                            {
                                Address = new Uri(uploadSettings.ProxyAddress ?? string.Empty),
                                UseDefaultCredentials = uploadSettings.ProxyUseDefaultCredentials,
                                Credentials = new NetworkCredential(uploadSettings.ProxyCredentialsUsername, uploadSettings.ProxyCredentialsPassword)
                            };
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Exception '{Source}' thrown: {Message}.", ex.Source, ex.Message);
                        }
                    }

                    return handler;
                });

                services.AddTransient<HttpRepository>();
                services.AddSingleton<IController<MainForm>, MainController>();
            })
            .UseSerilog();

        return host;
    }

    /// <summary>
    /// The main method.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(new ConfigurationBuilder()
            .AddJsonFile(env == Environments.Development ? "appsettings.Development.json" : "appsettings.json", false, true)
            .Build())
            .CreateLogger();

        ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();

        using var host = CreateHostBuilder([]).Build();
        host.RunAsync();
        var mainController = host.Services.GetRequiredService<IController<MainForm>>();
        Application.Run(mainController.View);
    }
}