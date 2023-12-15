using Dalog.DataPlatform.Client.ImageUploader.Schema;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    public partial class NetworkForm : Form
    {
        private readonly Settings _settings;

        public NetworkForm()
        {
            InitializeComponent();

            _settings = new Settings();
        }

        internal NetworkForm(Settings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        private void NetworkForm_Load(object sender, EventArgs e)
        {
            checkBoxDisableSslChecks.DataBindings.Add(new Binding(nameof(checkBoxDisableSslChecks.Checked), _settings, nameof(_settings.DisableSslChecks)));
            checkBoxUseProxy.DataBindings.Add(new Binding(nameof(checkBoxUseProxy.Checked), _settings, nameof(_settings.UseProxy)));
            checkBoxProxyUseDefaultCredentials.DataBindings.Add(new Binding(nameof(checkBoxProxyUseDefaultCredentials.Checked), _settings, nameof(_settings.ProxyUseDefaultCredentials)));
            textBoxProxyCredentialsUsername.DataBindings.Add(new Binding(nameof(textBoxProxyCredentialsUsername.Text), _settings, nameof(_settings.ProxyCredentialsUsername)));
            textBoxProxyCredentialsPassword.DataBindings.Add(new Binding(nameof(textBoxProxyCredentialsPassword.Text), _settings, nameof(_settings.ProxyCredentialsPassword)));
            textBoxProxyAddress.DataBindings.Add(new Binding(nameof(textBoxProxyAddress.Text), _settings, nameof(_settings.ProxyAddress)));
            numericUpDownTimeout.DataBindings.Add(new Binding(nameof(numericUpDownTimeout.Value), _settings, nameof(_settings.Timeout)));
        }
    }
}
