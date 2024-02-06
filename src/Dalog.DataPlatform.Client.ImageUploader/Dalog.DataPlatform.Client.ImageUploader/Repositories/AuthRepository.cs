// -----------------------------------------------------------------------
// <copyright file="AuthRepository.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Dalog.DataPlatform.Client.ImageUploader.Authentication;
using Dalog.DataPlatform.Client.ImageUploader.Schema;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace Dalog.DataPlatform.Client.ImageUploader.Repositories
{
    /// <summary>
    /// The authentication repository class.
    /// </summary>
    public sealed class AuthRepository
    {
        /// <summary>
        /// The public client application
        /// </summary>
        private readonly IPublicClientApplication _clientApp;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<AuthRepository> _logger;

        /// <summary>
        /// The authentication settings.
        /// </summary>
        private readonly AuthSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRepository"/> class.
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="settings">The authentication settings</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AuthRepository(ILogger<AuthRepository> logger, IOptions<AuthSettings> settings)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(settings?.Value, nameof(settings));
            this._logger = logger;
            this._settings = settings.Value;
            this._clientApp = this.GetClientApp() ?? throw new ArgumentNullException("Error initializing authentication.");
        }

        /// <summary>
        /// Gets and sets the access token
        /// </summary>
        public string AccessToken { get; private set; } = string.Empty;

        /// <summary>
        /// Logs into the DDP
        /// </summary>
        /// <param name="scopes">The scopes string list.</param>
        /// <returns>A value determining whether the user was successfully logged in or not.</returns>
        public bool Login(string[] scopes)
        {
            var response = Task.Run(() => this.LoginAsync(scopes)).Result;
            if (response == null)
            {
                return false;
            }

            this.AccessToken = response.AccessToken;
            return !string.IsNullOrEmpty(this.AccessToken);
        }

        /// <summary>
        /// Gets the public client application object.
        /// </summary>
        /// <returns>The public client application.</returns>
        private IPublicClientApplication? GetClientApp()
        {
            IPublicClientApplication? result = null;

            try
            {
                this._logger.LogInformation("Initializing bearer token authentication...");
                result = PublicClientApplicationBuilder.Create(this._settings.ClientId)
                    .WithB2CAuthority($"https://{this._settings.B2CTenantName}.b2clogin.com/tfp/{this._settings.B2CTenantName}.onmicrosoft.com/{this._settings.B2CPolicyName}")
                    .WithRedirectUri(this._settings.RedirectUrl)
                    .Build();
                TokenCacheHelper.EnableSerialization(result.UserTokenCache);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception '{Source}' thrown: {Message}", ex.Source, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Logs into the DDP asynchronously
        /// </summary>
        /// <param name="scopes">the scopes string list</param>
        /// <param name="token">The cancellation token</param>
        /// <returns>The authentication result task.</returns>
        private async Task<AuthenticationResult?> LoginAsync(string[] scopes, CancellationToken token = default)
        {
            AuthenticationResult? authResult = null;
            var accounts = await this._clientApp.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            try
            {
                authResult = await this._clientApp.AcquireTokenSilent(scopes, firstAccount)
                    .ExecuteAsync(token);
            }
            catch (MsalUiRequiredException ex)
            {
                this._logger.LogWarning(ex, "MSAL UI Exception '{Source}' thrown: {Message}", ex.Source, ex.Message);

                try
                {
                    authResult = await this._clientApp.AcquireTokenInteractive(scopes)
                        .WithAccount(accounts.FirstOrDefault())
                        .WithPrompt(Prompt.SelectAccount)
                        .ExecuteAsync(token);
                }
                catch (MsalException msalex)
                {
                    this._logger.LogError(msalex, "Error acquiring token: {Message}", msalex.Message);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception '{Source}' thrown: {Message}", ex.Source, ex.Message);
            }

            return authResult;
        }
    }
}