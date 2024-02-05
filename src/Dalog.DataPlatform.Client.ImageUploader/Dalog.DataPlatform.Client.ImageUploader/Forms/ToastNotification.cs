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
        /// <summary>
        /// Initializes a new instance of the <see cref="ToastNotification"/> class.
        /// </summary>
        /// <param name="text">The initial text to display</param>
        public ToastNotification(string text = "")
        {
            InitializeComponent();
            this.ChangeMessage(text);
        }

        /// <summary>
        /// Changes the label message
        /// </summary>
        /// <param name="text">The text to display.</param>
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