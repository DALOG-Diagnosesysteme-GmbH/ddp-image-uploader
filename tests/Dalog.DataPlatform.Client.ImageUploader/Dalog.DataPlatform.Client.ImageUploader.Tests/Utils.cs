// -----------------------------------------------------------------------
// <copyright file="Utils.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Dalog.DataPlatform.Client.ImageUploader.Schema;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dalog.DataPlatform.Client.ImageUploader.Tests
{
    /// <summary>
    /// The test utils class.
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Creates a host builder
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>The host builder.</returns>
        internal static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureDefaults(args)
                .ConfigureServices((context, services) =>
                {
                    services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
                    services.Configure<ImagesUploadEndpoints>(context.Configuration.GetSection(nameof(ImagesUploadEndpoints)));
                    services.AddHttpClient("DdpClient", options =>
                    {
                        var appsettings = context.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
                        options.BaseAddress = new Uri(appsettings!.BaseUrl);
                    })
                    .SetHandlerLifetime(TimeSpan.FromSeconds(1));
                    services.AddTransient<HttpRepository>();
                });

            return host;
        }
    }
}