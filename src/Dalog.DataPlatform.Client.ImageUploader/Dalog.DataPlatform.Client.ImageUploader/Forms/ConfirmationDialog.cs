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
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationDialog"/> class.
        /// </summary>
        /// <param name="text">The confirmation text.</param>
        public ConfirmationDialog(string text)
        {
            InitializeComponent();
            this.labelText.Text = text;
        }

        /// <summary>
        /// Method called when the confirm button is clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args.</param>
        private void ButtonConfirm_OnButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// Method called when the return button is clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args.</param>
        private void ButtonReturn_OnButtonClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}