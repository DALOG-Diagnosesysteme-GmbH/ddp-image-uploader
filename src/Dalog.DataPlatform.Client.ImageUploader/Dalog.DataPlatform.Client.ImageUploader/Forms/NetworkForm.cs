// -----------------------------------------------------------------------
// <copyright file="NetworkForm.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Dalog.DataPlatform.Client.ImageUploader.Forms;

/// <summary>
/// The network form class.
/// </summary>
public partial class NetworkForm : Form
{
    public NetworkForm()
    {
        InitializeComponent();
        this.CheckBoxUseProxy_CheckedChanged(this, EventArgs.Empty);
    }

    public CheckBox DisableSslChecks
    {
        get
        {
            return this.checkBoxDisableSslChecks;
        }
    }

    public TextBox ProxyAddress
    {
        get
        {
            return this.textBoxProxyAddress;
        }
    }

    public CheckBox ProxyUseDefaultCredentials
    {
        get
        {
            return this.checkBoxProxyUseDefaultCredentials;
        }
    }

    public TextBox ProxyUserName
    {
        get
        {
            return this.textBoxProxyCredentialsUsername;
        }
    }

    public TextBox ProxyUserPassword
    {
        get
        {
            return this.textBoxProxyCredentialsPassword;
        }
    }

    public NumericUpDown Timeout
    {
        get
        {
            return this.numericUpDownTimeout;
        }
    }

    public CheckBox UseProxy
    {
        get
        {
            return this.checkBoxUseProxy;
        }
    }

    private void ButtonDone_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void CheckBoxProxyUseDefaultCredentials_CheckedChanged(object sender, EventArgs e)
    {
        var enable = this.checkBoxUseProxy.Checked && !this.checkBoxProxyUseDefaultCredentials.Checked;
        this.labelProxyCredentialsUsername.Enabled = enable;
        this.textBoxProxyCredentialsUsername.Enabled = enable;
        this.labelProxyCredentialsPassword.Enabled = enable;
        this.textBoxProxyCredentialsPassword.Enabled = enable;
    }

    private void CheckBoxUseProxy_CheckedChanged(object sender, EventArgs e)
    {
        this.labelProxyAddress.Enabled = this.checkBoxUseProxy.Checked;
        this.textBoxProxyAddress.Enabled = this.checkBoxUseProxy.Checked;
        this.checkBoxProxyUseDefaultCredentials.Enabled = this.checkBoxUseProxy.Checked;
        this.CheckBoxProxyUseDefaultCredentials_CheckedChanged(sender, e);
    }
}
