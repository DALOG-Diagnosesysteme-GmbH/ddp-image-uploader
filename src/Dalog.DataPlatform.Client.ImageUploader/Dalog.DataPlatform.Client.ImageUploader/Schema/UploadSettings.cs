// -----------------------------------------------------------------------
// <copyright file="UploadSettings.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Text;

namespace Dalog.DataPlatform.Client.ImageUploader.Schema
{
    /// <summary>
    /// The upload settings class.
    /// </summary>
    public class UploadSettings : INotifyPropertyChanged
    {
        /// <summary>
        /// The API key
        /// </summary>
        private string? _apiKey;

        /// <summary>
        /// The machine number (dalog Id)
        /// </summary>
        private string? _dalogId;

        /// <summary>
        /// Value determining whether to disable the SSL checks or not.
        /// </summary>
        private bool _disableSslChecks;

        /// <summary>
        /// The folder path.
        /// </summary>
        private string? _folder;

        /// <summary>
        /// The images type to process.
        /// </summary>
        private ImageType _imageType;

        /// <summary>
        /// The machine DDP ID
        /// </summary>
        private string? _machineId;

        /// <summary>
        /// The proxy address
        /// </summary>
        private string? _proxyAddress;

        /// <summary>
        /// The proxy user password.
        /// </summary>
        private string? _proxyCredentialsPassword;

        /// <summary>
        /// The proxy username
        /// </summary>
        private string? _proxyCredentialsUsername;

        /// <summary>
        /// Value determining whether to use the default proxy credentials or not.
        /// </summary>
        private bool _proxyUseDefaultCredentials;

        /// <summary>
        /// Sets the timeout in seconds.
        /// </summary>
        private int _timeout;

        /// <summary>
        /// Value determining whether a proxy must be used or not.
        /// </summary>
        private bool _useProxy;

