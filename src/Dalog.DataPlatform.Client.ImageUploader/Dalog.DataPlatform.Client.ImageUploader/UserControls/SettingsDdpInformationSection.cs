// -----------------------------------------------------------------------
// <copyright file="SettingsDdpInformationSection.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Dalog.DataPlatform.Client.ImageUploader.Views
{
    /// <summary>
    /// The settings DDP information view class.
    /// </summary>
    public partial class SettingsDdpInformationSection : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsDdpInformationSection"/> class.
        /// </summary>
        public SettingsDdpInformationSection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the machine Id text box
        /// </summary>
        public TextBox MachineId
        {
            get
            {
                return this.textBoxMachineId;
            }
        }

        /// <summary>
        /// Gets the machine number text box
        /// </summary>
        public TextBox MachineNumber
        {
            get
            {
                return this.textBoxMachineNumber;
            }
        }
    }
}