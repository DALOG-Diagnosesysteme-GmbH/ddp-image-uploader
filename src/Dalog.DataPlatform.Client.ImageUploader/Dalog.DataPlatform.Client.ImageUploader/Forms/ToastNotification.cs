// -----------------------------------------------------------------------
// <copyright file="ToastNotification.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    /// <summary>
    /// The toast notification form.
    /// </summary>
    public partial class ToastNotification : Form
    {
        public ToastNotification(string text = "")
        {
            InitializeComponent();
            this.ChangeMessage(text);
        }

        internal void ChangeMessage(string text)
        {
            if (this.labelNotification.InvokeRequired)
            {
                this.labelNotification.Invoke(new MethodInvoker(() => this.ChangeMessage(text)));
                return;
            }

            this.labelNotification.Text = text;
        }
    }
}
