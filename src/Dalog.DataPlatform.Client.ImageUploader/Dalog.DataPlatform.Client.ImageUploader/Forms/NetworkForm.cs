﻿// -----------------------------------------------------------------------
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
    /// <summary>
    /// Initializes a new instance of the <see cref="NetworkForm"/> class.
    /// </summary>
    public NetworkForm()
    {
        InitializeComponent();
        this.CheckBoxUseProxy_CheckedChanged(this, EventArgs.Empty);
    }

    /// <summary>
    /// Gets the disable SSL checks checkbox.
    /// </summary>
    public CheckBox DisableSslChecks
    {
        get
        {
            return this.checkBoxDisableSslChecks;
        }
    }

    /// <summary>
    /// Gets the proxy address text box.
    /// </summary>
    public TextBox ProxyAddress
    {
        get
        {
            return this.textBoxProxyAddress;
        }
    }

    /// <summary>
    /// Gets the proxy use default credentials checkbox.
    /// </summary>
    public CheckBox ProxyUseDefaultCredentials
    {
        get
        {
            return this.checkBoxProxyUseDefaultCredentials;
        }
    }

    /// <summary>
    /// Gets the proxy username text box.
    /// </summary>
    public TextBox ProxyUserName
    {
        get
        {
            return this.textBoxProxyCredentialsUsername;
        }
    }

    /// <summary>
    /// Gets the proxy user password text box.
    /// </summary>
    public TextBox ProxyUserPassword
    {
        get
        {
            return this.textBoxProxyCredentialsPassword;
        }
    }

    /// <summary>
    /// Gets the timeout numeric up down.
    /// </summary>
    public NumericUpDown Timeout
    {
        get
        {
            return this.numericUpDownTimeout;
        }
    }

    /// <summary>
    /// Gets the use proxy checkbox.
    /// </summary>
    public CheckBox UseProxy
    {
        get
        {
            return this.checkBoxUseProxy;
        }
    }

    /// <summary>
    /// Method called when the done button is clicked.
    /// </summary>
    /// <param name="sender">The sender object</param>
    /// <param name="e">The event args.</param>
    private void ButtonDone_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    /// <summary>
    /// Method called when the use default credentials check box is changed.
    /// </summary>
    /// <param name="sender">The sender object</param>
    /// <param name="e">The event args.</param>
    private void CheckBoxProxyUseDefaultCredentials_CheckedChanged(object sender, EventArgs e)
    {
        var enable = this.checkBoxUseProxy.Checked && !this.checkBoxProxyUseDefaultCredentials.Checked;
        this.labelProxyCredentialsUsername.Enabled = enable;
        this.textBoxProxyCredentialsUsername.Enabled = enable;
        this.labelProxyCredentialsPassword.Enabled = enable;
        this.textBoxProxyCredentialsPassword.Enabled = enable;
    }

    /// <summary>
    /// Method called when the use proxy check box is changed.
    /// </summary>
    /// <param name="sender">The sender object</param>
    /// <param name="e">The event args.</param>
    private void CheckBoxUseProxy_CheckedChanged(object sender, EventArgs e)
    {
        this.labelProxyAddress.Enabled = this.checkBoxUseProxy.Checked;
        this.textBoxProxyAddress.Enabled = this.checkBoxUseProxy.Checked;
        this.checkBoxProxyUseDefaultCredentials.Enabled = this.checkBoxUseProxy.Checked;
        this.CheckBoxProxyUseDefaultCredentials_CheckedChanged(sender, e);
    }
}