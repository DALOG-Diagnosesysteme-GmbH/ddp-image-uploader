// -----------------------------------------------------------------------
// <copyright file="SettingsCommandBar.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Dalog.DataPlatform.Client.ImageUploader.Views
{
    /// <summary>
    /// The settings command bar view class.
    /// </summary>
    public partial class SettingsCommandBar : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsCommandBar"/> class.
        /// </summary>
        public SettingsCommandBar() => InitializeComponent();

        /// <summary>
        /// Data field of the network settings button click event handler.
        /// </summary>
        public event EventHandler<EventArgs>? OnButtonNetworkSettingsClick;

        /// <summary>
        /// Data field of the reset settings button click event handler.
        /// </summary>
        public event EventHandler<EventArgs>? OnButtonResetSettingsClick;

        /// <summary>
        /// Data field of the test connection button click event handler.
        /// </summary>
        public event EventHandler<EventArgs>? OnButtonTestConnectionClick;

        /// <summary>
        /// Method called when the network settings button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args.</param>
        private void ButtonNetworkSettings_Click(object sender, EventArgs e)
        {
            this.OnButtonNetworkSettingsClick?.Invoke(sender, e);
        }

        /// <summary>
        /// Method called when the reset settings button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args.</param>
        private void ButtonResetSettings_Click(object sender, EventArgs e)
        {
            this.OnButtonResetSettingsClick?.Invoke(sender, e);
        }

        /// <summary>
        /// Method called when the test connection button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args.</param>
        private void ButtonTestConnection_Click(object sender, EventArgs e)
        {
            this.OnButtonTestConnectionClick?.Invoke(sender, e);
        }
    }
}