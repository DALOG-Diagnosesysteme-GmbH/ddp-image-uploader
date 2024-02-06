// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Net;
using System.Net.Http.Headers;
using Dalog.DataPlatform.Client.ImageUploader.Controllers;
using Dalog.DataPlatform.Client.ImageUploader.Forms;
using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Dalog.DataPlatform.Client.ImageUploader.Schema;
using Dalog.DataPlatform.Client.ImageUploader.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Templates;

namespace Dalog.DataPlatform.Client.ImageUploader;

/// <summary>
/// The program class.
/// </summary>
internal static class Program
{
    private static readonly string s_env = Environments.Development;

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureDefaults(args)
            .UseEnvironment(s_env)
            .ConfigureServices((context, services) =>
            {
                services.Configure<AuthSettings>(context.Configuration.GetSection(nameof(AuthSettings)));
                services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
                services.Configure<ImagesUploadEndpoints>(context.Configuration.GetSection(nameof(ImagesUploadEndpoints)));
                services.AddHttpClient();
                services.AddTransient<HttpRepository>();
                services.AddSingleton<AuthRepository>();
                services.AddSingleton<IController<MainForm>, MainController>();
                services.AddHostedService<Worker>();
            })
            .UseSerilog();

        return host;
    }

    private static ILogger GetLoggerConfiguration()
    {
        string userFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var outputTemplate = new ExpressionTemplate("[{@t:yyyy.MM.dd HH:mm:ss} {@l:u3} {#if SourceContext is not null}({Substring(SourceContext, LastIndexOf(SourceContext, '.') + 1)}){#end}] {@m}\n{@x}");
        LoggerConfiguration result = new LoggerConfiguration().ReadFrom.Configuration(new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build());

        if (s_env == Environments.Development)
        {
            result.WriteTo.Debug(outputTemplate);
        }
        else
        {
            result.WriteTo.File(outputTemplate,
                Path.Combine(userFolderPath, "DALOG Diagnosesysteme GmbH", "Images Uploader", "log.txt"),
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 10
            );
        }

        return result.CreateLogger();
    }

    /// <summary>
    /// The main method.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Log.Logger = GetLoggerConfiguration();
        ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();

        using IHost host = CreateHostBuilder([]).Build();
        host.RunAsync();

        IController<MainForm> mainController = host.Services.GetRequiredService<IController<MainForm>>();
        AuthRepository authRepository = host.Services.GetRequiredService<AuthRepository>();
        bool loginSuccess = authRepository.Login([]);
        if (!loginSuccess)
        {
            MessageDialog.Show(mainController.View, MessageBoxIcon.Error, "Authentication failure. This application will be closed.");
        }
        else
        {
            Application.Run(mainController.View);
        }
    }
}
