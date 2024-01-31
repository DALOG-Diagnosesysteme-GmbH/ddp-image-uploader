// -----------------------------------------------------------------------
// <copyright file="AppSettings.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Dalog.DataPlatform.Client.ImageUploader.Schema
{
    /// <summary>
    /// The application settings class.
    /// </summary>
    public sealed class AppSettings()
    {
        /// <summary>
        /// Gets and sets the base URL
        /// </summary>
        public string BaseUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the Ping Url
        /// </summary>
        public string PingUrl { get; set; } = string.Empty;
    }
}