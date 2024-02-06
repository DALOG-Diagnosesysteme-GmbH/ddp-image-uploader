// -----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Diagnostics;
using Dalog.DataPlatform.Client.ImageUploader.Views;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    /// <summary>
    /// The main form.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly SettingsCommandBar _commandBar;

        public MainForm()
        {
            InitializeComponent();
            this._commandBar = new SettingsCommandBar
            {
                TabIndex = 1
            };
            this.SectionLocalInformation = new SettingsLocalInformationSection
            {
                TabIndex = 2
            };
            this.SectionDdpInformation = new SettingsDdpInformationSection
            {
                TabIndex = 3
            };

            this.CheckBoxMode_CheckedChanged(this, EventArgs.Empty);
        }

        internal NumericUpDown AutoUploadHours
        {
            get
            {
                return this.numAutoUploadHours;
            }
        }

        internal SettingsCommandBar CommandBar
        {
            get
            {
                return this._commandBar;
            }
        }

        internal SettingsDdpInformationSection SectionDdpInformation { get; init; }

        internal SettingsLocalInformationSection SectionLocalInformation { get; init; }

        internal PrimaryButton UploadButton
        {
            get
            {
                return this.buttonUpload;
            }
        }

        private void AppendSection(UserControl control)
        {
            if (this.Controls.Contains(control))
            {
                return;
            }

            this.Controls.Add(control);
            this.Controls.SetChildIndex(control, 0);
            control.Dock = DockStyle.Top;
            control.BackColor = Color.Transparent;
            this.Height += control.Height;
        }

        private void CheckBoxMode_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateView(this.checkBoxMode.Checked);
        }

        private void CheckBoxMode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            this.checkBoxMode.Checked = !this.checkBoxMode.Checked;
        }

        private void MainForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Process.Start("CMD.exe", $"/C start msedge \"https://github.com/DALOG-Diagnosesysteme-GmbH/ddp-image-uploader\"");
        }

        private void RemoveSection(UserControl control)
        {
            if (!this.Controls.Contains(control))
            {
                return;
            }

            this.Controls.Remove(control);
            this.Height -= control.Height;
        }

        private void UpdateView(bool expertMode)
        {
            this.SuspendLayout();
            if (!expertMode)
            {
                this.RemoveSection(this._commandBar);
                this.RemoveSection(this.SectionDdpInformation);
                this.AppendSection(this.SectionLocalInformation);
            }
            else
            {
                this.RemoveSection(this.SectionLocalInformation);
                this.AppendSection(this._commandBar);
                this.AppendSection(this.SectionLocalInformation);
                this.AppendSection(this.SectionDdpInformation);
            }

            this.ResumeLayout();
        }
    }
}
