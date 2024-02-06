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
        private readonly IPublicClientApplication _clientApp;

        private readonly ILogger<AuthRepository> _logger;

        private readonly AuthSettings _settings;

        public AuthRepository(ILogger<AuthRepository> logger, IOptions<AuthSettings> settings)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(settings?.Value, nameof(settings));
            this._logger = logger;
            this._settings = settings.Value;
            this._clientApp = this.GetClientApp() ?? throw new ArgumentNullException("Error initializing authentication.");
        }

        public string AccessToken { get; private set; } = string.Empty;

        public bool Login(string[] scopes)
        {
            AuthenticationResult? response = Task.Run(() => this.LoginAsync(scopes)).Result;
            if (response == null)
            {
                return false;
            }

            this.AccessToken = response.AccessToken;
            return !string.IsNullOrEmpty(this.AccessToken);
        }

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
