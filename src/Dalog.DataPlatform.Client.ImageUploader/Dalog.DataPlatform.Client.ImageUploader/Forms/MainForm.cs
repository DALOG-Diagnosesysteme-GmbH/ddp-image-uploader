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
        /// <summary>
        /// The command bar view
        /// </summary>
        private readonly SettingsCommandBar _commandBar;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets the auto upload numerical up down.
        /// </summary>
        internal NumericUpDown AutoUploadHours
        {
            get
            {
                return this.numAutoUploadHours;
            }
        }

        /// <summary>
        /// Gets the command bar
        /// </summary>
        internal SettingsCommandBar CommandBar
        {
            get
            {
                return this._commandBar;
            }
        }

        /// <summary>
        /// The DDP Information section view
        /// </summary>
        internal SettingsDdpInformationSection SectionDdpInformation { get; init; }

        /// <summary>
        /// The local information section view.
        /// </summary>
        internal SettingsLocalInformationSection SectionLocalInformation { get; init; }

        /// <summary>
        /// Gets the upload button.
        /// </summary>
        internal PrimaryButton UploadButton
        {
            get
            {
                return this.buttonUpload;
            }
        }

        /// <summary>
        /// Appends a control to this form.
        /// </summary>
        /// <param name="control">The user control to append.</param>
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

        /// <summary>
        /// Method called when the Expert Mode checked state has changed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args.</param>
        private void CheckBoxMode_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateView(this.checkBoxMode.Checked);
        }

        /// <summary>
        /// Method called when a key is up when the expert mode check box is focused.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The key event args</param>
        private void CheckBoxMode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            this.checkBoxMode.Checked = !this.checkBoxMode.Checked;
        }

        /// <summary>
        /// Method called when the help button is clicked.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void MainForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Process.Start("CMD.exe", $"/C start msedge \"https://github.com/DALOG-Diagnosesysteme-GmbH/ddp-image-uploader\"");
        }

        /// <summary>
        /// Removes a control from this form
        /// </summary>
        /// <param name="control">The control to remove.</param>
        private void RemoveSection(UserControl control)
        {
            if (!this.Controls.Contains(control))
            {
                return;
            }

            this.Controls.Remove(control);
            this.Height -= control.Height;
        }

        /// <summary>
        /// Updates the form's view.
        /// </summary>
        /// <param name="expertMode">Value determining whether the mode is expert or not</param>
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