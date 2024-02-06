// -----------------------------------------------------------------------
// <copyright file="ToastNotificationController.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Media;
using Dalog.DataPlatform.Client.ImageUploader.Forms;

namespace Dalog.DataPlatform.Client.ImageUploader.Controllers
{
    /// <summary>
    /// The toast notification controller class.
    /// </summary>
    internal sealed class ToastNotificationController(string text) : IController<ToastNotification>
    {
        private static readonly int _timeoutMilliseconds = 5000;

        private readonly ToastNotification _view = new(text);

        public ToastNotification View => this._view;

        public void Dispose()
        {
            this._view?.Dispose();
        }

        public void SubscribeEvents()
        {
            // Nothing.
        }

        public void UnsubscribeEvents()
        {
            // Nothing.
        }

        internal static async void Show(Form parent, string text)
        {
            if (parent.InvokeRequired)
            {
                parent.Invoke(new MethodInvoker(() => Show(parent, text)));
                return;
            }

            using var dialog = new ToastNotification(text);
            dialog.Location = new Point((Screen.PrimaryScreen!.WorkingArea.Width - dialog.Width) / 2, 15);
            SystemSounds.Hand.Play();
            dialog.Show();
            await Task.Delay(_timeoutMilliseconds);
        }
    }
}
