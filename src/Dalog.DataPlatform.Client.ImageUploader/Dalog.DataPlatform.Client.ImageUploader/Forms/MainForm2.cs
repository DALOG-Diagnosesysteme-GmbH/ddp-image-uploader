// -----------------------------------------------------------------------
// <copyright file="MainForm2.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Dalog.DataPlatform.Client.ImageUploader.Views;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    /// <summary>
    /// The main form.
    /// </summary>
    public partial class MainForm2 : Form
    {
        /// <summary>
        /// The command bar view
        /// </summary>
        private readonly SettingsCommandBar _commandBar;

        /// <summary>
        /// The DDP Information section view
        /// </summary>
        private readonly SettingsDdpInformationSection _ddpInformationSection;

        /// <summary>
        /// The local information section view.
        /// </summary>
        private readonly SettingsLocalInformationSection _localInformationSection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm2"/> class.
        /// </summary>
        public MainForm2()
        {
            InitializeComponent();
            this._commandBar = new SettingsCommandBar();
            this._ddpInformationSection = new SettingsDdpInformationSection();
            this._localInformationSection = new SettingsLocalInformationSection();
            this.CheckBoxMode_CheckedChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Appends a control to this form.
        /// </summary>
        /// <param name="control">The user control to append.</param>
        private void AppendControl(UserControl control)
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
        /// Removes a control from this form
        /// </summary>
        /// <param name="control">The control to remove.</param>
        private void RemoveControl(UserControl control)
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
                this.RemoveControl(this._commandBar);
                this.RemoveControl(this._ddpInformationSection);
                this.AppendControl(this._localInformationSection);
            }
            else
            {
                this.RemoveControl(this._localInformationSection);
                this.AppendControl(this._commandBar);
                this.AppendControl(this._localInformationSection);
                this.AppendControl(this._ddpInformationSection);
            }

            this.ResumeLayout();
        }
    }
}