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
        /// The HTTP settings.
        /// </summary>
        private readonly UploadSettings _uploadSettings;

        /// <summary>
        /// The network form view.
        /// </summary>
        private readonly NetworkForm _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkSettingsController"/> class.
        /// </summary>
        /// <param name="settings">The settings</param>
        public NetworkSettingsController(UploadSettings settings)
        {
            this._view = new NetworkForm();
            this.SubscribeEvents();

            // Data bindings
            this._view.DisableSslChecks.AddDataBinding(settings, nameof(settings.DisableSslChecks));
            this._view.Timeout.AddDataBinding(settings, nameof(settings.Timeout));
            this._view.UseProxy.AddDataBinding(settings, nameof(settings.UseProxy));
            this._view.ProxyAddress.AddDataBinding(settings, nameof(settings.ProxyAddress));
            this._view.ProxyUseDefaultCredentials.AddDataBinding(settings, nameof(settings.ProxyUseDefaultCredentials));
            this._view.ProxyUserName.AddDataBinding(settings, nameof(settings.ProxyCredentialsUsername));
            this._view.ProxyUserPassword.AddDataBinding(settings, nameof(settings.ProxyCredentialsPassword));
            this._uploadSettings = settings;
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
            this._view.FormClosing += FormClosing;
        }

        /// <summary>
        /// Unsubscribes from all view's events.
        /// </summary>
        public void UnsubscribeEvents()
        {
            this._view.FormClosing -= FormClosing;
        }

        /// <summary>
        /// Method called when the view is being closed.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The form closing event args</param>
        private void FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (this._uploadSettings.NetworkSettingsAreValid(out var errors))
            {
                this.Dispose();
                return;
            }

            MessageBox.Show(this._view, errors, this._view.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }
    }
}