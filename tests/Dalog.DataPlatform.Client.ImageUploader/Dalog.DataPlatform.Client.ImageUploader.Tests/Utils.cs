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
        internal static IHostBuilder CreateHostBuilder(string[] args)
        {
            IHostBuilder host = Host.CreateDefaultBuilder(args)
                .ConfigureDefaults(args)
                .ConfigureServices((context, services) =>
                {
                    services.Configure<AuthSettings>(context.Configuration.GetSection(nameof(AuthSettings)));
                    services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
                    services.Configure<ImagesUploadEndpoints>(context.Configuration.GetSection(nameof(ImagesUploadEndpoints)));
                    services.AddSingleton<AuthRepository>();
                    services.AddTransient<HttpRepository>();
                });

            return host;
        }
    }
}
