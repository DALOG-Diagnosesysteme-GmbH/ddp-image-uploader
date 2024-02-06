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
        public SettingsLocalInformationSection()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs>? OnSelectFolderButtonClick;

        public TextBox ImagesFolder
        {
            get
            {
                return this.textBoxImagesFolder;
            }
        }

        public ComboBox ImagesType
        {
            get
            {
                return this.comboBoxImagesType;
            }
        }

        private void ButtonSelectFolder_Click(object sender, EventArgs e)
        {
            this.OnSelectFolderButtonClick?.Invoke(sender, e);
        }
    }
}
