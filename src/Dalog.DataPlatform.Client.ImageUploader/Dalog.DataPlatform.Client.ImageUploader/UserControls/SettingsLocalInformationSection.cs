// -----------------------------------------------------------------------
// <copyright file="SettingsLocalInformationSection.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Dalog.DataPlatform.Client.ImageUploader.Views
{
    /// <summary>
    /// The settings local information view class.
    /// </summary>
    public partial class SettingsLocalInformationSection : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsLocalInformationSection"/> class.
        /// </summary>
        public SettingsLocalInformationSection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event triggered when the select folder button is clicked
        /// </summary>
        public event EventHandler<EventArgs>? OnSelectFolderButtonClick;

        /// <summary>
        /// Gets the images folder text box.
        /// </summary>
        public TextBox ImagesFolder
        {
            get
            {
                return this.textBoxImagesFolder;
            }
        }

        /// <summary>
        /// Gets the images type combo box.
        /// </summary>
        public ComboBox ImagesType
        {
            get
            {
                return this.comboBoxImagesType;
            }
        }

        /// <summary>
        /// Method called when the select folder button is clicked.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args.</param>
        private void ButtonSelectFolder_Click(object sender, EventArgs e)
        {
            this.OnSelectFolderButtonClick?.Invoke(sender, e);
        }
    }
}