// -----------------------------------------------------------------------
// <copyright file="MainController.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Dalog.DataPlatform.Client.ImageUploader.ExtensionMethods;
using Dalog.DataPlatform.Client.ImageUploader.Forms;
using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Dalog.DataPlatform.Client.ImageUploader.Schema;
using Microsoft.Extensions.Options;

namespace Dalog.DataPlatform.Client.ImageUploader.Controllers
{
    /// <summary>
    /// The main controller class.
    /// </summary>
    internal sealed class MainController : IController<MainForm>
    {
        private readonly HttpRepository _httpRepository;

        private readonly UploadSettings _uploadSettings;

        private readonly MainForm _view;

        public MainController(IOptions<AppSettings> appsettings, HttpRepository repository)
        {
            ArgumentNullException.ThrowIfNull(appsettings, nameof(appsettings));
            ArgumentNullException.ThrowIfNull(repository, nameof(repository));
            this._httpRepository = repository;
            this._view = new MainForm();
            this._uploadSettings = new UploadSettings();
            this.SubscribeEvents();
            this.SetSettingsDataBindings();
            this._uploadSettings.Initialize();
            this._view.AutoUploadHours.Value = appsettings.Value?.AutoUploadIntervalHours ?? 1;
        }

        internal delegate void AutoUploadHoursEvent(int hours);

        /// <summary>
        /// Event triggered when the auto upload interval in hours has changed.
        /// </summary>
        internal event AutoUploadHoursEvent? OnAutoUploadHoursChanged;

        public MainForm View => this._view;

        public void Dispose()
        {
            this.UnsubscribeEvents();
            this._view?.Dispose();
        }

        public void SubscribeEvents()
        {
            this._view.FormClosing += View_FormClosing;
            this._view.AutoUploadHours.ValueChanged += AutoUploadHours_ValueChanged;
            this._view.UploadButton.OnButtonClick += UploadButton_Click;
            this._view.SectionLocalInformation.OnSelectFolderButtonClick += OnSelectFolderButtonClick;
            this._view.CommandBar.OnButtonTestConnectionClick += OnButtonTestConnectionClick;
            this._view.CommandBar.OnButtonResetSettingsClick += OnButtonResetSettingsClick;
            this._view.CommandBar.OnButtonNetworkSettingsClick += OnButtonNetworkSettingsClick;
        }

        public void UnsubscribeEvents()
        {
            this._view.FormClosing -= View_FormClosing;
            this._view.AutoUploadHours.ValueChanged -= AutoUploadHours_ValueChanged;
            this._view.UploadButton.OnButtonClick -= UploadButton_Click;
            this._view.SectionLocalInformation.OnSelectFolderButtonClick -= OnSelectFolderButtonClick;
            this._view.CommandBar.OnButtonTestConnectionClick -= OnButtonTestConnectionClick;
            this._view.CommandBar.OnButtonResetSettingsClick -= OnButtonResetSettingsClick;
            this._view.CommandBar.OnButtonNetworkSettingsClick -= OnButtonNetworkSettingsClick;
        }

        private void AutoUploadHours_ValueChanged(object? sender, EventArgs e)
        {
            this.OnAutoUploadHoursChanged?.Invoke((int)this._view.AutoUploadHours.Value);
        }

        private void OnButtonNetworkSettingsClick(object? sender, EventArgs e)
        {
            this._view.HideFormWhile(() =>
            {
                using var ctrl = new NetworkSettingsController(this._uploadSettings);
                ctrl.View.ShowDialog(this._view);
            });
        }

        private void OnButtonResetSettingsClick(object? sender, EventArgs e)
        {
            using var dialog = new ConfirmationDialog("Do you really want to reset all settings to their default value?");
            if (dialog.ShowDialog(this._view) != DialogResult.Yes)
            {
                return;
            }

            this._uploadSettings.Reset();
        }

        private async void OnButtonTestConnectionClick(object? sender, EventArgs e)
        {
            using var cts = new CancellationTokenSource();
            using var panel = ProgressPanel.Instantiate(this._view, cts, "Testing connection to the Data Platform...");
            panel?.Show();
            var response = await this._httpRepository.TestConnectionAsync(this._uploadSettings, cts.Token);
            if (response.IsSuccessStatusCode)
            {
                MessageDialog.Show(this._view, MessageBoxIcon.Information, "Connection successful!");
            }
            else
            {
                var body = await response.Content.ReadAsStringAsync();
                MessageDialog.Show(this._view, MessageBoxIcon.Warning, $"Connection error ({response.StatusCode}):{Environment.NewLine}{body}");
            }
        }

        private void OnSelectFolderButtonClick(object? sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this._view) != DialogResult.OK || string.IsNullOrEmpty(dialog.SelectedPath))
            {
                return;
            }

            this._uploadSettings.Folder = dialog.SelectedPath;
        }

        private void SetSettingsDataBindings()
        {
            this._view.SectionDdpInformation.MachineId.AddDataBinding(this._uploadSettings, nameof(this._uploadSettings.MachineId));
            this._view.SectionDdpInformation.MachineNumber.AddDataBinding(this._uploadSettings, nameof(this._uploadSettings.DalogId));
            this._view.SectionLocalInformation.ImagesFolder.AddDataBinding(this._uploadSettings, nameof(this._uploadSettings.Folder));
            this._view.SectionLocalInformation.ImagesType.DataSource = Enum.GetValues(typeof(ImageType));
            this._view.SectionLocalInformation.ImagesType.AddDataBinding(this._uploadSettings, nameof(this._uploadSettings.ImageType));
        }

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

        private void View_FormClosing(object? sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
