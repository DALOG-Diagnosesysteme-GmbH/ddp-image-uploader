// -----------------------------------------------------------------------
// <copyright file="MainController.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Dalog.DataPlatform.Client.ImageUploader.ExtensionMethods;
using Dalog.DataPlatform.Client.ImageUploader.Forms;
using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Dalog.DataPlatform.Client.ImageUploader.Schema;

namespace Dalog.DataPlatform.Client.ImageUploader.Controllers
{
    /// <summary>
    /// The main controller class.
    /// </summary>
    internal sealed class MainController : IController<MainForm>
    {
        /// <summary>
        /// The HTTP repository
        /// </summary>
        private readonly HttpRepository _httpRepository;

        /// <summary>
        /// The uplaod settings.
        /// </summary>
        private readonly UploadSettings _uploadSettings;

        /// <summary>
        /// The view.
        /// </summary>
        private readonly MainForm _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainController"/> class.
        /// </summary>
        public MainController(HttpRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            this._httpRepository = repository;
            this._view = new MainForm();
            this._uploadSettings = new UploadSettings();
            this.SubscribeEvents();
            this.SetSettingsDataBindings();
            this._uploadSettings.Initialize();
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        public MainForm View => this._view;

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
            this._view.SectionLocalInformation.OnSelectFolderButtonClick += OnSelectFolderButtonClick;
            this._view.CommandBar.OnButtonTestConnectionClick += OnButtonTestConnectionClick;
            this._view.CommandBar.OnButtonResetSettingsClick += OnButtonResetSettingsClick;
            this._view.CommandBar.OnButtonNetworkSettingsClick += OnButtonNetworkSettingsClick;
        }

        /// <summary>
        /// Unsubscribes from all view's events.
        /// </summary>
        public void UnsubscribeEvents()
        {
            this._view.FormClosing -= View_FormClosing;
            this._view.UploadButton.OnButtonClick -= UploadButton_Click;
            this._view.SectionLocalInformation.OnSelectFolderButtonClick -= OnSelectFolderButtonClick;
            this._view.CommandBar.OnButtonTestConnectionClick -= OnButtonTestConnectionClick;
            this._view.CommandBar.OnButtonResetSettingsClick -= OnButtonResetSettingsClick;
            this._view.CommandBar.OnButtonNetworkSettingsClick -= OnButtonNetworkSettingsClick;
        }

        /// <summary>
        /// Method called when the network settings button is clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void OnButtonNetworkSettingsClick(object? sender, EventArgs e)
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
        private void OnButtonResetSettingsClick(object? sender, EventArgs e)
        {
            using var dialog = new ConfirmationDialog("Do you really want to reset all settings to their default value?");
            if (dialog.ShowDialog(this._view) != DialogResult.Yes)
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
        private async void OnButtonTestConnectionClick(object? sender, EventArgs e)
        {
            using var cts = new CancellationTokenSource();
            using var progressPanel = new ProgressPanel(cts, "Testing connection to the Data Platform...");
            progressPanel.Show(this._view);

            var response = await this._httpRepository.TestConnectionAsync(this._uploadSettings, cts.Token);
            if (response.IsSuccessStatusCode)
            {
                MessageDialog.Show(this._view, MessageBoxIcon.Information, "Connection successful!");
            }
            else
            {
                var body = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
                MessageDialog.Show(this._view, MessageBoxIcon.Error, $"Connection error ({response.StatusCode}):{Environment.NewLine}{body}");
            }
        }

        /// <summary>
        /// Method called when the select folder button is clicked.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args.</param>
        private void OnSelectFolderButtonClick(object? sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this._view) != DialogResult.OK || string.IsNullOrEmpty(dialog.SelectedPath))
            {
                return;
            }

            this._uploadSettings.Folder = dialog.SelectedPath;
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
            if (!this._uploadSettings.SettingsAreValid(out var errors))
            {
                MessageDialog.Show(this._view, MessageBoxIcon.Error, errors);
                return;
            }

            this._view.HideFormWhile(() =>
            {
                using var ctrl = new UploadController(this._httpRepository, this._uploadSettings);
                ctrl.View.ShowDialog(this._view);
            });
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