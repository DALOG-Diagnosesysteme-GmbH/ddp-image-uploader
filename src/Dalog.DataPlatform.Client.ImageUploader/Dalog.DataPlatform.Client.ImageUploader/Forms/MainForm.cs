using Dalog.DataPlatform.Client.ImageUploader.Schema;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    public partial class MainForm : Form
    {
        private const string PingUrl = "/files/v1/ping";
        private readonly Settings _settings;

        public MainForm()
        {
            InitializeComponent();

            _settings = new Settings();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBoxBaseUrl.DataBindings.Add(new Binding(nameof(textBoxBaseUrl.Text), _settings, nameof(_settings.BaseUrl)));
            textBoxApiKey.DataBindings.Add(new Binding(nameof(textBoxApiKey.Text), _settings, nameof(_settings.ApiKey)));
            textBoxLocalFolder.DataBindings.Add(new Binding(nameof(textBoxLocalFolder.Text), _settings, nameof(_settings.Folder)));
            textBoxMachineId.DataBindings.Add(new Binding(nameof(textBoxMachineId.Text), _settings, nameof(_settings.MachineId)));
            textBoxDalogId.DataBindings.Add(new Binding(nameof(textBoxDalogId.Text), _settings, nameof(_settings.DalogId)));
            checkBoxDisableSslChecks.DataBindings.Add(new Binding(nameof(checkBoxDisableSslChecks.Checked), _settings, nameof(_settings.DisableSslChecks)));
            checkBoxUseProxy.DataBindings.Add(new Binding(nameof(checkBoxUseProxy.Checked), _settings, nameof(_settings.UseProxy)));
            checkBoxProxyUseDefaultCredentials.DataBindings.Add(new Binding(nameof(checkBoxProxyUseDefaultCredentials.Checked), _settings, nameof(_settings.ProxyUseDefaultCredentials)));
            textBoxProxyCredentialsUsername.DataBindings.Add(new Binding(nameof(textBoxProxyCredentialsUsername.Text), _settings, nameof(_settings.ProxyCredentialsUsername)));
            textBoxProxyCredentialsPassword.DataBindings.Add(new Binding(nameof(textBoxProxyCredentialsPassword.Text), _settings, nameof(_settings.ProxyCredentialsPassword)));
            textBoxProxyAddress.DataBindings.Add(new Binding(nameof(textBoxProxyAddress.Text), _settings, nameof(_settings.ProxyAddress)));

            comboBoxImageType.DataSource = Enum.GetValues(typeof(ImageType));
            comboBoxImageType.DataBindings.Add(new Binding(nameof(comboBoxImageType.SelectedItem), _settings, nameof(_settings.ImageType)));

            _settings.Initialize();
        }

        private void ButtonFolderSelect_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                _settings.Folder = dialog.SelectedPath;
            }
        }

        private void ButtonResetSettings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you really want to reset all settings to their default value?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _settings.Reset();
            }
        }

        private void CheckBoxUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseProxy.Checked)
            {
                textBoxProxyAddress.Enabled = true;
                checkBoxProxyUseDefaultCredentials.Enabled = true;
                textBoxProxyCredentialsUsername.Enabled = !checkBoxProxyUseDefaultCredentials.Checked;
                textBoxProxyCredentialsPassword.Enabled = !checkBoxProxyUseDefaultCredentials.Checked;
            }
            else
            {
                textBoxProxyAddress.Enabled = false;
                checkBoxProxyUseDefaultCredentials.Enabled = false;
                textBoxProxyCredentialsUsername.Enabled = false;
                textBoxProxyCredentialsPassword.Enabled = false;
            }
        }

        private void CheckBoxProxyUseDefaultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxProxyUseDefaultCredentials.Checked)
            {
                textBoxProxyCredentialsUsername.Enabled = false;
                textBoxProxyCredentialsPassword.Enabled = false;
            }
            else
            {
                textBoxProxyCredentialsUsername.Enabled = true;
                textBoxProxyCredentialsPassword.Enabled = true;
            }
        }

        private async void ButtonTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                var client = _settings.GetHttpClient();
                var response = await client.GetAsync(PingUrl).ConfigureAwait(true);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(this, "Connection successful", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var body = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
                    MessageBox.Show(this, $"Connection error ({response.StatusCode}):{Environment.NewLine}{body}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
