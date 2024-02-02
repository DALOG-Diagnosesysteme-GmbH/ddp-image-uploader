// -----------------------------------------------------------------------
// <copyright file="HttpRepository.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Net;
using Dalog.DataPlatform.Client.ImageUploader.Schema;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dalog.DataPlatform.Client.ImageUploader.Repositories
{
    /// <summary>
    /// The HTTP repository class.
    /// </summary>
    public sealed class HttpRepository
    {
        /// <summary>
        /// The application settings.
        /// </summary>
        private readonly AppSettings _appSettings;

        /// <summary>
        /// The images upload endpoints.
        /// </summary>
        private readonly ImagesUploadEndpoints _endpoints;

        /// <summary>
        /// The HTTP client factory.
        /// </summary>
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<HttpRepository> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRepository"/> class.
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="appSettings">The application settings</param>
        /// <param name="httpClientFactory">The HTTP client factory</param>
        public HttpRepository(ILogger<HttpRepository> logger, IOptions<AppSettings> appSettings, IOptions<ImagesUploadEndpoints> endpoints, IHttpClientFactory httpClientFactory)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(appSettings, nameof(appSettings));
            ArgumentNullException.ThrowIfNull(endpoints, nameof(endpoints));
            ArgumentNullException.ThrowIfNull(httpClientFactory, nameof(httpClientFactory));
            this._logger = logger;
            this._appSettings = appSettings.Value;
            this._endpoints = endpoints.Value;
            this._httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Tests the connection to the DDP async.
        /// </summary>
        /// <param name="uploadSettings">The HTTP settings</param>
        /// <param name="token">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task<HttpResponseMessage> TestConnectionAsync(UploadSettings uploadSettings, CancellationToken token = default)
        {
            var result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Unused
            };

            try
            {
                this._logger.LogInformation("Starting connection test to DDP...");
                this._logger.LogInformation("Validating settings...");
                if (!uploadSettings.NetworkSettingsAreValid(out var errors))
                {
                    this._logger.LogError("Settings not valid: {errors}", errors);
                    result.Content = new StringContent(errors);
                    return result;
                }

                using var client = this.GetHttpClient(uploadSettings);
                var response = await client.GetAsync(this._appSettings.PingUrl, token).ConfigureAwait(true);
                response.EnsureSuccessStatusCode();
                result = response;
                this._logger.LogInformation("Test connection successful.");
            }
            catch (TaskCanceledException)
            {
                result.Content = new StringContent("Task cancelled.");
                this._logger.LogInformation("Task cancelled.");
            }
            catch (HttpRequestException ex)
            {
                result.StatusCode = ex.StatusCode ?? HttpStatusCode.BadRequest;
                result.Content = new StringContent(ex.Message);
                this._logger.LogError(ex, "Connection error ({StatusCode}): {Message}.", ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception '{Source}' thrown: {Message}.", ex.Source, ex.Message);
            }

            return result;
        }

        public async Task<HttpResponseMessage> UploadImageAsync(UploadSettings uploadSettings, FileInfo fileInfo, CancellationToken token = default)
        {
            var result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Unused
            };

            try
            {
                // Adds the form data
                using var formData = new MultipartFormDataContent();
                var fileBytes = await File.ReadAllBytesAsync(fileInfo.FullName, token);
                var fileContent = new ByteArrayContent(fileBytes);
                formData.Add(fileContent, "file", fileName: Path.GetFileNameWithoutExtension(fileInfo.FullName));
                if (!string.IsNullOrWhiteSpace(uploadSettings.MachineId))
                {
                    formData.Add(new StringContent(uploadSettings.MachineId), name: "machineId");
                }

                if (!string.IsNullOrWhiteSpace(uploadSettings.DalogId))
                {
                    formData.Add(new StringContent(uploadSettings.DalogId), name: "dalogId");
                }

                // Performs the upload.
                using var httpClient = this.GetHttpClient(uploadSettings);
                result = await httpClient.PostAsync(this.GetEndpoint(uploadSettings.ImageType), formData, token);
                result.EnsureSuccessStatusCode();
            }
            catch (TaskCanceledException)
            {
                result.Content = new StringContent("Task cancelled.");
                this._logger.LogInformation("Task cancelled.");
            }
            catch (HttpRequestException ex)
            {
                result.StatusCode = ex.StatusCode ?? HttpStatusCode.BadRequest;
                result.Content = new StringContent(ex.Message);
                this._logger.LogError(ex, "Connection error ({StatusCode}): {Message}.", ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception '{Source}' thrown: {Message}.", ex.Source, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Gets the image upload endpoint.
        /// </summary>
        /// <param name="type">The image type to upload</param>
        /// <returns>The endpoint relative Url string.</returns>
        /// <exception cref="NotImplementedException">When the image type is unknown</exception>
        private string GetEndpoint(ImageType type) => type switch
        {
            ImageType.Default => this._endpoints.Default,
            ImageType.BusyBee => this._endpoints.BusyBee,
            ImageType.FLS => this._endpoints.FLS,
            ImageType.GZip => this._endpoints.GZip,
            ImageType.Wireless => this._endpoints.Wireless,
            ImageType.Zip => this._endpoints.Zip,
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        /// Gets an HTTP client
        /// </summary>
        /// <param name="settings">The HTTP settings</param>
        /// <returns>The HTTP client.</returns>
        private HttpClient GetHttpClient(UploadSettings settings)
        {
            this._logger.LogInformation("Instantiating HTTP client from factory...");
            var result = this._httpClientFactory.CreateClient("DdpClient");
            if (!string.IsNullOrEmpty(settings.ApiKey))
            {
                result.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", settings.ApiKey);
            }

            return result;
        }
    }
}