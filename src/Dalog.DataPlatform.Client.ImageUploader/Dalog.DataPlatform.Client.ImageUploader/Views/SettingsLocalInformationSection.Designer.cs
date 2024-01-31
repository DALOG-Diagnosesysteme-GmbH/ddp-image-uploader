namespace Dalog.DataPlatform.Client.ImageUploader.Views
{
    partial class SettingsLocalInformationSection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsLocalInformationSection));
            labelImagesFolder = new Label();
            labelImagesType = new Label();
            textBoxImagesFolder = new TextBox();
            comboBoxImagesType = new ComboBox();
            groupBoxContainer = new GroupBox();
            buttonSelectFolder = new Button();
            groupBoxContainer.SuspendLayout();
            SuspendLayout();
            // 
            // labelImagesFolder
            // 
            labelImagesFolder.AutoSize = true;
            labelImagesFolder.BackColor = Color.Transparent;
            labelImagesFolder.Font = new Font("Segoe UI", 10F);
            labelImagesFolder.ForeColor = Color.FromArgb(50, 49, 48);
            labelImagesFolder.Location = new Point(9, 26);
            labelImagesFolder.Margin = new Padding(2, 0, 2, 0);
            labelImagesFolder.Name = "labelImagesFolder";
            labelImagesFolder.Size = new Size(105, 19);
            labelImagesFolder.TabIndex = 2;
            labelImagesFolder.Text = "Images Folder *";
            // 
            // labelImagesType
            // 
            labelImagesType.AutoSize = true;
            labelImagesType.BackColor = Color.Transparent;
            labelImagesType.Font = new Font("Segoe UI", 10F);
            labelImagesType.ForeColor = Color.FromArgb(50, 49, 48);
            labelImagesType.Location = new Point(9, 59);
            labelImagesType.Margin = new Padding(2, 0, 2, 0);
            labelImagesType.Name = "labelImagesType";
            labelImagesType.Size = new Size(85, 19);
            labelImagesType.TabIndex = 3;
            labelImagesType.Text = "Images Type";
            // 
            // textBoxImagesFolder
            // 
            textBoxImagesFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxImagesFolder.Font = new Font("Segoe UI", 10F);
            textBoxImagesFolder.ForeColor = Color.FromArgb(50, 49, 48);
            textBoxImagesFolder.Location = new Point(130, 24);
            textBoxImagesFolder.Margin = new Padding(2);
            textBoxImagesFolder.MaxLength = 9999;
            textBoxImagesFolder.Name = "textBoxImagesFolder";
            textBoxImagesFolder.Size = new Size(212, 25);
            textBoxImagesFolder.TabIndex = 1;
            // 
            // comboBoxImagesType
            // 
            comboBoxImagesType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxImagesType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxImagesType.Font = new Font("Segoe UI", 10F);
            comboBoxImagesType.ForeColor = Color.FromArgb(50, 49, 48);
            comboBoxImagesType.FormattingEnabled = true;
            comboBoxImagesType.Location = new Point(130, 56);
            comboBoxImagesType.Name = "comboBoxImagesType";
            comboBoxImagesType.Size = new Size(242, 25);
            comboBoxImagesType.TabIndex = 2;
            // 
            // groupBoxContainer
            // 
            groupBoxContainer.Controls.Add(buttonSelectFolder);
            groupBoxContainer.Controls.Add(comboBoxImagesType);
            groupBoxContainer.Controls.Add(textBoxImagesFolder);
            groupBoxContainer.Controls.Add(labelImagesFolder);
            groupBoxContainer.Controls.Add(labelImagesType);
            groupBoxContainer.Dock = DockStyle.Fill;
            groupBoxContainer.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxContainer.Location = new Point(10, 5);
            groupBoxContainer.Name = "groupBoxContainer";
            groupBoxContainer.Size = new Size(384, 95);
            groupBoxContainer.TabIndex = 6;
            groupBoxContainer.TabStop = false;
            groupBoxContainer.Text = "Local Folder Information";
            // 
            // buttonSelectFolder
            // 
            buttonSelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSelectFolder.BackColor = Color.White;
            buttonSelectFolder.BackgroundImage = (Image)resources.GetObject("buttonSelectFolder.BackgroundImage");
            buttonSelectFolder.BackgroundImageLayout = ImageLayout.Zoom;
            buttonSelectFolder.FlatAppearance.BorderColor = Color.White;
            buttonSelectFolder.FlatAppearance.BorderSize = 0;
            buttonSelectFolder.FlatAppearance.MouseDownBackColor = Color.FromArgb(237, 235, 233);
            buttonSelectFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(243, 242, 241);
            buttonSelectFolder.FlatStyle = FlatStyle.Flat;
            buttonSelectFolder.Location = new Point(347, 24);
            buttonSelectFolder.Name = "buttonSelectFolder";
            buttonSelectFolder.Size = new Size(25, 25);
            buttonSelectFolder.TabIndex = 4;
            buttonSelectFolder.UseVisualStyleBackColor = false;
            buttonSelectFolder.Click += ButtonSelectFolder_Click;
            // 
            // SettingsLocalInformationSection
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(groupBoxContainer);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(50, 49, 48);
            Name = "SettingsLocalInformationSection";
            Padding = new Padding(10, 5, 10, 5);
            Size = new Size(404, 105);
            groupBoxContainer.ResumeLayout(false);
            groupBoxContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelImagesFolder;
        private Label labelImagesType;
        private TextBox textBoxImagesFolder;
        private ComboBox comboBoxImagesType;
        private GroupBox groupBoxContainer;
        private Button buttonSelectFolder;
    }
}
