// -----------------------------------------------------------------------
// <copyright file="PrimaryButton.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.ComponentModel;

namespace Dalog.DataPlatform.Client.ImageUploader.Views
{
    /// <summary>
    /// The primary button view class.
    /// </summary>
    public partial class PrimaryButton : UserControl
    {
        public PrimaryButton() => InitializeComponent();

        public event EventHandler<EventArgs>? OnButtonClick;

        [Description("The button displayed text."), Category("Appearance")]
        public string ButtonText
        {
            get { return this.buttonPrimary.Text; }
            set { this.buttonPrimary.Text = value; }
        }

        public void PerformClick()
        {
            if (this.buttonPrimary.InvokeRequired)
            {
                this.buttonPrimary.Invoke(new MethodInvoker(() => this.PerformClick()));
                return;
            }

            this.buttonPrimary.PerformClick();
        }

        private void ButtonPrimary_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            this.buttonPrimary.PerformClick();
        }

        private void ButtonPrimaryClick(object sender, EventArgs e)
        {
            OnButtonClick?.Invoke(sender, e);
        }
    }
}
