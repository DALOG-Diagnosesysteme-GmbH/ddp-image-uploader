﻿using Dalog.DataPlatform.Client.ImageUploader.ExtensionMethods;
using Dalog.DataPlatform.Client.ImageUploader.Forms;
using Dalog.DataPlatform.Client.ImageUploader.Schema;

namespace Dalog.DataPlatform.Client.ImageUploader.Controllers
{
    /// <summary>
    /// The main controller class.
    /// </summary>
    internal sealed class MainController : IController<MainForm2>
    {
        /// <summary>
        /// The uplaod settings.
        /// </summary>
        private readonly Settings _uploadSettings;

        /// <summary>
        /// The view.
        /// </summary>
        private readonly MainForm2 _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainController"/> class.
        /// </summary>
        public MainController()
        {
            this._view = new MainForm2();
            this._uploadSettings = new Settings();
            this.SubscribeEvents();
            this.SetSettingsDataBindings();
            this._uploadSettings.Initialize();
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        public MainForm2 View => this._view;

        /// <summary>
        /// Disposes all resources
        /// </summary>
        public void Dispose()
        {
            this.UnsubscribeEvents();
            this._view?.Dispose();
        }

        /// <summary>
        /// Subscribes to all view's events.
        /// </summary>
        public void SubscribeEvents()
        {
            this._view.FormClosing += View_FormClosing;
            this._view.UploadButton.OnButtonClick += UploadButton_Click;
            this._view.CommandBar.OnButtonTestConnectionClick += CommandBar_OnButtonTestConnectionClick;
            this._view.CommandBar.OnButtonResetSettingsClick += CommandBar_OnButtonResetSettingsClick;
            this._view.CommandBar.OnButtonNetworkSettingsClick += CommandBar_OnButtonNetworkSettingsClick;
        }

        /// <summary>
        /// Unsubscribes from all view's events.
        /// </summary>
        public void UnsubscribeEvents()
        {
            this._view.FormClosing -= View_FormClosing;
            this._view.UploadButton.OnButtonClick -= UploadButton_Click;
            this._view.CommandBar.OnButtonTestConnectionClick -= CommandBar_OnButtonTestConnectionClick;
            this._view.CommandBar.OnButtonResetSettingsClick -= CommandBar_OnButtonResetSettingsClick;
            this._view.CommandBar.OnButtonNetworkSettingsClick -= CommandBar_OnButtonNetworkSettingsClick;
        }

        /// <summary>
        /// Method called when the network settings button is clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void CommandBar_OnButtonNetworkSettingsClick(object? sender, EventArgs e)
        {
            this._view.HideFormWhile(() =>
            {
                using var ctrl = new NetworkSettingsController(this._uploadSettings);
                ctrl.View.ShowDialog(this._view);
            });
        }

        /// <summary>
        /// Method called when the reset settings button is clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void CommandBar_OnButtonResetSettingsClick(object? sender, EventArgs e)
        {
            using var dialog = new ConfirmationDialog("Do you really want to reset all settings to their default value?");
            if(dialog.ShowDialog(this._view) != DialogResult.Yes)
            {
                return;
            }

            this._uploadSettings.Reset();
        }

        /// <summary>
        /// Method called when the test connection settings button is clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void CommandBar_OnButtonTestConnectionClick(object? sender, EventArgs e)
        {
            this._view.HideFormWhile(() =>
            {
                using var cts = new CancellationTokenSource();
                using var progressPanel = new ProgressPanel(cts);
                progressPanel.ShowDialog(this._view);
            });
        }

        /// <summary>
        /// Sets the upload settings object data bindings.
        /// </summary>
        private void SetSettingsDataBindings()
        {
            this._view.SectionDdpInformation.MachineId.AddDataBinding(this._uploadSettings, nameof(this._uploadSettings.MachineId));
            this._view.SectionDdpInformation.MachineNumber.AddDataBinding(this._uploadSettings, nameof(this._uploadSettings.DalogId));
            this._view.SectionLocalInformation.ImagesFolder.AddDataBinding(this._uploadSettings, nameof(this._uploadSettings.Folder));
            this._view.SectionLocalInformation.ImagesType.DataSource = Enum.GetValues(typeof(ImageType));
            this._view.SectionLocalInformation.ImagesType.AddDataBinding(this._uploadSettings, nameof(this._uploadSettings.ImageType));
        }

        /// <summary>
        /// Method called when the upload button is clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void UploadButton_Click(object? sender, EventArgs e)
        {
            var lala = this._uploadSettings;
        }

        /// <summary>
        /// Method called when the form is closing.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The form closing event args.</param>
        private void View_FormClosing(object? sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}