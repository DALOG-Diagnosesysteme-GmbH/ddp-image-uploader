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
        private readonly HttpSettings _httpSettings;

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
            this._httpSettings = new HttpSettings();
            this.SubscribeEvents();
            this.SetSettingsDataBindings();
            this._httpSettings.Initialize();
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
            this._view.SectionLocalInformation.OnSelectFolderButtonClick += SectionLocalInformation_OnSelectFolderButtonClick;
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
            this._view.SectionLocalInformation.OnSelectFolderButtonClick -= SectionLocalInformation_OnSelectFolderButtonClick;
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
                using var ctrl = new NetworkSettingsController(this._httpSettings);
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
            if (dialog.ShowDialog(this._view) != DialogResult.Yes)
            {
                return;
            }

            this._httpSettings.Reset();
        }

        /// <summary>
        /// Method called when the test connection settings button is clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private async void CommandBar_OnButtonTestConnectionClick(object? sender, EventArgs e)
        {
            using var cts = new CancellationTokenSource();
            using var progressPanel = new ProgressPanel(cts);
            progressPanel.Show(this._view);

            var response = await this._httpRepository.TestConnectionAsync(this._httpSettings, cts.Token);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show(this._view, "Connection successful", this._view.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var body = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
                MessageBox.Show(this._view, $"Connection error ({response.StatusCode}):{Environment.NewLine}{body}", this._view.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Method called when the select folder button is clicked.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args.</param>
        private void SectionLocalInformation_OnSelectFolderButtonClick(object? sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this._view) != DialogResult.OK || string.IsNullOrEmpty(dialog.SelectedPath))
            {
                return;
            }

            this._httpSettings.Folder = dialog.SelectedPath;
        }

        /// <summary>
        /// Sets the upload settings object data bindings.
        /// </summary>
        private void SetSettingsDataBindings()
        {
            this._view.SectionDdpInformation.MachineId.AddDataBinding(this._httpSettings, nameof(this._httpSettings.MachineId));
            this._view.SectionDdpInformation.MachineNumber.AddDataBinding(this._httpSettings, nameof(this._httpSettings.DalogId));
            this._view.SectionLocalInformation.ImagesFolder.AddDataBinding(this._httpSettings, nameof(this._httpSettings.Folder));
            this._view.SectionLocalInformation.ImagesType.DataSource = Enum.GetValues(typeof(ImageType));
            this._view.SectionLocalInformation.ImagesType.AddDataBinding(this._httpSettings, nameof(this._httpSettings.ImageType));
        }

        /// <summary>
        /// Method called when the upload button is clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void UploadButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this._httpSettings.BaseUrl))
            {
                MessageBox.Show(this._view, "Base URL is required", this._view.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Uri.TryCreate(this._httpSettings.BaseUrl, UriKind.Absolute, out var _))
            {
                MessageBox.Show(this._view, "Base URL is not a valid URL", this._view.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(this._httpSettings.ApiKey))
            {
                MessageBox.Show(this._view, "API Key is required", this._view.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(this._httpSettings.Folder))
            {
                MessageBox.Show(this._view, "Folder is required", this._view.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(this._httpSettings.Folder))
            {
                MessageBox.Show(this._view, "Folder does not exist", this._view.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this._httpSettings.UseProxy)
            {
                if (string.IsNullOrWhiteSpace(this._httpSettings.ProxyAddress))
                {
                    MessageBox.Show(this._view, "Proxy Adress is required", this._view.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!this._httpSettings.ProxyUseDefaultCredentials)
                {
                    if (string.IsNullOrWhiteSpace(this._httpSettings.ProxyCredentialsUsername))
                    {
                        MessageBox.Show(this._view, "Proxy Username is required", this._view.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            using var copyForm = new CopyForm(this._httpRepository, this._httpSettings);
            copyForm.ShowDialog(this._view);
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