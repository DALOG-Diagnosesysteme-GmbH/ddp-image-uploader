namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    partial class MainForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm2));
            buttonUpload = new Views.PrimaryButton();
            checkBoxMode = new CheckBox();
            labelTitle = new Label();
            panelHeader = new Panel();
            panelFooter = new Panel();
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // buttonUpload
            // 
            buttonUpload.Anchor = AnchorStyles.Top;
            buttonUpload.AutoSize = true;
            buttonUpload.BackColor = Color.Transparent;
            buttonUpload.ButtonText = "Upload Images";
            buttonUpload.Font = new Font("Segoe UI", 10F);
            buttonUpload.Location = new Point(168, 5);
            buttonUpload.MinimumSize = new Size(92, 32);
            buttonUpload.Name = "buttonUpload";
            buttonUpload.Size = new Size(111, 32);
            buttonUpload.TabIndex = 4;
            // 
            // checkBoxMode
            // 
            checkBoxMode.Anchor = AnchorStyles.Right;
            checkBoxMode.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxMode.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            checkBoxMode.Location = new Point(323, 8);
            checkBoxMode.Name = "checkBoxMode";
            checkBoxMode.Size = new Size(96, 25);
            checkBoxMode.TabIndex = 0;
            checkBoxMode.Text = "Expert Mode:";
            checkBoxMode.UseVisualStyleBackColor = true;
            checkBoxMode.CheckedChanged += CheckBoxMode_CheckedChanged;
            checkBoxMode.KeyUp += CheckBoxMode_KeyUp;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Left;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.Location = new Point(13, 8);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(154, 25);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Upload Settings";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(checkBoxMode);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(434, 40);
            panelHeader.TabIndex = 0;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(buttonUpload);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 39);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(434, 46);
            panelFooter.TabIndex = 4;
            // 
            // MainForm2
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(434, 85);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(50, 49, 48);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DALOG Images Uploader";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Views.PrimaryButton buttonUpload;
        private CheckBox checkBoxMode;
        private Label labelTitle;
        private Panel panelHeader;
        private Panel panelFooter;
    }
}