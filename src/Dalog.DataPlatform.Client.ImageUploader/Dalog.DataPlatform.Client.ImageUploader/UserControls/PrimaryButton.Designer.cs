namespace Dalog.DataPlatform.Client.ImageUploader.Views
{
    partial class PrimaryButton
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
            buttonPrimary = new Button();
            SuspendLayout();
            // 
            // buttonPrimary
            // 
            buttonPrimary.AutoSize = true;
            buttonPrimary.BackColor = Color.FromArgb(44, 83, 160);
            buttonPrimary.Dock = DockStyle.Fill;
            buttonPrimary.FlatAppearance.BorderColor = Color.FromArgb(16, 110, 190);
            buttonPrimary.FlatAppearance.BorderSize = 0;
            buttonPrimary.FlatAppearance.MouseDownBackColor = Color.FromArgb(235, 63, 61);
            buttonPrimary.FlatAppearance.MouseOverBackColor = Color.FromArgb(16, 110, 190);
            buttonPrimary.FlatStyle = FlatStyle.Flat;
            buttonPrimary.Font = new Font("Segoe UI", 10F);
            buttonPrimary.ForeColor = Color.White;
            buttonPrimary.Location = new Point(0, 0);
            buttonPrimary.Margin = new Padding(0);
            buttonPrimary.Name = "buttonPrimary";
            buttonPrimary.Size = new Size(82, 32);
            buttonPrimary.TabIndex = 0;
            buttonPrimary.Text = "button1";
            buttonPrimary.UseVisualStyleBackColor = false;
            buttonPrimary.Click += ButtonPrimaryClick;
            buttonPrimary.KeyUp += ButtonPrimary_KeyUp;
            // 
            // PrimaryButton
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Transparent;
            Controls.Add(buttonPrimary);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(82, 32);
            Name = "PrimaryButton";
            Size = new Size(82, 32);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonPrimary;
    }
}
