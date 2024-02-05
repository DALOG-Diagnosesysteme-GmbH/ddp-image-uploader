// -----------------------------------------------------------------------
// <copyright file="Worker.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Dalog.DataPlatform.Client.ImageUploader.Controllers;
using Dalog.DataPlatform.Client.ImageUploader.Forms;
using Dalog.DataPlatform.Client.ImageUploader.Repositories;
using Dalog.DataPlatform.Client.ImageUploader.Schema;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dalog.DataPlatform.Client.ImageUploader.Services
{
    /// <summary>
    /// The worker service class.
    /// </summary>
    internal sealed class Worker : BackgroundService
    {
        /// <summary>
        /// The HTTP repository
        /// </summary>
        private readonly HttpRepository _httpRepository;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<Worker> _logger;

        /// <summary>
        /// The main controller.
        /// </summary>
        private readonly MainController _mainController;

        /// <summary>
        /// The next tasks due datetime.
        /// </summary>
        private DateTime _nextDue;

        /// <summary>
        /// The tasks time interval.
        /// </summary>
        private TimeSpan _taskInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="Worker"/> class.
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="appsettings">The application settings</param>
        /// <param name="mainController">The main controller</param>
        /// <param name="httpRepository">The HTTP repository</param>
        public Worker(ILogger<Worker> logger, IOptions<AppSettings> appsettings, IController<MainForm> mainController, HttpRepository httpRepository)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(appsettings, nameof(appsettings));
            ArgumentNullException.ThrowIfNull(mainController, nameof(mainController));
            ArgumentNullException.ThrowIfNull(httpRepository, nameof(httpRepository));
            this._logger = logger;
            this._httpRepository = httpRepository;
            this._mainController = (MainController)mainController;
            this._mainController.OnAutoUploadHoursChanged += MainController_OnAutoUploadHoursChanged;
            //this._taskInterval = TimeSpan.FromSeconds(10);
            this._taskInterval = TimeSpan.FromHours(appsettings.Value?.AutoUploadIntervalHours ?? 1);
            this._nextDue = DateTime.Now + this._taskInterval;
        }

        /// <summary>
        /// Disposes all resources
        /// </summary>
        public override void Dispose()
        {
            this._mainController.OnAutoUploadHoursChanged -= MainController_OnAutoUploadHoursChanged;
            base.Dispose();
        }

        /// <summary>
        /// Executes the service asynchronously.
        /// </summary>
        /// <param name="stoppingToken">The stopping token</param>
        /// <returns>The task.</returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                this._logger.LogInformation("{name} service successfully started.", nameof(Worker));
                while (!stoppingToken.IsCancellationRequested)
                {
                    // Uploads the images.
                    if (DateTime.Now > this._nextDue)
                    {
                        ToastNotificationController.Show(this._mainController.View, $"The upload task is running now in background.");

                        await this.UploadImagesAsync(stoppingToken);
                        this._nextDue = DateTime.Now + this._taskInterval;
                        this._logger.LogInformation("Next automatic upload due on {time}", this._nextDue);

                        ToastNotificationController.Show(this._mainController.View, $"All images were successfully processed. Next automatic upload on {this._nextDue.ToLocalTime()}");
                    }

                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogCritical(ex, "Exception '{Source}' thrown: {Message}.", ex.Source, ex.Message);
                this._logger.LogCritical("Stopping service...");
            }
        }

        /// <summary>
        /// Method called when the auto upload interval value changes.
        /// </summary>
        /// <param name="hours">The new interval in hours</param>
        private void MainController_OnAutoUploadHoursChanged(int hours)
        {
            if (hours <= 0)
            {
                return;
            }

            this._taskInterval = TimeSpan.FromHours(hours);
            this._nextDue = DateTime.Now + this._taskInterval;
            ToastNotificationController.Show(this._mainController.View, $"The next upload task will be performed at {this._nextDue.ToLocalTime()}");
        }

        /// <summary>
        /// Uploads images asynchronously
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The task.</returns>
        private async Task UploadImagesAsync(CancellationToken token)
        {
            var settings = new UploadSettings();
            settings.Initialize();

            this._logger.LogInformation("Starting uploading process for the images within the folder path '{Folder}'...", settings.Folder);
            try
            {
                var directoryInfo = new DirectoryInfo(settings.Folder!);
                if (!directoryInfo.Exists)
                {
                    this._logger.LogError("The folder path '{Folder}' does not exist or its access is restricted", settings.Folder);
                    return;
                }

                var files = directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    await this._httpRepository.UploadImageAsync(settings, file, token).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception '{Source}' thrown: {Message}", ex.Source, ex.Message);
            }
        }
    }
}