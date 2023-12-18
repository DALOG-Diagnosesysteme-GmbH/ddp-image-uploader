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
            groupBoxNetwork.Controls.Add(groupBoxProxySettings);
            groupBoxNetwork.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxNetwork.Location = new Point(12, 12);
            groupBoxNetwork.Name = "groupBoxNetwork";
            groupBoxNetwork.Size = new Size(760, 266);
            groupBoxNetwork.TabIndex = 17;
            groupBoxNetwork.TabStop = false;
            groupBoxNetwork.Text = "Network (Advanced)";
            // 
            // labelTimeout
            // 
            labelTimeout.AutoSize = true;
            labelTimeout.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTimeout.Location = new Point(6, 53);
            labelTimeout.Name = "labelTimeout";
            labelTimeout.Size = new Size(105, 15);
            labelTimeout.TabIndex = 20;
            labelTimeout.Text = "Timeout (seconds)";
            // 
            // numericUpDownTimeout
            // 
            numericUpDownTimeout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownTimeout.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownTimeout.Location = new Point(203, 51);
            numericUpDownTimeout.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            numericUpDownTimeout.Name = "numericUpDownTimeout";
            numericUpDownTimeout.Size = new Size(551, 23);
            numericUpDownTimeout.TabIndex = 19;
            numericUpDownTimeout.TextAlign = HorizontalAlignment.Center;
            numericUpDownTimeout.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // checkBoxDisableSslChecks
            // 
            checkBoxDisableSslChecks.AutoSize = true;
            checkBoxDisableSslChecks.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxDisableSslChecks.Location = new Point(6, 24);
            checkBoxDisableSslChecks.Name = "checkBoxDisableSslChecks";
            checkBoxDisableSslChecks.Size = new Size(126, 19);
            checkBoxDisableSslChecks.TabIndex = 11;
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
            groupBoxProxySettings.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxProxySettings.Location = new Point(6, 80);
            groupBoxProxySettings.Name = "groupBoxProxySettings";
            groupBoxProxySettings.Size = new Size(748, 175);
            groupBoxProxySettings.TabIndex = 15;
            groupBoxProxySettings.TabStop = false;
            groupBoxProxySettings.Text = "Proxy Settings";
            // 
            // labelProxyCredentialsPassword
            // 
            labelProxyCredentialsPassword.AutoSize = true;
            labelProxyCredentialsPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelProxyCredentialsPassword.Location = new Point(6, 141);
            labelProxyCredentialsPassword.Name = "labelProxyCredentialsPassword";
            labelProxyCredentialsPassword.Size = new Size(57, 15);
            labelProxyCredentialsPassword.TabIndex = 22;
            labelProxyCredentialsPassword.Text = "Password";
            // 
            // labelProxyCredentialsUsername
            // 
            labelProxyCredentialsUsername.AutoSize = true;
            labelProxyCredentialsUsername.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelProxyCredentialsUsername.Location = new Point(6, 112);
            labelProxyCredentialsUsername.Name = "labelProxyCredentialsUsername";
            labelProxyCredentialsUsername.Size = new Size(60, 15);
            labelProxyCredentialsUsername.TabIndex = 21;
            labelProxyCredentialsUsername.Text = "Username";
            // 
            // textBoxProxyCredentialsUsername
            // 
            textBoxProxyCredentialsUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxProxyCredentialsUsername.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxProxyCredentialsUsername.Location = new Point(191, 109);
            textBoxProxyCredentialsUsername.Name = "textBoxProxyCredentialsUsername";
            textBoxProxyCredentialsUsername.Size = new Size(551, 23);
            textBoxProxyCredentialsUsername.TabIndex = 20;
            // 
            // textBoxProxyCredentialsPassword
            // 
            textBoxProxyCredentialsPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxProxyCredentialsPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxProxyCredentialsPassword.Location = new Point(191, 138);
            textBoxProxyCredentialsPassword.Name = "textBoxProxyCredentialsPassword";
            textBoxProxyCredentialsPassword.PasswordChar = '*';
            textBoxProxyCredentialsPassword.Size = new Size(551, 23);
            textBoxProxyCredentialsPassword.TabIndex = 19;
            // 
            // checkBoxProxyUseDefaultCredentials
            // 
            checkBoxProxyUseDefaultCredentials.AutoSize = true;
            checkBoxProxyUseDefaultCredentials.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxProxyUseDefaultCredentials.Location = new Point(6, 82);
            checkBoxProxyUseDefaultCredentials.Name = "checkBoxProxyUseDefaultCredentials";
            checkBoxProxyUseDefaultCredentials.Size = new Size(148, 19);
            checkBoxProxyUseDefaultCredentials.TabIndex = 18;
            checkBoxProxyUseDefaultCredentials.Text = "Use Default Credentials";
            checkBoxProxyUseDefaultCredentials.UseVisualStyleBackColor = true;
            // 
            // textBoxProxyAddress
            // 
            textBoxProxyAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxProxyAddress.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxProxyAddress.Location = new Point(191, 51);
            textBoxProxyAddress.Name = "textBoxProxyAddress";
            textBoxProxyAddress.Size = new Size(551, 23);
            textBoxProxyAddress.TabIndex = 17;
            // 
            // labelProxyAddress
            // 
            labelProxyAddress.AutoSize = true;
            labelProxyAddress.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelProxyAddress.Location = new Point(6, 54);
            labelProxyAddress.Name = "labelProxyAddress";
            labelProxyAddress.Size = new Size(49, 15);
            labelProxyAddress.TabIndex = 16;
            labelProxyAddress.Text = "Address";
            // 
            // checkBoxUseProxy
            // 
            checkBoxUseProxy.AutoSize = true;
            checkBoxUseProxy.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxUseProxy.Location = new Point(6, 26);
            checkBoxUseProxy.Name = "checkBoxUseProxy";
            checkBoxUseProxy.Size = new Size(78, 19);
            checkBoxUseProxy.TabIndex = 12;
            checkBoxUseProxy.Text = "Use Proxy";
            checkBoxUseProxy.UseVisualStyleBackColor = true;
            // 
            // NetworkForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 291);
            Controls.Add(groupBoxNetwork);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(800, 330);
            MinimizeBox = false;
            MinimumSize = new Size(800, 330);
            Name = "NetworkForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DALOG Image Uploader";
            groupBoxNetwork.ResumeLayout(false);
            groupBoxNetwork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeout).EndInit();
            groupBoxProxySettings.ResumeLayout(false);
            groupBoxProxySettings.PerformLayout();
            ResumeLayout(false);
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
    }
}