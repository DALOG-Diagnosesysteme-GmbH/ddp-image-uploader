using Dalog.DataPlatform.Client.ImageUploader.Schema;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms;

public partial class NetworkForm : Form
{

    public NetworkForm()
    {
        InitializeComponent();
    }

    internal NetworkForm(Settings settings)
    {
        InitializeComponent();

        checkBoxDisableSslChecks.Checked = settings.DisableSslChecks;
        checkBoxUseProxy.Checked = settings.UseProxy;
        checkBoxProxyUseDefaultCredentials.Checked = settings.ProxyUseDefaultCredentials;
        textBoxProxyCredentialsUsername.Text = settings.ProxyCredentialsUsername;
        textBoxProxyCredentialsPassword.Text = settings.ProxyCredentialsPassword;
        textBoxProxyAddress.Text = settings.ProxyAddress;
        numericUpDownTimeout.Value = settings.Timeout;
    }

    public bool DisableSslChecks => checkBoxDisableSslChecks.Checked;
    public bool UseProxy => checkBoxUseProxy.Checked;
    public bool ProxyUseDefaultCredentials => checkBoxProxyUseDefaultCredentials.Checked;
    public string? ProxyCredentialsUsername => textBoxProxyCredentialsUsername.Text;
    public string? ProxyCredentialsPassword => textBoxProxyCredentialsPassword.Text;
    public string? ProxyAddress => textBoxProxyAddress.Text;
    public int Timeout => Convert.ToInt32(numericUpDownTimeout.Value);
}
