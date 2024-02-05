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
        /// <summary>
        /// Gets and sets the client Id.
        /// </summary>
        public string ClientId { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the redirect URL
        /// </summary>
        public string RedirectUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the tenant Id.
        /// </summary>
        public string TenantId { get; set; } = string.Empty;
    }
}