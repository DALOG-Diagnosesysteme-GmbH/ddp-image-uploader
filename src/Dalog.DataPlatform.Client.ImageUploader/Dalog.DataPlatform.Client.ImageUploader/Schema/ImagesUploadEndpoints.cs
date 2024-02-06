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
        public string BusyBee { get; set; } = string.Empty;

        public string Default { get; set; } = string.Empty;

        public string FLS { get; set; } = string.Empty;

        public string GZip { get; set; } = string.Empty;

        public string Wireless { get; set; } = string.Empty;

        public string Zip { get; set; } = string.Empty;
    }
}
