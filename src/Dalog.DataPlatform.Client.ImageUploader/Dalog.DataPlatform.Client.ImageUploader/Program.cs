using Dalog.DataPlatform.Client.ImageUploader.Controllers;
using Dalog.DataPlatform.Client.ImageUploader.Forms;
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
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IController<MainForm2>, MainController>();
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

        var mainController = host.Services.GetRequiredService<IController<MainForm2>>();
        Application.Run(mainController.View);
    }
}