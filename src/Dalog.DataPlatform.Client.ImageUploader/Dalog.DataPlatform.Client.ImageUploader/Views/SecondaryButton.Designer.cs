namespace Dalog.DataPlatform.Client.ImageUploader.Views
{
    partial class SecondaryButton
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
            buttonSecondary = new Button();
            SuspendLayout();
            // 
            // buttonSecondary
            // 
            buttonSecondary.AutoSize = true;
            buttonSecondary.BackColor = Color.White;
            buttonSecondary.Dock = DockStyle.Fill;
            buttonSecondary.FlatAppearance.BorderColor = Color.White;
            buttonSecondary.FlatAppearance.BorderSize = 0;
            buttonSecondary.FlatAppearance.MouseDownBackColor = Color.FromArgb(237, 235, 233);
            buttonSecondary.FlatAppearance.MouseOverBackColor = Color.FromArgb(243, 242, 241);
            buttonSecondary.FlatStyle = FlatStyle.Flat;
            buttonSecondary.Font = new Font("Segoe UI", 10F);
            buttonSecondary.ForeColor = Color.FromArgb(50, 49, 48);
            buttonSecondary.Location = new Point(0, 0);
            buttonSecondary.Margin = new Padding(0);
            buttonSecondary.Name = "buttonSecondary";
            buttonSecondary.Size = new Size(92, 32);
            buttonSecondary.TabIndex = 1;
            buttonSecondary.Text = "button1";
            buttonSecondary.UseVisualStyleBackColor = false;
            buttonSecondary.MouseDown += ButtonSecondary_MouseDown;
            buttonSecondary.MouseEnter += ButtonSecondary_MouseEnter;
            buttonSecondary.MouseLeave += ButtonSecondary_MouseLeave;
            buttonSecondary.MouseUp += ButtonSecondary_MouseUp;
            // 
            // SecondaryButton
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Transparent;
            Controls.Add(buttonSecondary);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(92, 32);
            Name = "SecondaryButton";
            Size = new Size(92, 32);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSecondary;
    }
}
