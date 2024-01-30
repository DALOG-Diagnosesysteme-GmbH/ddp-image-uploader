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
        /// <summary>
        /// Data field of the default fore color.
        /// </summary>
        private Color _defaultForeColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondaryButton"/> class.
        /// </summary>
        public SecondaryButton()
        {
            InitializeComponent();
            this._defaultForeColor = this.buttonSecondary.ForeColor;
        }

        /// <summary>
        /// Gets and sets the button text.
        /// </summary>
        [Description("The button text"), Category("Appearance")]
        public string ButtonText
        {
            get { return this.buttonSecondary.Text; }
            set { this.buttonSecondary.Text = value; }
        }

        /// <summary>
        /// Method called when the mouse button is down.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event args.</param>
        private void ButtonSecondary_MouseDown(object sender, MouseEventArgs e)
        {
            this.buttonSecondary.ForeColor = Color.FromArgb(235, 63, 61);
        }

        /// <summary>
        /// Method called when the mouse pointer enters the button boundary
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event args.</param>
        private void ButtonSecondary_MouseEnter(object sender, EventArgs e)
        {
            this.buttonSecondary.ForeColor = Color.FromArgb(16, 110, 190);
        }

        /// <summary>
        /// Method called when the mouse pointer leaves the button boundary
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event args.</param>
        private void ButtonSecondary_MouseLeave(object sender, EventArgs e)
        {
            this.buttonSecondary.ForeColor = this._defaultForeColor;
        }

        /// <summary>
        /// Method called when the mouse button is up.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event args.</param>
        private void ButtonSecondary_MouseUp(object sender, MouseEventArgs e)
        {
            this.ButtonSecondary_MouseEnter(sender, e);
        }
    }
}