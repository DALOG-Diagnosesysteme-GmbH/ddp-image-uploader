namespace Dalog.DataPlatform.Client.ImageUploader.Views
{
    partial class SettingsCommandBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonTestConnection = new SecondaryButton();
            buttonResetSettings = new SecondaryButton();
            buttonNetworkSettings = new SecondaryButton();
            commandBarContainer = new FlowLayoutPanel();
            commandBarContainer.SuspendLayout();
            SuspendLayout();
            // 
            // buttonTestConnection
            // 
            buttonTestConnection.AutoSize = true;
            buttonTestConnection.BackColor = Color.Transparent;
            buttonTestConnection.ButtonText = "Test connection";
            buttonTestConnection.Font = new Font("Segoe UI", 10F);
            buttonTestConnection.Location = new Point(263, 3);
            buttonTestConnection.Margin = new Padding(0, 0, 8, 0);
            buttonTestConnection.MinimumSize = new Size(92, 32);
            buttonTestConnection.Name = "buttonTestConnection";
            buttonTestConnection.Size = new Size(114, 32);
            buttonTestConnection.TabIndex = 0;
            buttonTestConnection.Click += ButtonTestConnection_Click;
            // 
            // buttonResetSettings
            // 
            buttonResetSettings.AutoSize = true;
            buttonResetSettings.BackColor = Color.Transparent;
            buttonResetSettings.ButtonText = "Reset settings";
            buttonResetSettings.Font = new Font("Segoe UI", 10F);
            buttonResetSettings.Location = new Point(141, 3);
            buttonResetSettings.Margin = new Padding(0, 0, 8, 0);
            buttonResetSettings.MinimumSize = new Size(92, 32);
            buttonResetSettings.Name = "buttonResetSettings";
            buttonResetSettings.Size = new Size(114, 32);
            buttonResetSettings.TabIndex = 1;
            buttonResetSettings.Click += ButtonResetSettings_Click;
            // 
            // buttonNetworkSettings
            // 
            buttonNetworkSettings.AutoSize = true;
            buttonNetworkSettings.BackColor = Color.Transparent;
            buttonNetworkSettings.ButtonText = "Network settings";
            buttonNetworkSettings.Font = new Font("Segoe UI", 10F);
            buttonNetworkSettings.Location = new Point(10, 3);
            buttonNetworkSettings.Margin = new Padding(0, 0, 8, 0);
            buttonNetworkSettings.MinimumSize = new Size(92, 32);
            buttonNetworkSettings.Name = "buttonNetworkSettings";
            buttonNetworkSettings.Size = new Size(123, 32);
            buttonNetworkSettings.TabIndex = 2;
            buttonNetworkSettings.Click += ButtonNetworkSettings_Click;
            // 
            // commandBarContainer
            // 
            commandBarContainer.Controls.Add(buttonNetworkSettings);
            commandBarContainer.Controls.Add(buttonResetSettings);
            commandBarContainer.Controls.Add(buttonTestConnection);
            commandBarContainer.Dock = DockStyle.Fill;
            commandBarContainer.Location = new Point(0, 0);
            commandBarContainer.Name = "commandBarContainer";
            commandBarContainer.Padding = new Padding(10, 3, 10, 3);
            commandBarContainer.Size = new Size(407, 39);
            commandBarContainer.TabIndex = 3;
            // 
            // SettingsCommandBar
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(commandBarContainer);
            Font = new Font("Segoe UI", 10F);
            Name = "SettingsCommandBar";
            Size = new Size(407, 39);
            commandBarContainer.ResumeLayout(false);
            commandBarContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private SecondaryButton buttonTestConnection;
        private SecondaryButton buttonResetSettings;
        private SecondaryButton buttonNetworkSettings;
        private FlowLayoutPanel commandBarContainer;
    }
}
