namespace Dalog.DataPlatform.Client.ImageUploader.Views
{
    partial class SettingsDdpInformationSection
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
            labelMachineId = new Label();
            labelMachineNumber = new Label();
            textBoxMachineId = new TextBox();
            textBoxMachineNumber = new TextBox();
            groupBoxContainer = new GroupBox();
            groupBoxContainer.SuspendLayout();
            SuspendLayout();
            // 
            // labelMachineId
            // 
            labelMachineId.AutoSize = true;
            labelMachineId.BackColor = Color.Transparent;
            labelMachineId.Font = new Font("Segoe UI", 10F);
            labelMachineId.ForeColor = Color.FromArgb(50, 49, 48);
            labelMachineId.Location = new Point(9, 27);
            labelMachineId.Margin = new Padding(2, 0, 2, 0);
            labelMachineId.Name = "labelMachineId";
            labelMachineId.Size = new Size(83, 19);
            labelMachineId.TabIndex = 0;
            labelMachineId.Text = "Machine ID ";
            // 
            // labelMachineNumber
            // 
            labelMachineNumber.AutoSize = true;
            labelMachineNumber.BackColor = Color.Transparent;
            labelMachineNumber.Font = new Font("Segoe UI", 10F);
            labelMachineNumber.ForeColor = Color.FromArgb(50, 49, 48);
            labelMachineNumber.Location = new Point(9, 60);
            labelMachineNumber.Margin = new Padding(2, 0, 2, 0);
            labelMachineNumber.Name = "labelMachineNumber";
            labelMachineNumber.Size = new Size(119, 19);
            labelMachineNumber.TabIndex = 1;
            labelMachineNumber.Text = "Machine Number ";
            // 
            // textBoxMachineId
            // 
            textBoxMachineId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMachineId.BorderStyle = BorderStyle.FixedSingle;
            textBoxMachineId.Font = new Font("Segoe UI", 10F);
            textBoxMachineId.ForeColor = Color.FromArgb(50, 49, 48);
            textBoxMachineId.Location = new Point(130, 24);
            textBoxMachineId.Margin = new Padding(2);
            textBoxMachineId.MaxLength = 32;
            textBoxMachineId.Name = "textBoxMachineId";
            textBoxMachineId.Size = new Size(242, 25);
            textBoxMachineId.TabIndex = 2;
            // 
            // textBoxMachineNumber
            // 
            textBoxMachineNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMachineNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxMachineNumber.Font = new Font("Segoe UI", 10F);
            textBoxMachineNumber.ForeColor = Color.FromArgb(50, 49, 48);
            textBoxMachineNumber.Location = new Point(130, 57);
            textBoxMachineNumber.Margin = new Padding(2);
            textBoxMachineNumber.MaxLength = 9;
            textBoxMachineNumber.Name = "textBoxMachineNumber";
            textBoxMachineNumber.Size = new Size(242, 25);
            textBoxMachineNumber.TabIndex = 3;
            // 
            // groupBoxContainer
            // 
            groupBoxContainer.Controls.Add(textBoxMachineNumber);
            groupBoxContainer.Controls.Add(textBoxMachineId);
            groupBoxContainer.Controls.Add(labelMachineId);
            groupBoxContainer.Controls.Add(labelMachineNumber);
            groupBoxContainer.Dock = DockStyle.Fill;
            groupBoxContainer.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            groupBoxContainer.Location = new Point(10, 5);
            groupBoxContainer.Name = "groupBoxContainer";
            groupBoxContainer.Size = new Size(384, 95);
            groupBoxContainer.TabIndex = 4;
            groupBoxContainer.TabStop = false;
            groupBoxContainer.Text = "Data Platform";
            // 
            // SettingsDdpInformationSection
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(groupBoxContainer);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(50, 49, 48);
            Name = "SettingsDdpInformationSection";
            Padding = new Padding(10, 5, 10, 5);
            Size = new Size(404, 105);
            groupBoxContainer.ResumeLayout(false);
            groupBoxContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelMachineId;
        private Label labelMachineNumber;
        private TextBox textBoxMachineId;
        private TextBox textBoxMachineNumber;
        private GroupBox groupBoxContainer;
    }
}
