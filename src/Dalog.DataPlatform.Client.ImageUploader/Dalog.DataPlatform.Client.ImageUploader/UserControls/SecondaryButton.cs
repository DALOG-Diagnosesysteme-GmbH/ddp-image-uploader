// -----------------------------------------------------------------------
// <copyright file="SecondaryButton.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System.ComponentModel;

namespace Dalog.DataPlatform.Client.ImageUploader.Views
{
    /// <summary>
    /// The secondary button view class.
    /// </summary>
    public partial class SecondaryButton : UserControl
    {
        private readonly Color _defaultForeColor;

        public SecondaryButton()
        {
            InitializeComponent();
            this._defaultForeColor = this.buttonSecondary.ForeColor;
        }

        public event EventHandler<EventArgs>? OnButtonClick;

        [Description("The button text"), Category("Appearance")]
        public string ButtonText
        {
            get { return this.buttonSecondary.Text; }
            set { this.buttonSecondary.Text = value; }
        }

        private void ButtonSecondary_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            this.buttonSecondary.PerformClick();
        }

        private void ButtonSecondary_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonSecondary.ForeColor = Color.FromArgb(235, 63, 61);
            this.OnButtonClick?.Invoke(this, e);
        }

        private void ButtonSecondary_MouseEnter(object sender, EventArgs e)
        {
            this.buttonSecondary.ForeColor = Color.FromArgb(16, 110, 190);
        }

        private void ButtonSecondary_MouseLeave(object sender, EventArgs e)
        {
            this.buttonSecondary.ForeColor = this._defaultForeColor;
        }

        private void ButtonSecondary_MouseUp(object sender, MouseEventArgs e)
        {
            this.ButtonSecondary_MouseEnter(sender, e);
        }
    }
}
