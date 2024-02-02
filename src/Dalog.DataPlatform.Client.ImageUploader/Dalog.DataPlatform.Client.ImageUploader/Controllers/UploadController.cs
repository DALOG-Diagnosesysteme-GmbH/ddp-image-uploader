﻿// -----------------------------------------------------------------------
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
        /// <summary>
        /// The Http repository
        /// </summary>
        private readonly HttpRepository _httpRepository;

        /// <summary>
        /// The HTTP settings.
        /// </summary>
        private readonly UploadSettings _uploadSettings;

        /// <summary>
        /// The upload form view.
        /// </summary>
        private readonly UploadForm _view;

        /// <summary>
        /// The cancellation token source.
        /// </summary>
        private CancellationTokenSource? _cts;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadController"/> class.
        /// </summary>
        public UploadController(HttpRepository httpRepository, UploadSettings httpSettings)
        {
            ArgumentNullException.ThrowIfNull(httpRepository, nameof(httpRepository));
            ArgumentNullException.ThrowIfNull(httpSettings, nameof(httpSettings));
            this._httpRepository = httpRepository;
            this._uploadSettings = httpSettings;
            this._view = new UploadForm();
            this.SubscribeEvents();
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        public UploadForm View => this._view;

        /// <summary>
        /// Disposes all resources.
        /// </summary>
        public void Dispose()
        {
            this.UnsubscribeEvents();
            this._cts?.Dispose();
            this._view?.Dispose();
        }

        /// <summary>
        /// Subscribes to the view's events.
        /// </summary>
        public void SubscribeEvents()
        {
            this._view.Shown += FormShown;
            this._view.FormClosing += FormClosing;
        }

        /// <summary>
        /// Unsubscribes from all view's events.
        /// </summary>
        public void UnsubscribeEvents()
        {
            this._view.FormClosing -= FormClosing;
            this._view.Shown -= FormShown;
        }

        /// <summary>
        /// Uploads all files.
        /// </summary>
        /// <returns>The task.</returns>
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

        /// <summary>
        /// Method called when the view is closing.
        /// </summary>
        /// <param name="sender">the sender object</param>
        /// <param name="e">The form closing event args.</param>
        private void FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (this._cts != null && !this._cts.IsCancellationRequested)
            {
                this._cts.Cancel();
            }

            this.Dispose();
        }

        /// <summary>
        /// Method called when the form is shown the first time.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args.</param>
        private async void FormShown(object? sender, EventArgs e)
        {
            this._view.UseWaitCursor = true;
            await this.UploadAllFiles();
            this._view.UseWaitCursor = false;
        }
    }
}