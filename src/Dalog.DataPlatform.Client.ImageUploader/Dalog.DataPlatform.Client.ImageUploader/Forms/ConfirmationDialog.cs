// -----------------------------------------------------------------------
// <copyright file="ConfirmationDialog.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    /// <summary>
    /// The confirmation dialog form.
    /// </summary>
    public partial class ConfirmationDialog : Form
    {
        public ConfirmationDialog(string text)
        {
            InitializeComponent();
            this.labelText.Text = text;
        }

        private void ButtonConfirm_OnButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void ButtonReturn_OnButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
