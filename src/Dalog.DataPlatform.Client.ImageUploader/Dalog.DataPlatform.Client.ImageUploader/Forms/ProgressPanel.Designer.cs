namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    partial class ProgressPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressPanel));
            progressBar = new ProgressBar();
            labelStatus = new Label();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(12, 12);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(292, 23);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // labelStatus
            // 
            labelStatus.Anchor = AnchorStyles.Bottom;
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(121, 41);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(67, 19);
            labelStatus.TabIndex = 1;
            labelStatus.Text = "Loading...";
            labelStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ProgressPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(316, 69);
            Controls.Add(labelStatus);
            Controls.Add(progressBar);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(43, 42, 41);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProgressPanel";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Loading...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar;
        private Label labelStatus;
    }
}