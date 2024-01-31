using Dalog.DataPlatform.Client.ImageUploader.Controllers;
using Dalog.DataPlatform.Client.ImageUploader.Forms;
using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Dalog.DataPlatform.Client.ImageUploader.Schema;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dalog.DataPlatform.Client.ImageUploader;

internal static class Program
{
    /// <summary>
    /// Creates a host builder
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns>The host builder.</returns>
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((builder) =>
            {
                builder.AddUserSecrets<AppSettings>();
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
                services.AddSingleton<HttpRepository>();
                services.AddSingleton<IController<MainForm>, MainController>();
            });

        return host;
    }

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        using var host = CreateHostBuilder([]).Build();
        host.RunAsync();

        var mainController = host.Services.GetRequiredService<IController<MainForm>>();
        Application.Run(mainController.View);
    }
}