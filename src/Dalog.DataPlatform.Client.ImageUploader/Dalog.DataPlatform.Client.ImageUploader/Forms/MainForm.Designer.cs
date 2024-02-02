namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            buttonUpload = new Views.PrimaryButton();
            checkBoxMode = new CheckBox();
            labelTitle = new Label();
            panelHeader = new Panel();
            panelFooter = new Panel();
            labelHours = new Label();
            numAutoUploadHours = new NumericUpDown();
            labelStartUploadEvery = new Label();
            panelHeader.SuspendLayout();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAutoUploadHours).BeginInit();
            SuspendLayout();
            // 
            // buttonUpload
            // 
            buttonUpload.Anchor = AnchorStyles.Right;
            buttonUpload.AutoSize = true;
            buttonUpload.BackColor = Color.Transparent;
            buttonUpload.ButtonText = "Upload Images";
            buttonUpload.Font = new Font("Segoe UI", 10F);
            buttonUpload.Location = new Point(413, 5);
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
            checkBoxMode.Location = new Point(428, 8);
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
            panelHeader.Size = new Size(536, 40);
            panelHeader.TabIndex = 0;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(labelHours);
            panelFooter.Controls.Add(numAutoUploadHours);
            panelFooter.Controls.Add(labelStartUploadEvery);
            panelFooter.Controls.Add(buttonUpload);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 39);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(536, 46);
            panelFooter.TabIndex = 4;
            // 
            // labelHours
            // 
            labelHours.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelHours.AutoSize = true;
            labelHours.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelHours.ForeColor = Color.FromArgb(44, 82, 159);
            labelHours.Location = new Point(177, 12);
            labelHours.Name = "labelHours";
            labelHours.Size = new Size(41, 15);
            labelHours.TabIndex = 7;
            labelHours.Text = "hours.";
            // 
            // numAutoUploadHours
            // 
            numAutoUploadHours.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numAutoUploadHours.BorderStyle = BorderStyle.FixedSingle;
            numAutoUploadHours.Font = new Font("Segoe UI", 9F);
            numAutoUploadHours.ForeColor = Color.FromArgb(43, 42, 41);
            numAutoUploadHours.Location = new Point(129, 9);
            numAutoUploadHours.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAutoUploadHours.Name = "numAutoUploadHours";
            numAutoUploadHours.Size = new Size(47, 23);
            numAutoUploadHours.TabIndex = 6;
            numAutoUploadHours.TextAlign = HorizontalAlignment.Center;
            numAutoUploadHours.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // labelStartUploadEvery
            // 
            labelStartUploadEvery.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelStartUploadEvery.AutoSize = true;
            labelStartUploadEvery.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelStartUploadEvery.ForeColor = Color.FromArgb(44, 82, 159);
            labelStartUploadEvery.Location = new Point(18, 12);
            labelStartUploadEvery.Name = "labelStartUploadEvery";
            labelStartUploadEvery.Size = new Size(110, 15);
            labelStartUploadEvery.TabIndex = 5;
            labelStartUploadEvery.Text = "Start upload every";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(536, 85);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(50, 49, 48);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DALOG Images Uploader";
            HelpButtonClicked += MainForm_HelpButtonClicked;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAutoUploadHours).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Views.PrimaryButton buttonUpload;
        private CheckBox checkBoxMode;
        private Label labelTitle;
        private Panel panelHeader;
        private Panel panelFooter;
        private Label labelStartUploadEvery;
        private NumericUpDown numAutoUploadHours;
        private Label labelHours;
    }
}