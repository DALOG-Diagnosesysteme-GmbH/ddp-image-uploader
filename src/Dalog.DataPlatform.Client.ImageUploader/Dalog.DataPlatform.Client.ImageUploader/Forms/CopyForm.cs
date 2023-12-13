using Dalog.DataPlatform.Client.ImageUploader.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    public partial class CopyForm : Form
    {
        private readonly Settings _settings;

        public CopyForm()
        {
            InitializeComponent();

            _settings = new Settings();
        }

        internal CopyForm(Settings settings)
        {
            InitializeComponent();

            _settings = settings;
        }
    }
}
