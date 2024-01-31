using System.Net;
using Dalog.DataPlatform.Client.ImageUploader.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dalog.DataPlatform.Client.ImageUploader;
internal static class Program
{
    /// <summary>
    /// The Host builder
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns>The </returns>
    static IHostBuilder CreateHostBuilder(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainForm2>();
            });

        return host;
    }

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        using var host = CreateHostBuilder([]).Build();
        host.RunAsync();

        var view = host.Services.GetRequiredService<MainForm2>();
        Application.Run(view);
    }
}