using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dalog.DataPlatform.Client.ImageUploader.ExtensionMethods;
using Dalog.DataPlatform.Client.ImageUploader.Views;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    public partial class MainForm2 : Form
    {
        private readonly SettingsCommandBar _commandBar;

        private readonly SettingsDdpInformationSection _ddpInformationSection;

        private readonly SettingsLocalInformationSection _localInformationSection;

        public MainForm2()
        {
            InitializeComponent();
            this._commandBar = new SettingsCommandBar();
            this._ddpInformationSection = new SettingsDdpInformationSection();
            this._localInformationSection = new SettingsLocalInformationSection();
            this.CheckBoxMode_CheckedChanged(this, EventArgs.Empty);
        }

        private void AppendItem(UserControl control)
        {
            if (this.Controls.Contains(control))
            {
                return;
            }

            this.Controls.Add(control);
            this.Controls.SetChildIndex(control, 0);
            control.Dock = DockStyle.Top;
            control.BackColor = Color.Transparent;
            this.Height += control.Height;
        }

        private void CheckBoxMode_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateView(this.checkBoxMode.Checked);
        }

        private void RemoveItem(UserControl control)
        {
            if (!this.Controls.Contains(control))
            {
                return;
            }

            this.Controls.Remove(control);
            this.Height -= control.Height;
        }

        private void UpdateView(bool expertMode)
        {
            this.SuspendLayout();
            if (!expertMode)
            {
                this.RemoveItem(this._commandBar);
                this.RemoveItem(this._ddpInformationSection);
                this.AppendItem(this._localInformationSection);
            }
            else
            {
                this.RemoveItem(this._localInformationSection);
                this.AppendItem(this._commandBar);
                this.AppendItem(this._localInformationSection);
                this.AppendItem(this._ddpInformationSection);
            }

            this.ResumeLayout();
        }
    }
}