// -----------------------------------------------------------------------
// <copyright file="HttpSettings.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Net;

namespace Dalog.DataPlatform.Client.ImageUploader.Schema
{
    /// <summary>
    /// The HTTP settings class.
    /// </summary>
    public class HttpSettings : INotifyPropertyChanged
    {
        private string? _apiKey;
        private string? _baseUrl;
        private string? _dalogId;
        private bool _disableSslChecks;
        private string? _folder;
        private ImageType _imageType;
        private string? _machineId;
        private string? _proxyAddress;
        private string? _proxyCredentialsPassword;
        private string? _proxyCredentialsUsername;
        private bool _proxyUseDefaultCredentials;
        private int _timeout;
        private bool _useProxy;

        public event PropertyChangedEventHandler? PropertyChanged;

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

        public string? BaseUrl
        {
            get { return _baseUrl; }
            set
            {
                _baseUrl = value;
                Forms.UserSettings.Default.BaseUrl = value;
                Forms.UserSettings.Default.Save();
                InvokePropertyChanged(new PropertyChangedEventArgs(nameof(BaseUrl)));
            }
        }

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

        public void Initialize()
        {
            BaseUrl = Forms.UserSettings.Default.BaseUrl;
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

        public void Reset()
        {
            BaseUrl = "https://api.dalog.net";
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

        internal static string GetPathFromImageType(ImageType type) => type switch
        {
            ImageType.Default => "/files/v1/images",
            ImageType.BusyBee => "/files/v1/images/busybee",
            ImageType.FLS => "/files/v1/images/fls",
            ImageType.GZip => "/files/v1/images/gzip",
            ImageType.Wireless => "/files/v1/images/wireless",
            ImageType.Zip => "/files/v1/images/zip",
            _ => throw new NotImplementedException(),
        };

        protected void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged is not null) PropertyChanged(this, e);
        }
    }
}