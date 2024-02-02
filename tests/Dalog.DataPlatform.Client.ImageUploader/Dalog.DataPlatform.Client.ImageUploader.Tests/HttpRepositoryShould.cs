// -----------------------------------------------------------------------
// <copyright file="HttpRepositoryShould.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Net;
using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Dalog.DataPlatform.Client.ImageUploader.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dalog.DataPlatform.Client.ImageUploader.Tests
{
    /// <summary>
    /// The HTTP repository should test class.
    /// </summary>
    public class HttpRepositoryShould
    {
        /// <summary>
        /// The test API key
        /// </summary>
        private const string ApiKey = "86388ed5fa7d426baa5176befd610b8a";

        /// <summary>
        /// The host
        /// </summary>
        private readonly IHost _host;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRepositoryShould"/> class
        /// </summary>
        public HttpRepositoryShould()
        {
            this._host = Utils.CreateHostBuilder([]).Build();
        }

        [Trait("Category", "Unit Tests")]
        [Fact]
        public async Task TestConnection_ReturnSuccess()
        {
            var sut = this._host.Services.GetRequiredService<HttpRepository>();
            Assert.NotNull(sut);
            var settings = new UploadSettings()
            {
                ApiKey = ApiKey,
                Timeout = 10
            };

            var response = await sut.TestConnectionAsync(settings);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Trait("Category", "Unit Tests")]
        [Fact]
        public async Task UploadImages_NotReturnBadRequest()
        {
            var sut = this._host.Services.GetRequiredService<HttpRepository>();
            Assert.NotNull(sut);
            var settings = new UploadSettings()
            {
                ApiKey = ApiKey,
                Folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"),
                ImageType = ImageType.BusyBee,
                Timeout = 10
            };

            var dataFolder = new DirectoryInfo(settings.Folder);
            var files = dataFolder.EnumerateFiles("*.sav", SearchOption.TopDirectoryOnly);
            Assert.NotEmpty(files);
            foreach (var file in files)
            {
                var response = await sut.UploadImageAsync(settings, file);
                Assert.NotEqual(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }
    }
}