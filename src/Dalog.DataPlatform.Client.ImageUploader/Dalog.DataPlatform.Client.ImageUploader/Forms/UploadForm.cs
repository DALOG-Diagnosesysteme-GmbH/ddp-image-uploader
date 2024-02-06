// -----------------------------------------------------------------------
// <copyright file="UploadForm.cs" company="DALOG Diagnosesysteme GmbH">
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
    private readonly DataTable _dataTable;

    public UploadForm()
    {
        InitializeComponent();
        this._dataTable = new DataTable();
        InitializeDataTable();
    }

    internal void AppendResult(string fileName, bool uploadSuccessful, string statusCode, string statusText)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new MethodInvoker(() => this.AppendResult(fileName, uploadSuccessful, statusCode, statusText)));
            return;
        }

        this._dataTable.Rows.Add(uploadSuccessful, fileName, statusCode, statusText);
        this.progressBar.Value += 1;
        this.UpdateIndicatorText();
    }

    internal void InitializeProgressBar(int max)
    {
        if (this.progressBar.InvokeRequired)
        {
            this.progressBar.Invoke(new MethodInvoker(() => this.InitializeProgressBar(max)));
            return;
        }

        this.progressBar.Maximum = max;
        this.progressBar.Value = 0;
        this.UpdateIndicatorText();
    }

    internal void SetCurrentFileName(string fileName)
    {
        if (this.textBoxCurrentFile.InvokeRequired)
        {
            this.textBoxCurrentFile.Invoke(new MethodInvoker(() => this.SetCurrentFileName(fileName)));
            return;
        }

        this.textBoxCurrentFile.Text = fileName;
    }

    private void InitializeDataTable()
    {
        this._dataTable.Columns.Add("Success", typeof(bool));
        this._dataTable.Columns.Add("File Name", typeof(string));
        this._dataTable.Columns.Add("Response Code", typeof(string));
        this._dataTable.Columns.Add("Response Message", typeof(string));

        this.dataGridView.DataSource = this._dataTable;

        this.dataGridView.Columns.GetLastColumn(DataGridViewElementStates.None, DataGridViewElementStates.None).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    }

    private void UpdateIndicatorText()
    {
        if (this.labelBarIndicator.InvokeRequired)
        {
            this.labelBarIndicator.Invoke(new MethodInvoker(() => this.UpdateIndicatorText()));
            return;
        }

        this.labelBarIndicator.Text = $"Processed ({this.progressBar.Value}/{this.progressBar.Maximum}):";
    }
}
