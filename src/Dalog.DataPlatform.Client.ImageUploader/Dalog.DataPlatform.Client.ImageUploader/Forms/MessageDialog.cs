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
        public MessageDialog(MessageBoxIcon icon, string message)
        {
            InitializeComponent();
            this.Text = GetTitle(icon);
            this.messageIcon.BackgroundImage = GetImage(icon);
            this.labelMessage.Text = message;
            SystemSounds.Exclamation.Play();
        }

        internal static void Show(Form owner, MessageBoxIcon icon, string message)
        {
            if (owner.InvokeRequired)
            {
                owner.Invoke(new MethodInvoker(() => Show(owner, icon, message)));
                return;
            }

            using var dialog = new MessageDialog(icon, message);
            dialog.ShowDialog(owner);
        }

        private static Image? GetImage(MessageBoxIcon icon) => icon switch
        {
            MessageBoxIcon.Information => Properties.Resources.info,
            MessageBoxIcon.Warning => Properties.Resources.warning,
            MessageBoxIcon.Error => Properties.Resources.error,
            _ => null,
        };

        private void ButtonOk_OnButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetTitle(MessageBoxIcon icon) => icon switch
        {
            MessageBoxIcon.Information => "Information",
            MessageBoxIcon.Warning => "Warning",
            MessageBoxIcon.Error => "Error",
            _ => string.Empty,
        };
    }
}
