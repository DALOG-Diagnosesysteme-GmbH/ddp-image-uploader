// -----------------------------------------------------------------------
// <copyright file="HttpRepository.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Net;
using System.Net.Http.Headers;
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
        private readonly AppSettings _appSettings;

        private readonly AuthRepository _authRepository;

        private readonly ImagesUploadEndpoints _endpoints;

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly ILogger<HttpRepository> _logger;

        public HttpRepository(ILogger<HttpRepository> logger, IOptions<AppSettings> appSettings, IOptions<ImagesUploadEndpoints> endpoints, IHttpClientFactory httpClientFactory, AuthRepository authRepository)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(appSettings, nameof(appSettings));
            ArgumentNullException.ThrowIfNull(endpoints, nameof(endpoints));
            ArgumentNullException.ThrowIfNull(httpClientFactory, nameof(httpClientFactory));
            ArgumentNullException.ThrowIfNull(authRepository, nameof(authRepository));
            this._logger = logger;
            this._appSettings = appSettings.Value;
            this._endpoints = endpoints.Value;
            this._httpClientFactory = httpClientFactory;
            this._authRepository = authRepository;
        }

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
            this._logger.LogInformation("Uploading file '{FullName}'...", fileInfo.FullName);
            var result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            if (!fileInfo.Exists)
            {
                this._logger.LogError("The file '{FullName}' does not exist or its access is restricted.", fileInfo.FullName);
                return result;
            }

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
                this._logger.LogInformation("Image successfully uploaded.");
            }
            catch (TaskCanceledException)
            {
                result.Content = new StringContent("Task cancelled.");
                this._logger.LogInformation("Task cancelled.");
            }
            catch (HttpRequestException ex)
            {
                result.Content = new StringContent(ex.Message);
                this._logger.LogError(ex, "Connection error ({StatusCode}): {Message}.", ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                result.Content = new StringContent(ex.Message);
                this._logger.LogError(ex, "Exception '{Source}' thrown: {Message}.", ex.Source, ex.Message);
            }

            return result;
        }

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

        private HttpClient GetHttpClient(UploadSettings settings)
        {
            this._logger.LogInformation("Instantiating HTTP client from factory...");
            var result = this._httpClientFactory.CreateClient("DdpClient");
            if (!string.IsNullOrEmpty(this._authRepository.AccessToken))
            {
                result.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this._authRepository.AccessToken);
            }
            else if (!string.IsNullOrEmpty(settings.ApiKey))
            {
                result.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", settings.ApiKey);
            }

            return result;
        }
    }
}
