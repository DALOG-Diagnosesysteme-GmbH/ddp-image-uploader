// -----------------------------------------------------------------------
// <copyright file="MessageDialog.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.Media;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    /// <summary>
    /// The message dialog form class.
    /// </summary>
    public partial class MessageDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageDialog"/> class.
        /// </summary>
        /// <param name="icon">The message box icon</param>
        /// <param name="message">The message string.</param>
        public MessageDialog(MessageBoxIcon icon, string message)
        {
            InitializeComponent();
            this.Text = GetTitle(icon);
            this.messageIcon.BackgroundImage = GetImage(icon);
            this.labelMessage.Text = message;
            SystemSounds.Exclamation.Play();
        }

        /// <summary>
        /// Shows this dialog
        /// </summary>
        /// <param name="owner">The window owner</param>
        /// <param name="icon">The message box icon</param>
        /// <param name="message">The message</param>
        internal static void Show(IWin32Window owner, MessageBoxIcon icon, string message)
        {
            using var dialog = new MessageDialog(icon, message);
            dialog.ShowDialog(owner);
        }

        /// <summary>
        /// Gets an image from the selected message box icon
        /// </summary>
        /// <param name="icon">The message box icon.</param>
        /// <returns>The image.</returns>
        private static Image? GetImage(MessageBoxIcon icon) => icon switch
        {
            MessageBoxIcon.Information => Properties.Resources.info,
            MessageBoxIcon.Warning => Properties.Resources.warning,
            MessageBoxIcon.Error => Properties.Resources.error,
            _ => null,
        };

        /// <summary>
        /// Method called when the
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOk_OnButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Gets the dialog's title.
        /// </summary>
        /// <param name="icon">The message box icon</param>
        /// <returns>The title string.</returns>
        private string GetTitle(MessageBoxIcon icon) => icon switch
        {
            MessageBoxIcon.Information => "Information",
            MessageBoxIcon.Warning => "Warning",
            MessageBoxIcon.Error => "Error",
            _ => string.Empty,
        };
    }
}