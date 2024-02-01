// -----------------------------------------------------------------------
// <copyright file="CopyForm.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Data;

namespace Dalog.DataPlatform.Client.ImageUploader.Forms;

/// <summary>
/// The copy form class.
/// </summary>
public partial class UploadForm : Form
{
    /// <summary>
    /// The data table.
    /// </summary>
    private readonly DataTable _dataTable;

    /// <summary>
    /// Initializes a new instance of the <see cref="UploadForm"/> class.
    /// </summary>
    public UploadForm()
    {
        InitializeComponent();
        this._dataTable = new DataTable();
        InitializeDataTable();
    }

    /// <summary>
    /// Appends a result to the data table
    /// </summary>
    /// <param name="fileName">The file name</param>
    /// <param name="uploadSuccessful">Value determining whether the upload was successful</param>
    /// <param name="statusCode">The status code</param>
    /// <param name="statusText">The status text</param>
    internal void AppendResult(string fileName, bool uploadSuccessful, string statusCode, string statusText)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new MethodInvoker(() => this.AppendResult(fileName, uploadSuccessful, statusCode, statusText)));
            return;
        }

        this._dataTable.Rows.Add(uploadSuccessful, fileName, statusCode, statusText);
        this.progressBar.Value += 1;
    }

    /// <summary>
    /// Initializes the progress bar
    /// </summary>
    /// <param name="max">The maximum progress bar value</param>
    internal void InitializeProgressBar(int max)
    {
        if (this.progressBar.InvokeRequired)
        {
            this.progressBar.Invoke(new MethodInvoker(() => this.InitializeProgressBar(max)));
            return;
        }

        this.progressBar.Maximum = max;
        this.progressBar.Value = 0;
    }

    /// <summary>
    /// Sets the current file name
    /// </summary>
    /// <param name="fileName">The file name</param>
    internal void SetCurrentFileName(string fileName)
    {
        if (this.textBoxCurrentFile.InvokeRequired)
        {
            this.textBoxCurrentFile.Invoke(new MethodInvoker(() => this.SetCurrentFileName(fileName)));
            return;
        }

        this.textBoxCurrentFile.Text = fileName;
    }

    /// <summary>
    /// Initializes the data table.
    /// </summary>
    private void InitializeDataTable()
    {
        this._dataTable.Columns.Add("Success", typeof(bool));
        this._dataTable.Columns.Add("File Name", typeof(string));
        this._dataTable.Columns.Add("Response Code", typeof(string));
        this._dataTable.Columns.Add("Response Message", typeof(string));

        this.dataGridView.DataSource = this._dataTable;

        this.dataGridView.Columns.GetLastColumn(DataGridViewElementStates.None, DataGridViewElementStates.None).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    }
}