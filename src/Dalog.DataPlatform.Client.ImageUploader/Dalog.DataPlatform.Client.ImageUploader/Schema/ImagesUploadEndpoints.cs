// -----------------------------------------------------------------------
// <copyright file="ImagesUploadEndpoints.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Dalog.DataPlatform.Client.ImageUploader.Schema
{
    /// <summary>
    /// The images upload endpoints class.
    /// </summary>
    public sealed class ImagesUploadEndpoints
    {
        /// <summary>
        /// Gets and sets the BusyBee images endpoint
        /// </summary>
        public string BusyBee { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the default images endpoint.
        /// </summary>
        public string Default { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the FLS images endpoint.
        /// </summary>
        public string FLS { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the GZip images endpoint
        /// </summary>
        public string GZip { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the wireless endpoint.
        /// </summary>
        public string Wireless { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the Zip endpoint.
        /// </summary>
        public string Zip { get; set; } = string.Empty;
    }
}