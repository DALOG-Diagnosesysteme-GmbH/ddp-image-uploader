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
        public int AutoUploadIntervalHours { get; set; } = 2;
        public string BaseUrl { get; set; } = string.Empty;
        public string PingUrl { get; set; } = string.Empty;
        public string SharedSubscriptionKeyValue { get; set; } = string.Empty;
        public string SharedSubscriptionKeyName {  get; set; } = string.Empty;
    }
}
