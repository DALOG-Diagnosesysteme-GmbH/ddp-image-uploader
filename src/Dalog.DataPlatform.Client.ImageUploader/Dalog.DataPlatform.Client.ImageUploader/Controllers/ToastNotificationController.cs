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
        /// <summary>
        /// Gets the notification timeout (in milliseconds)
        /// </summary>
        private static readonly int _timeoutMilliseconds = 5000;

        /// <summary>
        /// The toast notification view.
        /// </summary>
        private readonly ToastNotification _view = new(text);

        /// <summary>
        /// Gets the controller's view.
        /// </summary>
        public ToastNotification View => this._view;

        /// <summary>
        /// Disposes all resources.
        /// </summary>
        public void Dispose()
        {
            this._view?.Dispose();
        }

        /// <summary>
        /// Subscribes to the view's events.
        /// </summary>
        public void SubscribeEvents()
        {
            // Nothing.
        }

        /// <summary>
        /// Unsubscribes from the view's events.
        /// </summary>
        public void UnsubscribeEvents()
        {
            // Nothing.
        }

        /// <summary>
        /// Shows a toast notification.
        /// </summary>
        /// <param name="parent">The form parent.</param>
        /// <param name="text">The notification text.</param>
        /// <param name="token">The cancellation token.</param>
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