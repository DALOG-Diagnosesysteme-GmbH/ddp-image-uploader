// -----------------------------------------------------------------------
// <copyright file="UploadController.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using Dalog.DataPlatform.Client.ImageUploader.Forms;
using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Dalog.DataPlatform.Client.ImageUploader.Schema;

namespace Dalog.DataPlatform.Client.ImageUploader.Controllers
{
    /// <summary>
    /// The upload controller class.
    /// </summary>
    internal class UploadController : IController<UploadForm>
    {
        private readonly HttpRepository _httpRepository;

        private readonly UploadSettings _uploadSettings;

        private readonly UploadForm _view;

        private CancellationTokenSource? _cts;

        public UploadController(HttpRepository httpRepository, UploadSettings httpSettings)
        {
            ArgumentNullException.ThrowIfNull(httpRepository, nameof(httpRepository));
            ArgumentNullException.ThrowIfNull(httpSettings, nameof(httpSettings));
            this._httpRepository = httpRepository;
            this._uploadSettings = httpSettings;
            this._view = new UploadForm();
            this.SubscribeEvents();
        }

        public UploadForm View => this._view;

        public void Dispose()
        {
            this.UnsubscribeEvents();
            this._cts?.Dispose();
            this._view?.Dispose();
        }

        public void SubscribeEvents()
        {
            this._view.Shown += FormShown;
            this._view.FormClosing += FormClosing;
        }

        public void UnsubscribeEvents()
        {
            this._view.FormClosing -= FormClosing;
            this._view.Shown -= FormShown;
        }

        public async Task UploadAllFiles()
        {
            if (!this._uploadSettings.SettingsAreValid(out var errors))
            {
                MessageDialog.Show(this._view, MessageBoxIcon.Error, errors);
                return;
            }

            var folderInfo = new DirectoryInfo(this._uploadSettings.Folder!);
            var files = folderInfo.EnumerateFiles("*", SearchOption.AllDirectories);
            if (!files.Any())
            {
                MessageDialog.Show(this._view, MessageBoxIcon.Information, $"No images found in '{folderInfo.FullName}'.");
                return;
            }

            // Uploads the images.
            this._cts = new CancellationTokenSource();
            this._view.InitializeProgressBar(files.Count());
            foreach (var file in files)
            {
                if (this._cts.IsCancellationRequested)
                {
                    return;
                }

                this._view.SetCurrentFileName(file.Name);
                var response = await this._httpRepository.UploadImageAsync(this._uploadSettings, file, this._cts.Token);
                var responseContentAsString = await response.Content.ReadAsStringAsync();
                this._view.AppendResult(file.Name, response.IsSuccessStatusCode, response.StatusCode.ToString(), responseContentAsString);
            }

            this._view.SetCurrentFileName(string.Empty);
            MessageDialog.Show(this._view, MessageBoxIcon.Information, "All images were successfully processed.");
            this._cts.Dispose();
            this._cts = null;
        }

        private void FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (this._cts != null && !this._cts.IsCancellationRequested)
            {
                this._cts.Cancel();
            }

            this.Dispose();
        }

        private async void FormShown(object? sender, EventArgs e)
        {
            this._view.UseWaitCursor = true;
            await this.UploadAllFiles();
            this._view.UseWaitCursor = false;
        }
    }
}
