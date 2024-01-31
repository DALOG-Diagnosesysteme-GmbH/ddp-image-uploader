namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    partial class ConfirmationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmationDialog));
            labelText = new Label();
            buttonConfirm = new Views.PrimaryButton();
            buttonReturn = new Views.SecondaryButton();
            SuspendLayout();
            // 
            // labelText
            // 
            labelText.Dock = DockStyle.Top;
            labelText.Location = new Point(0, 0);
            labelText.Name = "labelText";
            labelText.Padding = new Padding(10);
            labelText.Size = new Size(324, 59);
            labelText.TabIndex = 10;
            labelText.Text = "Do you really want to reset all settings to their default value? ";
            labelText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonConfirm.AutoSize = true;
            buttonConfirm.BackColor = Color.Transparent;
            buttonConfirm.ButtonText = "Confirm";
            buttonConfirm.Font = new Font("Segoe UI", 10F);
            buttonConfirm.Location = new Point(122, 60);
            buttonConfirm.MinimumSize = new Size(92, 32);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(92, 32);
            buttonConfirm.TabIndex = 2;
            buttonConfirm.OnButtonClick += ButtonConfirm_OnButtonClick;
            // 
            // buttonReturn
            // 
            buttonReturn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonReturn.AutoSize = true;
            buttonReturn.BackColor = Color.Transparent;
            buttonReturn.ButtonText = "Return";
            buttonReturn.Font = new Font("Segoe UI", 10F);
            buttonReturn.Location = new Point(220, 60);
            buttonReturn.MinimumSize = new Size(92, 32);
            buttonReturn.Name = "buttonReturn";
            buttonReturn.Size = new Size(92, 32);
            buttonReturn.TabIndex = 1;
            buttonReturn.OnButtonClick += ButtonReturn_OnButtonClick;
            // 
            // ConfirmationDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(324, 102);
            Controls.Add(buttonReturn);
            Controls.Add(buttonConfirm);
            Controls.Add(labelText);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(43, 42, 41);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfirmationDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelText;
        private Views.PrimaryButton buttonConfirm;
        private Views.SecondaryButton buttonReturn;
    }
}