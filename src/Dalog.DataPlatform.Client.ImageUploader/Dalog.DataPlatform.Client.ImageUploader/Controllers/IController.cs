// -----------------------------------------------------------------------
// <copyright file="IController.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Dalog.DataPlatform.Client.ImageUploader.Controllers
{
    /// <summary>
    /// The controller interface.
    /// </summary>
    /// <typeparam name="T">The form type</typeparam>
    public interface IController<T> : IDisposable where T : Form
    {
        /// <summary>
        /// The controller's view.
        /// </summary>
        public T View
        {
            get;
        }

        /// <summary>
        /// Subscribes to the view's events.
        /// </summary>
        public void SubscribeEvents();

        /// <summary>
        /// Unsubscribes from the view's events.
        /// </summary>
        public void UnsubscribeEvents();
    }
}