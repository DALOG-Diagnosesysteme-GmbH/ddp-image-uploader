// -----------------------------------------------------------------------
// <copyright file="AuthSettings.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Dalog.DataPlatform.Client.ImageUploader.Schema
{
    /// <summary>
    /// The authentication settings class.
    /// </summary>
    public class AuthSettings
    {
        public string ClientId { get; set; } = string.Empty;
        public string RedirectUrl { get; set; } = string.Empty;
        public string B2CTenantName { get; set; } = string.Empty;
        public string B2CPolicyName { get; set; } = string.Empty;
    }
}