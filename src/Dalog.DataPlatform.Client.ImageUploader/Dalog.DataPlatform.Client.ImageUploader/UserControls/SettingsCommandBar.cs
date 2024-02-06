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
        public SettingsCommandBar() => InitializeComponent();

        public event EventHandler<EventArgs>? OnButtonNetworkSettingsClick;

        public event EventHandler<EventArgs>? OnButtonResetSettingsClick;

        public event EventHandler<EventArgs>? OnButtonTestConnectionClick;

        private void ButtonNetworkSettings_Click(object sender, EventArgs e)
        {
            this.OnButtonNetworkSettingsClick?.Invoke(sender, e);
        }

        private void ButtonResetSettings_Click(object sender, EventArgs e)
        {
            this.OnButtonResetSettingsClick?.Invoke(sender, e);
        }

        private void ButtonTestConnection_Click(object sender, EventArgs e)
        {
            this.OnButtonTestConnectionClick?.Invoke(sender, e);
        }
    }
}