        /// <summary>
        /// Event handler triggered when a property value has changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets and sets the API key.
        /// </summary>
        public string? ApiKey
        {
            get { return _apiKey; }
            set
            {
                _apiKey = value;
                Forms.UserSettings.Default.ApiKey = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(ApiKey)));
            }
        }

        /// <summary>
        /// Gets and sets the machine number (Dalog ID)
        /// </summary>
        public string? DalogId
        {
            get { return _dalogId; }
            set
            {
                _dalogId = value;
                Forms.UserSettings.Default.DalogId = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(DalogId)));
            }
        }

        /// <summary>
        /// Gets and sets a value determining whether to disable the SSL checks or not.
        /// </summary>
        public bool DisableSslChecks
        {
            get { return _disableSslChecks; }
            set
            {
                _disableSslChecks = value;
                Forms.UserSettings.Default.DisableSslChecks = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(DisableSslChecks)));
            }
        }

        /// <summary>
        /// Gets and sets the folder path.
        /// </summary>
        public string? Folder
        {
            get { return _folder; }
            set
            {
                _folder = value;
                Forms.UserSettings.Default.Folder = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(Folder)));
            }
        }

        /// <summary>
        /// Gets and sets the image type.
        /// </summary>
        public ImageType ImageType
        {
            get { return _imageType; }
            set
            {
                _imageType = value;
                Forms.UserSettings.Default.ImageType = value.ToString();
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(ImageType)));
            }
        }

        /// <summary>
        /// Gets and sets the DDP machine Id
        /// </summary>
        public string? MachineId
        {
            get { return _machineId; }
            set
            {
                _machineId = value;
                Forms.UserSettings.Default.MachineId = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(MachineId)));
            }
        }

        /// <summary>
        /// Gets and sets the proxy address
        /// </summary>
        public string? ProxyAddress
        {
            get { return _proxyAddress; }
            set
            {
                _proxyAddress = value;
                Forms.UserSettings.Default.ProxyAddress = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(ProxyAddress)));
            }
        }

        /// <summary>
        /// Gets and sets the proxy username
        /// </summary>
        public string? ProxyCredentialsPassword
        {
            get { return _proxyCredentialsPassword; }
            set
            {
                _proxyCredentialsPassword = value;
                Forms.UserSettings.Default.ProxyCredentialsPassword = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(ProxyCredentialsPassword)));
            }
        }

        /// <summary>
        /// Gets and sets the proxy user password
        /// </summary>
        public string? ProxyCredentialsUsername
        {
            get { return _proxyCredentialsUsername; }
            set
            {
                _proxyCredentialsUsername = value;
                Forms.UserSettings.Default.ProxyCredentialsUsername = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(ProxyCredentialsUsername)));
            }
        }

        /// <summary>
        /// Gets and sets a value determining whether to use the proxy default credentials or not.
        /// </summary>
        public bool ProxyUseDefaultCredentials
        {
            get { return _proxyUseDefaultCredentials; }
            set
            {
                _proxyUseDefaultCredentials = value;
                Forms.UserSettings.Default.ProxyUseDefaultCredentials = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(ProxyUseDefaultCredentials)));
            }
        }

        /// <summary>
        /// Gets and sets the timeout in seconds.
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }
            set
            {
                _timeout = value;
                Forms.UserSettings.Default.Timeout = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(Timeout)));
            }
        }

        /// <summary>
        /// Gets or sets a value determining whether a proxy must be used or not.
        /// </summary>
        public bool UseProxy
        {
            get { return _useProxy; }
            set
            {
                _useProxy = value;
                Forms.UserSettings.Default.UseProxy = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(UseProxy)));
            }
        }

        /// <summary>
        /// Initializes the settings.
        /// </summary>
        public void Initialize()
        {
            ApiKey = Forms.UserSettings.Default.ApiKey;
            Folder = Forms.UserSettings.Default.Folder;
            MachineId = Forms.UserSettings.Default.MachineId;
            DalogId = Forms.UserSettings.Default.DalogId;
            DisableSslChecks = Forms.UserSettings.Default.DisableSslChecks;
            UseProxy = Forms.UserSettings.Default.UseProxy;
            ImageType = Enum.Parse<ImageType>(Forms.UserSettings.Default.ImageType);
            ProxyAddress = Forms.UserSettings.Default.ProxyAddress;
            ProxyUseDefaultCredentials = Forms.UserSettings.Default.ProxyUseDefaultCredentials;
            ProxyCredentialsUsername = Forms.UserSettings.Default.ProxyCredentialsUsername;
            ProxyCredentialsPassword = Forms.UserSettings.Default.ProxyCredentialsPassword;
            Timeout = Forms.UserSettings.Default.Timeout;
        }

        /// <summary>
        /// Resets the settings.
        /// </summary>
        public void Reset()
        {
            ApiKey = string.Empty;
            Folder = string.Empty;
            MachineId = string.Empty;
            DalogId = string.Empty;
            DisableSslChecks = false;
            UseProxy = false;
            ImageType = ImageType.BusyBee;
            ProxyAddress = string.Empty;
            ProxyUseDefaultCredentials = true;
            ProxyCredentialsUsername = string.Empty;
            ProxyCredentialsPassword = string.Empty;
            Timeout = 30;
        }

        /// <summary>
        /// Gets a value determining whether the network settings values are valid or not.
        /// </summary>
        /// <param name="errors">The possible errors string if the network settings are not valid.</param>
        /// <returns>True if the settings are valid. Otherwise false</returns>
        internal bool NetworkSettingsAreValid(out string errors)
        {
            errors = string.Empty;
            if (!this.UseProxy)
            {
                return true;
            }

            var builder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(this.ProxyAddress))
            {
                builder.AppendLine("The proxy address is required.");
            }

            if (!this.ProxyUseDefaultCredentials)
            {
                if (string.IsNullOrWhiteSpace(this.ProxyCredentialsUsername) || string.IsNullOrWhiteSpace(this.ProxyCredentialsPassword))
                {
                    builder.AppendLine("The proxy Username and password are required.");
                }
            }

            errors = builder.ToString();
            return string.IsNullOrEmpty(errors);
        }

        /// <summary>
        /// Gets a value determining whether the settings values are valid or not.
        /// </summary>
        /// <param name="errors">The possible errors string if the settings are not valid.</param>
        /// <returns>True if the settings are valid. Otherwise false.</returns>
        internal bool SettingsAreValid(out string errors)
        {
            var builder = new StringBuilder();
            if (!this.NetworkSettingsAreValid(out var networkSettingsErrors))
            {
                builder.Append(networkSettingsErrors);
            }

            if (!Directory.Exists(this.Folder))
            {
                builder.AppendLine("The folder path is not valid.");
            }

            errors = builder.ToString();
            return string.IsNullOrEmpty(errors);
        }

        /// <summary>
        /// Method called when a property value has changed.
        /// </summary>
        /// <param name="e">The property changed event args.</param>
        protected void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged is not null) PropertyChanged(this, e);
        }
    }
}