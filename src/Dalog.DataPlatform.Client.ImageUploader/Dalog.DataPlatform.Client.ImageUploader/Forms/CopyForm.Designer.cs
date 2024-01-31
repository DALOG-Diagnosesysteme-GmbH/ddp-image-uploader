namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    partial class CopyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyForm));
            groupBoxProgress = new GroupBox();
            dataGridView = new DataGridView();
            progressBar = new ProgressBar();
            textBoxCurrentFile = new TextBox();
            labelCurrentFile = new Label();
            groupBoxProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBoxProgress
            // 
            groupBoxProgress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxProgress.Controls.Add(dataGridView);
            groupBoxProgress.Controls.Add(progressBar);
            groupBoxProgress.Controls.Add(textBoxCurrentFile);
            groupBoxProgress.Controls.Add(labelCurrentFile);
            groupBoxProgress.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            groupBoxProgress.Location = new Point(12, 14);
            groupBoxProgress.Name = "groupBoxProgress";
            groupBoxProgress.Size = new Size(521, 374);
            groupBoxProgress.TabIndex = 0;
            groupBoxProgress.TabStop = false;
            groupBoxProgress.Text = "Progress";
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.Location = new Point(11, 91);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(501, 272);
            dataGridView.TabIndex = 3;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(11, 58);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(501, 26);
            progressBar.TabIndex = 2;
            // 
            // textBoxCurrentFile
            // 
            textBoxCurrentFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCurrentFile.Font = new Font("Segoe UI", 10F);
            textBoxCurrentFile.Location = new Point(108, 25);
            textBoxCurrentFile.Name = "textBoxCurrentFile";
            textBoxCurrentFile.ReadOnly = true;
            textBoxCurrentFile.Size = new Size(404, 25);
            textBoxCurrentFile.TabIndex = 1;
            // 
            // labelCurrentFile
            // 
            labelCurrentFile.AutoSize = true;
            labelCurrentFile.Font = new Font("Segoe UI", 10F);
            labelCurrentFile.Location = new Point(11, 28);
            labelCurrentFile.Name = "labelCurrentFile";
            labelCurrentFile.Size = new Size(80, 19);
            labelCurrentFile.TabIndex = 0;
            labelCurrentFile.Text = "Current file:";
            // 
            // CopyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(545, 401);
            Controls.Add(groupBoxProgress);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(43, 42, 41);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CopyForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "DALOG Image Uploader";
            Load += CopyForm_Load;
            groupBoxProgress.ResumeLayout(false);
            groupBoxProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxProgress;
        private ProgressBar progressBar;
        private TextBox textBoxCurrentFile;
        private Label labelCurrentFile;
        private DataGridView dataGridView;
    }
}