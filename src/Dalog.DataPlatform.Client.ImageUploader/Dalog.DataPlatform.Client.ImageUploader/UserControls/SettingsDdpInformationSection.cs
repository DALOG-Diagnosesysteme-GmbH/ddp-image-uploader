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
        public SettingsDdpInformationSection()
        {
            InitializeComponent();
        }

        public TextBox MachineId
        {
            get
            {
                return this.textBoxMachineId;
            }
        }

        public TextBox MachineNumber
        {
            get
            {
                return this.textBoxMachineNumber;
            }
        }
    }
}
