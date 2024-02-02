namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    partial class MessageDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageDialog));
            labelMessage = new Label();
            buttonOk = new Views.PrimaryButton();
            messageIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)messageIcon).BeginInit();
            SuspendLayout();
            // 
            // labelMessage
            // 
            labelMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelMessage.Font = new Font("Segoe UI", 9F);
            labelMessage.Location = new Point(90, 4);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(298, 60);
            labelMessage.TabIndex = 0;
            labelMessage.Text = "tastaqs asets atased tast asdtgysat saedt astdasd tastd ";
            labelMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.AutoSize = true;
            buttonOk.BackColor = Color.Transparent;
            buttonOk.ButtonText = "OK";
            buttonOk.Font = new Font("Segoe UI", 10F);
            buttonOk.Location = new Point(305, 64);
            buttonOk.MinimumSize = new Size(82, 32);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(82, 32);
            buttonOk.TabIndex = 2;
            buttonOk.OnButtonClick += ButtonOk_OnButtonClick;
            // 
            // messageIcon
            // 
            messageIcon.Anchor = AnchorStyles.Left;
            messageIcon.BackgroundImage = Properties.Resources.error;
            messageIcon.BackgroundImageLayout = ImageLayout.Zoom;
            messageIcon.Location = new Point(23, 20);
            messageIcon.Name = "messageIcon";
            messageIcon.Size = new Size(50, 50);
            messageIcon.SizeMode = PictureBoxSizeMode.Zoom;
            messageIcon.TabIndex = 1;
            messageIcon.TabStop = false;
            // 
            // MessageDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 107);
            Controls.Add(buttonOk);
            Controls.Add(messageIcon);
            Controls.Add(labelMessage);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(43, 42, 41);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MessageDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MessageDialog";
            ((System.ComponentModel.ISupportInitialize)messageIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMessage;
        private Views.PrimaryButton buttonOk;
        private PictureBox messageIcon;
    }
}