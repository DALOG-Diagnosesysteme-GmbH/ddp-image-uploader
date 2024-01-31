// -----------------------------------------------------------------------
// <copyright file="CopyForm.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Data;
using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Dalog.DataPlatform.Client.ImageUploader.Schema;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms;

/// <summary>
/// The copy form class.
/// </summary>
public partial class CopyForm : Form
{
    /// <summary>
    /// The data table.
    /// </summary>
    private readonly DataTable _dataTable;

    /// <summary>
    /// The HTTP repository
    /// </summary>
    private readonly HttpRepository _httpRepository;

    /// <summary>
    /// The settings object.
    /// </summary>
    private readonly HttpSettings _settings;

    /// <summary>
    /// Initializes a new instance of the <see cref="CopyForm"/> class.
    /// </summary>
    public CopyForm()
    {
        InitializeComponent();

        _settings = new HttpSettings();
        _dataTable = new DataTable();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CopyForm"/> class.
    /// </summary>
    /// <param name="settings"></param>
    internal CopyForm(HttpRepository repository, HttpSettings settings)
    {
        InitializeComponent();
        ArgumentNullException.ThrowIfNull(repository, nameof(repository));
        ArgumentNullException.ThrowIfNull(settings, nameof(settings));
        this._httpRepository = repository;
        this._settings = settings;
        this._dataTable = new DataTable();
    }

    /// <summary>
    /// Method called when the copy form is loading
    /// </summary>
    /// <param name="sender">The sender object</param>
    /// <param name="e">The event args.</param>
    private async void CopyForm_Load(object sender, EventArgs e)
    {
        InitializeDataTable();

        var files = Directory.GetFiles(_settings.Folder ?? string.Empty);
        this.progressBar.Maximum = files.Length;
        this.progressBar.Value = 0;
        using var httpClient = new HttpClient();
        foreach (var file in files)
        {
            this.textBoxCurrentFile.Text = file;
            using (var formData = new MultipartFormDataContent())
            {
                var fileBytes = await File.ReadAllBytesAsync(file);
                var fileContent = new ByteArrayContent(fileBytes);
                formData.Add(fileContent, "file", fileName: Path.GetFileNameWithoutExtension(file!));
                if (!string.IsNullOrWhiteSpace(this._settings.MachineId))
                {
                    formData.Add(new StringContent(this._settings.MachineId), name: "machineId");
                }
                if (!string.IsNullOrWhiteSpace(this._settings.DalogId))
                {
                    formData.Add(new StringContent(this._settings.DalogId), name: "dalogId");
                }

                var response = await httpClient.PostAsync(HttpSettings.GetPathFromImageType(this._settings.ImageType), formData);
                var responseContentAsString = await response.Content.ReadAsStringAsync();
                this._dataTable.Rows.Add(response.IsSuccessStatusCode, file, response.StatusCode.ToString(), responseContentAsString);
            }

            this.progressBar.Value += 1;
        }
    }

    /// <summary>
    /// Initializes the data table.
    /// </summary>
    private void InitializeDataTable()
    {
        this._dataTable.Columns.Add("Success", typeof(bool));
        this._dataTable.Columns.Add("File", typeof(string));
        this._dataTable.Columns.Add("Response Code", typeof(string));
        this._dataTable.Columns.Add("Response message", typeof(string));

        this.dataGridView.DataSource = this._dataTable;
    }
}