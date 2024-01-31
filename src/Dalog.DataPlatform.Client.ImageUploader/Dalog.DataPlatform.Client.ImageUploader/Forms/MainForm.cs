using Dalog.DataPlatform.Client.ImageUploader.Schema;
using System.Diagnostics;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms;

public partial class MainForm : Form
{
    private const string PingUrl = "/files/v1/ping";
    private readonly Dictionary<Control, bool> _controlStates;
    private readonly Settings _settings;

    public MainForm()
    {
        InitializeComponent();

        _settings = new Settings();
        _controlStates = new Dictionary<Control, bool>();
    }

    private void ButtonFolderSelect_Click(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog();
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _settings.Folder = dialog.SelectedPath;
        }
    }

    private void ButtonNetworkSettings_Click(object sender, EventArgs e)
    {
        //using var networkForm = new NetworkForm(_settings);
        //networkForm.ShowDialog(this);
        //_settings.DisableSslChecks = networkForm.DisableSslChecks;
        //_settings.Timeout = networkForm.Timeout;
        //_settings.UseProxy = networkForm.UseProxy;
        //_settings.ProxyAddress = networkForm.ProxyAddress;
        //_settings.ProxyUseDefaultCredentials = networkForm.ProxyUseDefaultCredentials;
        //_settings.ProxyCredentialsUsername = networkForm.ProxyCredentialsUsername;
        //_settings.ProxyCredentialsPassword = networkForm.ProxyCredentialsPassword;
    }

    private void ButtonResetSettings_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show(this, "Do you really want to reset all settings to their default value?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            _settings.Reset();
        }
    }

    private async void ButtonTestConnection_Click(object sender, EventArgs e)
    {
        try
        {
            StartWaitAnimation();
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
        finally
        {
            StopWaitAnimation();
        }
    }

    private void ButtonUpload_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_settings.BaseUrl))
        {
            MessageBox.Show(this, "Base URL is required", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!Uri.TryCreate(_settings.BaseUrl, UriKind.Absolute, out var _))
        {
            MessageBox.Show(this, "Base URL is not a valid URL", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(_settings.ApiKey))
        {
            MessageBox.Show(this, "API Key is required", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var isMachineIdOrDalogIdRequired = Settings.IsMachineIdOrDalogIdRequired(_settings.ImageType);
        if (isMachineIdOrDalogIdRequired)
        {
            if (string.IsNullOrWhiteSpace(_settings.MachineId) && string.IsNullOrWhiteSpace(_settings.DalogId))
            {
                MessageBox.Show(this, "Either Machine Id or DALOG Id are required", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(_settings.MachineId) && !Guid.TryParse(_settings.MachineId, out var _))
            {
                MessageBox.Show(this, "Machine Id is not valid", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(_settings.DalogId) && !new DalogIdAttribute().IsValid(_settings.DalogId))
            {
                MessageBox.Show(this, "DALOG Id is not valid", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        if (string.IsNullOrWhiteSpace(_settings.Folder))
        {
            MessageBox.Show(this, "Folder is required", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!Directory.Exists(_settings.Folder))
        {
            MessageBox.Show(this, "Folder does not exist", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (_settings.UseProxy)
        {
            if (string.IsNullOrWhiteSpace(_settings.ProxyAddress))
            {
                MessageBox.Show(this, "Proxy Adress is required", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_settings.ProxyUseDefaultCredentials)
            {
                if (string.IsNullOrWhiteSpace(_settings.ProxyCredentialsUsername))
                {
                    MessageBox.Show(this, "Proxy Username is required", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        using var copyForm = new CopyForm(_settings);
        copyForm.ShowDialog(this);
    }

    private void MainForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
    {
        Process.Start("CMD.exe", $"/C start msedge \"https://github.com/DALOG-Diagnosesysteme-GmbH/ddp-image-uploader\"");
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        textBoxBaseUrl.DataBindings.Add(new Binding(nameof(textBoxBaseUrl.Text), _settings, nameof(_settings.BaseUrl)));
        textBoxApiKey.DataBindings.Add(new Binding(nameof(textBoxApiKey.Text), _settings, nameof(_settings.ApiKey)));
        textBoxLocalFolder.DataBindings.Add(new Binding(nameof(textBoxLocalFolder.Text), _settings, nameof(_settings.Folder)));
        textBoxMachineId.DataBindings.Add(new Binding(nameof(textBoxMachineId.Text), _settings, nameof(_settings.MachineId)));
        textBoxDalogId.DataBindings.Add(new Binding(nameof(textBoxDalogId.Text), _settings, nameof(_settings.DalogId)));

        comboBoxImageType.DataSource = Enum.GetValues(typeof(ImageType));
        comboBoxImageType.DataBindings.Add(new Binding(nameof(comboBoxImageType.SelectedItem), _settings, nameof(_settings.ImageType)));

        _settings.Initialize();
    }

    private void RestoreControls(Control control)
    {
        foreach (Control c in control.Controls)
        {
            if (c == progressBar) continue;

            if (_controlStates.TryGetValue(c, out bool enabled))
            {
                c.Enabled = enabled;
            }
            RestoreControls(c);
        }
    }

    private void StartWaitAnimation()
    {
        _controlStates.Clear();
        StoreAndDisableControls(this);
        progressBar.Style = ProgressBarStyle.Marquee;
    }

    private void StopWaitAnimation()
    {
        RestoreControls(this);
        _controlStates.Clear();
        progressBar.Style = ProgressBarStyle.Blocks;
    }

    private void StoreAndDisableControls(Control control)
    {
        foreach (Control c in control.Controls)
        {
            if (c == progressBar) continue;
            if (c is TextBox || c is Button || c is ComboBox || c is NumericUpDown || c is CheckBox)
            {
                _controlStates.Add(c, c.Enabled);
                c.Enabled = false;
            }

            StoreAndDisableControls(c);
        }
    }
}