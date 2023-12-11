namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelBaseUrl = new Label();
            textBoxBaseUrl = new TextBox();
            textBoxApiKey = new TextBox();
            labelApiKey = new Label();
            buttonTestConnection = new Button();
            groupBoxSettings = new GroupBox();
            groupBoxLocal = new GroupBox();
            buttonFolderSelect = new Button();
            textBoxLocalFolder = new TextBox();
            labelFolder = new Label();
            labelImageType = new Label();
            comboBoxImageType = new ComboBox();
            groupBoxDdp = new GroupBox();
            labelDalogId = new Label();
            textBoxDalogId = new TextBox();
            labelMachineId = new Label();
            textBoxMachineId = new TextBox();
            groupBoxNetwork = new GroupBox();
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
            buttonResetSettings = new Button();
            groupBoxLog = new GroupBox();
            groupBoxControls = new GroupBox();
            groupBoxSettings.SuspendLayout();
            groupBoxLocal.SuspendLayout();
            groupBoxDdp.SuspendLayout();
            groupBoxNetwork.SuspendLayout();
            groupBoxProxySettings.SuspendLayout();
            groupBoxControls.SuspendLayout();
            SuspendLayout();
            // 
            // labelBaseUrl
            // 
            labelBaseUrl.AutoSize = true;
            labelBaseUrl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelBaseUrl.Location = new Point(6, 25);
            labelBaseUrl.Name = "labelBaseUrl";
            labelBaseUrl.Size = new Size(110, 15);
            labelBaseUrl.TabIndex = 0;
            labelBaseUrl.Text = "Base URL (required)";
            // 
            // textBoxBaseUrl
            // 
            textBoxBaseUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxBaseUrl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBaseUrl.Location = new Point(197, 22);
            textBoxBaseUrl.Name = "textBoxBaseUrl";
            textBoxBaseUrl.Size = new Size(545, 23);
            textBoxBaseUrl.TabIndex = 1;
            // 
            // textBoxApiKey
            // 
            textBoxApiKey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxApiKey.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxApiKey.Location = new Point(197, 51);
            textBoxApiKey.Name = "textBoxApiKey";
            textBoxApiKey.PasswordChar = '*';
            textBoxApiKey.Size = new Size(545, 23);
            textBoxApiKey.TabIndex = 3;
            // 
            // labelApiKey
            // 
            labelApiKey.AutoSize = true;
            labelApiKey.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelApiKey.Location = new Point(6, 54);
            labelApiKey.Name = "labelApiKey";
            labelApiKey.Size = new Size(101, 15);
            labelApiKey.TabIndex = 2;
            labelApiKey.Text = "API key (required)";
            // 
            // buttonTestConnection
            // 
            buttonTestConnection.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonTestConnection.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonTestConnection.Location = new Point(6, 21);
            buttonTestConnection.Name = "buttonTestConnection";
            buttonTestConnection.Size = new Size(150, 23);
            buttonTestConnection.TabIndex = 4;
            buttonTestConnection.Text = "Test connection";
            buttonTestConnection.UseVisualStyleBackColor = true;
            buttonTestConnection.Click += ButtonTestConnection_Click;
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSettings.Controls.Add(groupBoxLocal);
            groupBoxSettings.Controls.Add(groupBoxDdp);
            groupBoxSettings.Controls.Add(groupBoxNetwork);
            groupBoxSettings.Location = new Point(12, 12);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Size = new Size(760, 500);
            groupBoxSettings.TabIndex = 5;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Settings";
            // 
            // groupBoxLocal
            // 
            groupBoxLocal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxLocal.Controls.Add(buttonFolderSelect);
            groupBoxLocal.Controls.Add(textBoxLocalFolder);
            groupBoxLocal.Controls.Add(labelFolder);
            groupBoxLocal.Controls.Add(labelImageType);
            groupBoxLocal.Controls.Add(comboBoxImageType);
            groupBoxLocal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxLocal.Location = new Point(6, 173);
            groupBoxLocal.Name = "groupBoxLocal";
            groupBoxLocal.Size = new Size(748, 85);
            groupBoxLocal.TabIndex = 18;
            groupBoxLocal.TabStop = false;
            groupBoxLocal.Text = "Local";
            // 
            // buttonFolderSelect
            // 
            buttonFolderSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonFolderSelect.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonFolderSelect.Location = new Point(667, 22);
            buttonFolderSelect.Name = "buttonFolderSelect";
            buttonFolderSelect.Size = new Size(75, 23);
            buttonFolderSelect.TabIndex = 6;
            buttonFolderSelect.Text = "Select";
            buttonFolderSelect.UseVisualStyleBackColor = true;
            buttonFolderSelect.Click += ButtonFolderSelect_Click;
            // 
            // textBoxLocalFolder
            // 
            textBoxLocalFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLocalFolder.Enabled = false;
            textBoxLocalFolder.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxLocalFolder.Location = new Point(197, 22);
            textBoxLocalFolder.Name = "textBoxLocalFolder";
            textBoxLocalFolder.Size = new Size(464, 23);
            textBoxLocalFolder.TabIndex = 5;
            // 
            // labelFolder
            // 
            labelFolder.AutoSize = true;
            labelFolder.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFolder.Location = new Point(6, 26);
            labelFolder.Name = "labelFolder";
            labelFolder.Size = new Size(134, 15);
            labelFolder.TabIndex = 4;
            labelFolder.Text = "Images folder (required)";
            // 
            // labelImageType
            // 
            labelImageType.AutoSize = true;
            labelImageType.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelImageType.Location = new Point(6, 54);
            labelImageType.Name = "labelImageType";
            labelImageType.Size = new Size(67, 15);
            labelImageType.TabIndex = 14;
            labelImageType.Text = "Image Type";
            // 
            // comboBoxImageType
            // 
            comboBoxImageType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxImageType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxImageType.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxImageType.FormattingEnabled = true;
            comboBoxImageType.Location = new Point(197, 51);
            comboBoxImageType.Name = "comboBoxImageType";
            comboBoxImageType.Size = new Size(545, 23);
            comboBoxImageType.TabIndex = 13;
            // 
            // groupBoxDdp
            // 
            groupBoxDdp.Controls.Add(textBoxBaseUrl);
            groupBoxDdp.Controls.Add(labelBaseUrl);
            groupBoxDdp.Controls.Add(labelApiKey);
            groupBoxDdp.Controls.Add(textBoxApiKey);
            groupBoxDdp.Controls.Add(labelDalogId);
            groupBoxDdp.Controls.Add(textBoxDalogId);
            groupBoxDdp.Controls.Add(labelMachineId);
            groupBoxDdp.Controls.Add(textBoxMachineId);
            groupBoxDdp.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxDdp.Location = new Point(6, 22);
            groupBoxDdp.Name = "groupBoxDdp";
            groupBoxDdp.Size = new Size(748, 145);
            groupBoxDdp.TabIndex = 17;
            groupBoxDdp.TabStop = false;
            groupBoxDdp.Text = "Data Platform";
            // 
            // labelDalogId
            // 
            labelDalogId.AutoSize = true;
            labelDalogId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDalogId.Location = new Point(6, 112);
            labelDalogId.Name = "labelDalogId";
            labelDalogId.Size = new Size(59, 15);
            labelDalogId.TabIndex = 9;
            labelDalogId.Text = "DALOG Id";
            // 
            // textBoxDalogId
            // 
            textBoxDalogId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDalogId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDalogId.Location = new Point(197, 109);
            textBoxDalogId.Name = "textBoxDalogId";
            textBoxDalogId.Size = new Size(545, 23);
            textBoxDalogId.TabIndex = 10;
            // 
            // labelMachineId
            // 
            labelMachineId.AutoSize = true;
            labelMachineId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMachineId.Location = new Point(6, 83);
            labelMachineId.Name = "labelMachineId";
            labelMachineId.Size = new Size(92, 15);
            labelMachineId.TabIndex = 7;
            labelMachineId.Text = "DDP Machine Id";
            // 
            // textBoxMachineId
            // 
            textBoxMachineId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMachineId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMachineId.Location = new Point(197, 80);
            textBoxMachineId.Name = "textBoxMachineId";
            textBoxMachineId.Size = new Size(545, 23);
            textBoxMachineId.TabIndex = 8;
            // 
            // groupBoxNetwork
            // 
            groupBoxNetwork.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxNetwork.Controls.Add(checkBoxDisableSslChecks);
            groupBoxNetwork.Controls.Add(groupBoxProxySettings);
            groupBoxNetwork.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxNetwork.Location = new Point(6, 264);
            groupBoxNetwork.Name = "groupBoxNetwork";
            groupBoxNetwork.Size = new Size(748, 230);
            groupBoxNetwork.TabIndex = 16;
            groupBoxNetwork.TabStop = false;
            groupBoxNetwork.Text = "Network (Advanced)";
            // 
            // checkBoxDisableSslChecks
            // 
            checkBoxDisableSslChecks.AutoSize = true;
            checkBoxDisableSslChecks.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxDisableSslChecks.Location = new Point(6, 22);
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
            groupBoxProxySettings.Location = new Point(6, 47);
            groupBoxProxySettings.Name = "groupBoxProxySettings";
            groupBoxProxySettings.Size = new Size(736, 175);
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
            textBoxProxyCredentialsUsername.Size = new Size(539, 23);
            textBoxProxyCredentialsUsername.TabIndex = 20;
            // 
            // textBoxProxyCredentialsPassword
            // 
            textBoxProxyCredentialsPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxProxyCredentialsPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxProxyCredentialsPassword.Location = new Point(191, 138);
            textBoxProxyCredentialsPassword.Name = "textBoxProxyCredentialsPassword";
            textBoxProxyCredentialsPassword.PasswordChar = '*';
            textBoxProxyCredentialsPassword.Size = new Size(539, 23);
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
            checkBoxProxyUseDefaultCredentials.CheckedChanged += CheckBoxProxyUseDefaultCredentials_CheckedChanged;
            // 
            // textBoxProxyAddress
            // 
            textBoxProxyAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxProxyAddress.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxProxyAddress.Location = new Point(191, 51);
            textBoxProxyAddress.Name = "textBoxProxyAddress";
            textBoxProxyAddress.Size = new Size(539, 23);
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
            checkBoxUseProxy.CheckedChanged += CheckBoxUseProxy_CheckedChanged;
            // 
            // buttonResetSettings
            // 
            buttonResetSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonResetSettings.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonResetSettings.Location = new Point(162, 21);
            buttonResetSettings.Name = "buttonResetSettings";
            buttonResetSettings.Size = new Size(150, 23);
            buttonResetSettings.TabIndex = 6;
            buttonResetSettings.Text = "Reset settings";
            buttonResetSettings.UseVisualStyleBackColor = true;
            buttonResetSettings.Click += ButtonResetSettings_Click;
            // 
            // groupBoxLog
            // 
            groupBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxLog.Location = new Point(12, 518);
            groupBoxLog.Name = "groupBoxLog";
            groupBoxLog.Size = new Size(760, 125);
            groupBoxLog.TabIndex = 7;
            groupBoxLog.TabStop = false;
            groupBoxLog.Text = "Log";
            // 
            // groupBoxControls
            // 
            groupBoxControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxControls.Controls.Add(buttonTestConnection);
            groupBoxControls.Controls.Add(buttonResetSettings);
            groupBoxControls.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxControls.Location = new Point(12, 649);
            groupBoxControls.Name = "groupBoxControls";
            groupBoxControls.Size = new Size(760, 50);
            groupBoxControls.TabIndex = 8;
            groupBoxControls.TabStop = false;
            groupBoxControls.Text = "Controls";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 711);
            Controls.Add(groupBoxControls);
            Controls.Add(groupBoxLog);
            Controls.Add(groupBoxSettings);
            MinimumSize = new Size(800, 600);
            Name = "MainForm";
            Text = "DALOG Image Uploader";
            Load += MainForm_Load;
            groupBoxSettings.ResumeLayout(false);
            groupBoxLocal.ResumeLayout(false);
            groupBoxLocal.PerformLayout();
            groupBoxDdp.ResumeLayout(false);
            groupBoxDdp.PerformLayout();
            groupBoxNetwork.ResumeLayout(false);
            groupBoxNetwork.PerformLayout();
            groupBoxProxySettings.ResumeLayout(false);
            groupBoxProxySettings.PerformLayout();
            groupBoxControls.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label labelBaseUrl;
        private TextBox textBoxBaseUrl;
        private TextBox textBoxApiKey;
        private Label labelApiKey;
        private Button buttonTestConnection;
        private GroupBox groupBoxSettings;
        private Button buttonFolderSelect;
        private TextBox textBoxLocalFolder;
        private Label labelFolder;
        private Button buttonResetSettings;
        private TextBox textBoxMachineId;
        private Label labelMachineId;
        private TextBox textBoxDalogId;
        private Label labelDalogId;
        private CheckBox checkBoxUseProxy;
        private CheckBox checkBoxDisableSslChecks;
        private Label labelImageType;
        private ComboBox comboBoxImageType;
        private GroupBox groupBoxProxySettings;
        private Label labelProxyAddress;
        private ComboBox comboBox1;
        private TextBox textBoxProxyAddress;
        private TextBox textBoxProxyCredentialsPassword;
        private CheckBox checkBoxProxyUseDefaultCredentials;
        private Label labelProxyCredentialsUsername;
        private TextBox textBoxProxyCredentialsUsername;
        private Label labelProxyCredentialsPassword;
        private GroupBox groupBoxNetwork;
        private GroupBox groupBoxLocal;
        private GroupBox groupBoxDdp;
        private GroupBox groupBoxLog;
        private GroupBox groupBoxControls;
    }
}
