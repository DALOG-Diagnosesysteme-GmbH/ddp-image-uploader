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
        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryButton"/> class.
        /// </summary>
        public PrimaryButton() => InitializeComponent();

        /// <summary>
        /// Gets the on button click event handler.
        /// </summary>
        public event EventHandler<EventArgs>? OnButtonClick;

        /// <summary>
        /// Gets and sets the button text.
        /// </summary>
        [Description("The button text"), Category("Appearance")]
        public string ButtonText
        {
            get { return this.buttonPrimary.Text; }
            set { this.buttonPrimary.Text = value; }
        }

        /// <summary>
        /// Method called when the primary button is clicked
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonPrimaryClick(object sender, EventArgs e)
        {
            OnButtonClick?.Invoke(sender, e);
        }
    }
}