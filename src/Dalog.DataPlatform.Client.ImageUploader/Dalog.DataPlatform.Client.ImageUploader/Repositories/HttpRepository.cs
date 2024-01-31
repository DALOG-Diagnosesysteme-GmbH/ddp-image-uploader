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
        /// The logger
        /// </summary>
        private readonly ILogger<HttpRepository> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRepository"/> class.
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="appSettings">The application settings</param>
        public HttpRepository(ILogger<HttpRepository> logger, IOptions<AppSettings> appSettings)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(appSettings, nameof(appSettings));
            this._logger = logger;
            this._appSettings = appSettings.Value;
        }

        /// <summary>
        /// Tests the connection to the DDP async.
        /// </summary>
        /// <param name="httpSettings">The HTTP settings</param>
        /// <param name="token">The cancellation token</param>
        /// <returns>The task</returns>
        public async Task<HttpResponseMessage> TestConnectionAsync(HttpSettings httpSettings, CancellationToken token = default)
        {
            var result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Unused
            };

            try
            {
                this._logger.LogInformation("Testing connection to the DDP...");
                using var client = this.GetHttpClient(httpSettings);
                var response = await client.GetAsync(this._appSettings.PingUrl, token).ConfigureAwait(true);
                response.EnsureSuccessStatusCode();
                result = response;
            }
            catch (TaskCanceledException)
            {
                result.Content = new StringContent("Task cancelled");
                this._logger.LogInformation("Task cancelled");
            }
            catch (HttpRequestException ex)
            {
                result.StatusCode = ex.StatusCode ?? HttpStatusCode.Unused;
                result.Content = new StringContent(ex.Message);
                this._logger.LogError(ex, "Connection error ({StatusCode}): {Message}.", ex.StatusCode, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Gets an HTTP client
        /// </summary>
        /// <param name="settings">The HTTP settings</param>
        /// <returns>The HTTP client.</returns>
        private HttpClient GetHttpClient(HttpSettings settings)
        {
            var handler = new HttpClientHandler();
            if (settings.DisableSslChecks)
            {
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => { return true; };
            }
            if (settings.UseProxy)
            {
                handler.UseProxy = settings.UseProxy;
                handler.Proxy = new WebProxy
                {
                    Address = new Uri(settings.ProxyAddress ?? string.Empty),
                    UseDefaultCredentials = settings.ProxyUseDefaultCredentials,
                    Credentials = new NetworkCredential(settings.ProxyCredentialsUsername, settings.ProxyCredentialsPassword)
                };
            }

            var result = new HttpClient(handler)
            {
                BaseAddress = new Uri(this._appSettings.BaseUrl),
                Timeout = TimeSpan.FromSeconds(settings.Timeout)
            };

            result.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", settings.ApiKey);

            return result;
        }
    }
}