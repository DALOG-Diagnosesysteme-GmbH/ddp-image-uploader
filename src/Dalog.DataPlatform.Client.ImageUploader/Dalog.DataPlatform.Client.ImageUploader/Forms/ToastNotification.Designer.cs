namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    partial class ToastNotification
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
            labelNotification = new Label();
            pictureBoxIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // labelNotification
            // 
            labelNotification.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelNotification.Location = new Point(50, 0);
            labelNotification.Name = "labelNotification";
            labelNotification.Padding = new Padding(10);
            labelNotification.Size = new Size(281, 59);
            labelNotification.TabIndex = 0;
            labelNotification.Text = "This is an example of a Toast Notification This is an example of a Toast Notification";
            labelNotification.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Anchor = AnchorStyles.Left;
            pictureBoxIcon.Image = Properties.Resources.check;
            pictureBoxIcon.Location = new Point(12, 13);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(32, 32);
            pictureBoxIcon.TabIndex = 1;
            pictureBoxIcon.TabStop = false;
            // 
            // ToastNotification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 245, 223);
            ClientSize = new Size(331, 59);
            Controls.Add(pictureBoxIcon);
            Controls.Add(labelNotification);
            ForeColor = Color.FromArgb(53, 52, 51);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ToastNotification";
            StartPosition = FormStartPosition.Manual;
            Text = "ToastNotification";
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelNotification;
        private PictureBox pictureBoxIcon;
    }
}