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
        private readonly UploadSettings _uploadSettings;

        private readonly NetworkForm _view;

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

        public NetworkForm View => this._view;

        public void Dispose()
        {
            this.UnsubscribeEvents();
            this._view?.Dispose();
        }

        public void SubscribeEvents()
        {
            this._view.FormClosing += FormClosing;
        }

        public void UnsubscribeEvents()
        {
            this._view.FormClosing -= FormClosing;
        }

        private void FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (this._uploadSettings.NetworkSettingsAreValid(out var errors))
            {
                this.Dispose();
                return;
            }

            MessageDialog.Show(this._view, MessageBoxIcon.Error, errors);
            e.Cancel = true;
        }
    }
}
