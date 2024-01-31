// -----------------------------------------------------------------------
// <copyright file="NetworkSettingsController.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Dalog.DataPlatform.Client.ImageUploader.ExtensionMethods;
using Dalog.DataPlatform.Client.ImageUploader.Forms;
using Dalog.DataPlatform.Client.ImageUploader.Schema;

namespace Dalog.DataPlatform.Client.ImageUploader.Controllers
{
    /// <summary>
    /// The network settings controller class.
    /// </summary>
    internal sealed class NetworkSettingsController : IController<NetworkForm>
    {
        /// <summary>
        /// The network form view.
        /// </summary>
        private readonly NetworkForm _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSettingsController"/> class.
        /// </summary>
        /// <param name="settings">The settings</param>
        public NetworkSettingsController(HttpSettings settings)
        {
            this._view = new NetworkForm();
            this.SubscribeEvents();

            // Data bindings
            this._view.DisableSslChecks.AddDataBinding(settings, nameof(settings.DisableSslChecks));
            this._view.Timeout.AddDataBinding(settings, nameof(settings.Timeout));
            this._view.UseProxy.AddDataBinding(settings, nameof(settings.UseProxy));
            this._view.ProxyAddress.AddDataBinding(settings, nameof(settings.ProxyAddress));
            this._view.ProxyUserName.AddDataBinding(settings, nameof(settings.ProxyCredentialsUsername));
            this._view.ProxyUserPassword.AddDataBinding(settings, nameof(settings.ProxyCredentialsPassword));
        }

        /// <summary>
        /// Gets the form view.
        /// </summary>
        public NetworkForm View => this._view;

        /// <summary>
        /// Disposes all resources
        /// </summary>
        public void Dispose()
        {
            this.UnsubscribeEvents();
            this._view?.Dispose();
        }

        /// <summary>
        /// Subscribes to all necessary view's events.
        /// </summary>
        public void SubscribeEvents()
        {
            // Nothing
        }

        /// <summary>
        /// Unsubscribes from all view's events.
        /// </summary>
        public void UnsubscribeEvents()
        {
            // Nothing
        }
    }
}