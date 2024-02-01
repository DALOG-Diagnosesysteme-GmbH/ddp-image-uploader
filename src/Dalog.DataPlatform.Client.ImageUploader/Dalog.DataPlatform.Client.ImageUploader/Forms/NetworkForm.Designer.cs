namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    partial class NetworkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkForm));
            groupBoxNetwork = new GroupBox();
            labelTimeout = new Label();
            numericUpDownTimeout = new NumericUpDown();
            checkBoxDisableSslChecks = new CheckBox();
            groupBoxProxySettings = new GroupBox();
            labelProxyCredentialsPassword = new Label();
            labelProxyCredentialsUsername = new Label();
            textBoxProxyCredentialsUsername = new TextBox();
            textBoxProxyCredentialsPassword = new TextBox();
            checkBoxProxyUseDefaultCredentials = new CheckBox();
            textBoxProxyAddress = new TextBox();
            labelProxyAddress = new Label();
            checkBoxUseProxy = new CheckBox();
            buttonDone = new Views.PrimaryButton();
            labelTitle = new Label();
            groupBoxNetwork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeout).BeginInit();
            groupBoxProxySettings.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxNetwork
            // 
            groupBoxNetwork.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxNetwork.Controls.Add(labelTimeout);
            groupBoxNetwork.Controls.Add(numericUpDownTimeout);
            groupBoxNetwork.Controls.Add(checkBoxDisableSslChecks);
            groupBoxNetwork.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            groupBoxNetwork.Location = new Point(12, 45);
            groupBoxNetwork.Name = "groupBoxNetwork";
            groupBoxNetwork.Size = new Size(345, 98);
            groupBoxNetwork.TabIndex = 1;
            groupBoxNetwork.TabStop = false;
            groupBoxNetwork.Text = "Network (Advanced)";
            // 
            // labelTimeout
            // 
            labelTimeout.AutoSize = true;
            labelTimeout.Font = new Font("Segoe UI", 10F);
            labelTimeout.Location = new Point(13, 58);
            labelTimeout.Name = "labelTimeout";
            labelTimeout.Size = new Size(120, 19);
            labelTimeout.TabIndex = 20;
            labelTimeout.Text = "Timeout (seconds)";
            // 
            // numericUpDownTimeout
            // 
            numericUpDownTimeout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownTimeout.Font = new Font("Segoe UI", 10F);
            numericUpDownTimeout.Location = new Point(150, 56);
            numericUpDownTimeout.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            numericUpDownTimeout.Name = "numericUpDownTimeout";
            numericUpDownTimeout.Size = new Size(184, 25);
            numericUpDownTimeout.TabIndex = 2;
            numericUpDownTimeout.TextAlign = HorizontalAlignment.Center;
            numericUpDownTimeout.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // checkBoxDisableSslChecks
            // 
            checkBoxDisableSslChecks.AutoSize = true;
            checkBoxDisableSslChecks.Font = new Font("Segoe UI", 10F);
            checkBoxDisableSslChecks.Location = new Point(13, 25);
            checkBoxDisableSslChecks.Name = "checkBoxDisableSslChecks";
            checkBoxDisableSslChecks.RightToLeft = RightToLeft.Yes;
            checkBoxDisableSslChecks.Size = new Size(144, 23);
            checkBoxDisableSslChecks.TabIndex = 1;
            checkBoxDisableSslChecks.Text = "Disable SSL Checks";
            checkBoxDisableSslChecks.UseVisualStyleBackColor = true;
            // 
            // groupBoxProxySettings
            // 
            groupBoxProxySettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxProxySettings.Controls.Add(labelProxyCredentialsPassword);
            groupBoxProxySettings.Controls.Add(labelProxyCredentialsUsername);
            groupBoxProxySettings.Controls.Add(textBoxProxyCredentialsUsername);
            groupBoxProxySettings.Controls.Add(textBoxProxyCredentialsPassword);
            groupBoxProxySettings.Controls.Add(checkBoxProxyUseDefaultCredentials);
            groupBoxProxySettings.Controls.Add(textBoxProxyAddress);
            groupBoxProxySettings.Controls.Add(labelProxyAddress);
            groupBoxProxySettings.Controls.Add(checkBoxUseProxy);
            groupBoxProxySettings.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            groupBoxProxySettings.Location = new Point(12, 149);
            groupBoxProxySettings.Name = "groupBoxProxySettings";
            groupBoxProxySettings.Size = new Size(345, 194);
            groupBoxProxySettings.TabIndex = 2;
            groupBoxProxySettings.TabStop = false;
            groupBoxProxySettings.Text = "Proxy Settings";
            // 
            // labelProxyCredentialsPassword
            // 
            labelProxyCredentialsPassword.AutoSize = true;
            labelProxyCredentialsPassword.Font = new Font("Segoe UI", 10F);
            labelProxyCredentialsPassword.Location = new Point(13, 162);
            labelProxyCredentialsPassword.Name = "labelProxyCredentialsPassword";
            labelProxyCredentialsPassword.Size = new Size(67, 19);
            labelProxyCredentialsPassword.TabIndex = 22;
            labelProxyCredentialsPassword.Text = "Password";
            // 
            // labelProxyCredentialsUsername
            // 
            labelProxyCredentialsUsername.AutoSize = true;
            labelProxyCredentialsUsername.Font = new Font("Segoe UI", 10F);
            labelProxyCredentialsUsername.Location = new Point(13, 126);
            labelProxyCredentialsUsername.Name = "labelProxyCredentialsUsername";
            labelProxyCredentialsUsername.Size = new Size(71, 19);
            labelProxyCredentialsUsername.TabIndex = 21;
            labelProxyCredentialsUsername.Text = "Username";
            // 
            // textBoxProxyCredentialsUsername
            // 
            textBoxProxyCredentialsUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxProxyCredentialsUsername.Font = new Font("Segoe UI", 10F);
            textBoxProxyCredentialsUsername.Location = new Point(150, 123);
            textBoxProxyCredentialsUsername.Name = "textBoxProxyCredentialsUsername";
            textBoxProxyCredentialsUsername.Size = new Size(184, 25);
            textBoxProxyCredentialsUsername.TabIndex = 4;
            // 
            // textBoxProxyCredentialsPassword
            // 
            textBoxProxyCredentialsPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxProxyCredentialsPassword.Font = new Font("Segoe UI", 10F);
            textBoxProxyCredentialsPassword.Location = new Point(150, 159);
            textBoxProxyCredentialsPassword.Name = "textBoxProxyCredentialsPassword";
            textBoxProxyCredentialsPassword.PasswordChar = '*';
            textBoxProxyCredentialsPassword.Size = new Size(184, 25);
            textBoxProxyCredentialsPassword.TabIndex = 5;
            // 
            // checkBoxProxyUseDefaultCredentials
            // 
            checkBoxProxyUseDefaultCredentials.AutoSize = true;
            checkBoxProxyUseDefaultCredentials.Font = new Font("Segoe UI", 10F);
            checkBoxProxyUseDefaultCredentials.Location = new Point(13, 93);
            checkBoxProxyUseDefaultCredentials.Name = "checkBoxProxyUseDefaultCredentials";
            checkBoxProxyUseDefaultCredentials.RightToLeft = RightToLeft.Yes;
            checkBoxProxyUseDefaultCredentials.Size = new Size(171, 23);
            checkBoxProxyUseDefaultCredentials.TabIndex = 3;
            checkBoxProxyUseDefaultCredentials.Text = "Use Default Credentials";
            checkBoxProxyUseDefaultCredentials.UseVisualStyleBackColor = true;
            checkBoxProxyUseDefaultCredentials.CheckedChanged += CheckBoxProxyUseDefaultCredentials_CheckedChanged;
            // 
            // textBoxProxyAddress
            // 
            textBoxProxyAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxProxyAddress.Font = new Font("Segoe UI", 10F);
            textBoxProxyAddress.Location = new Point(150, 57);
            textBoxProxyAddress.Name = "textBoxProxyAddress";
            textBoxProxyAddress.Size = new Size(184, 25);
            textBoxProxyAddress.TabIndex = 2;
            // 
            // labelProxyAddress
            // 
            labelProxyAddress.AutoSize = true;
            labelProxyAddress.Enabled = false;
            labelProxyAddress.Font = new Font("Segoe UI", 10F);
            labelProxyAddress.Location = new Point(13, 60);
            labelProxyAddress.Name = "labelProxyAddress";
            labelProxyAddress.Size = new Size(58, 19);
            labelProxyAddress.TabIndex = 16;
            labelProxyAddress.Text = "Address";
            // 
            // checkBoxUseProxy
            // 
            checkBoxUseProxy.AutoSize = true;
            checkBoxUseProxy.Font = new Font("Segoe UI", 10F);
            checkBoxUseProxy.Location = new Point(13, 27);
            checkBoxUseProxy.Name = "checkBoxUseProxy";
            checkBoxUseProxy.RightToLeft = RightToLeft.Yes;
            checkBoxUseProxy.Size = new Size(89, 23);
            checkBoxUseProxy.TabIndex = 1;
            checkBoxUseProxy.Text = "Use Proxy";
            checkBoxUseProxy.UseVisualStyleBackColor = true;
            checkBoxUseProxy.CheckedChanged += CheckBoxUseProxy_CheckedChanged;
            // 
            // buttonDone
            // 
            buttonDone.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDone.AutoSize = true;
            buttonDone.BackColor = Color.Transparent;
            buttonDone.ButtonText = "Done";
            buttonDone.Font = new Font("Segoe UI", 10F);
            buttonDone.Location = new Point(265, 349);
            buttonDone.MinimumSize = new Size(92, 32);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(92, 32);
            buttonDone.TabIndex = 3;
            buttonDone.OnButtonClick += ButtonDone_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.Location = new Point(13, 8);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(167, 25);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Network Settings";
            // 
            // NetworkForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(370, 389);
            Controls.Add(labelTitle);
            Controls.Add(buttonDone);
            Controls.Add(groupBoxProxySettings);
            Controls.Add(groupBoxNetwork);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(43, 42, 41);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NetworkForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Network Settings";
            groupBoxNetwork.ResumeLayout(false);
            groupBoxNetwork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeout).EndInit();
            groupBoxProxySettings.ResumeLayout(false);
            groupBoxProxySettings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxNetwork;
        private Label labelTimeout;
        private NumericUpDown numericUpDownTimeout;
        private CheckBox checkBoxDisableSslChecks;
        private GroupBox groupBoxProxySettings;
        private Label labelProxyCredentialsPassword;
        private Label labelProxyCredentialsUsername;
        private TextBox textBoxProxyCredentialsUsername;
        private TextBox textBoxProxyCredentialsPassword;
        private CheckBox checkBoxProxyUseDefaultCredentials;
        private TextBox textBoxProxyAddress;
        private Label labelProxyAddress;
        private CheckBox checkBoxUseProxy;
        private Views.PrimaryButton buttonDone;
        private Label labelTitle;
    }
}