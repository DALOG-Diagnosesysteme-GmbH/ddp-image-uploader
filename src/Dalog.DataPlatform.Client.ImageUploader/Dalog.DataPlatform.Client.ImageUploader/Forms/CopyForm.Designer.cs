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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            groupBoxProgress.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxProgress.Location = new Point(12, 12);
            groupBoxProgress.Name = "groupBoxProgress";
            groupBoxProgress.Size = new Size(776, 426);
            groupBoxProgress.TabIndex = 0;
            groupBoxProgress.TabStop = false;
            groupBoxProgress.Text = "Progress";
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.Location = new Point(6, 80);
            dataGridView.Name = "dataGridView";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.Size = new Size(764, 340);
            dataGridView.TabIndex = 3;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(6, 51);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(764, 23);
            progressBar.TabIndex = 2;
            // 
            // textBoxCurrentFile
            // 
            textBoxCurrentFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCurrentFile.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCurrentFile.Location = new Point(169, 22);
            textBoxCurrentFile.Name = "textBoxCurrentFile";
            textBoxCurrentFile.ReadOnly = true;
            textBoxCurrentFile.Size = new Size(601, 23);
            textBoxCurrentFile.TabIndex = 1;
            // 
            // labelCurrentFile
            // 
            labelCurrentFile.AutoSize = true;
            labelCurrentFile.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentFile.Location = new Point(6, 25);
            labelCurrentFile.Name = "labelCurrentFile";
            labelCurrentFile.Size = new Size(69, 15);
            labelCurrentFile.TabIndex = 0;
            labelCurrentFile.Text = "Current file:";
            // 
            // CopyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxProgress);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CopyForm";
            StartPosition = FormStartPosition.CenterScreen;
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