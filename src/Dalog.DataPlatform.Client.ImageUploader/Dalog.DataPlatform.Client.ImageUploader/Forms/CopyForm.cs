using Dalog.DataPlatform.Client.ImageUploader.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    public partial class CopyForm : Form
    {
        private readonly Settings _settings;
        private readonly DataTable _dataTable;

        public CopyForm()
        {
            InitializeComponent();

            _settings = new Settings();
            _dataTable = new DataTable();
        }

        internal CopyForm(Settings settings)
        {
            InitializeComponent();

            _settings = settings;
            _dataTable = new DataTable();
        }

        private async void CopyForm_Load(object sender, EventArgs e)
        {
            InitializeDataTable();

            var files = Directory.GetFiles(_settings.Folder ?? string.Empty);
            progressBar.Maximum = files.Length;
            progressBar.Value = 0;
            var httpClient = _settings.GetHttpClient();
            foreach (var file in files)
            {
                textBoxCurrentFile.Text = file;
                using (var formData = new MultipartFormDataContent())
                {
                    var fileBytes = await File.ReadAllBytesAsync(file);
                    var fileContent = new ByteArrayContent(fileBytes);
                    formData.Add(fileContent, "file", fileName: Path.GetFileNameWithoutExtension(file!));
                    if (!string.IsNullOrWhiteSpace(_settings.MachineId))
                    {
                        formData.Add(new StringContent(_settings.MachineId), name: "machineId");
                    }
                    if (!string.IsNullOrWhiteSpace(_settings.DalogId))
                    {
                        formData.Add(new StringContent(_settings.DalogId), name: "dalogId");
                    }

                    var response = await httpClient.PostAsync(Settings.GetPathFromImageType(_settings.ImageType), formData);
                    var responseContentAsString = await response.Content.ReadAsStringAsync();
                    _dataTable.Rows.Add(response.IsSuccessStatusCode, file, response.StatusCode.ToString(), responseContentAsString);
                }

                progressBar.Value += 1;
            }
        }

        private void InitializeDataTable()
        {
            _dataTable.Columns.Add("Success", typeof(bool));
            _dataTable.Columns.Add("File", typeof(string));
            _dataTable.Columns.Add("Response Code", typeof(string));
            _dataTable.Columns.Add("Response message", typeof(string));

            dataGridView.DataSource = _dataTable;
        }
    }
}
