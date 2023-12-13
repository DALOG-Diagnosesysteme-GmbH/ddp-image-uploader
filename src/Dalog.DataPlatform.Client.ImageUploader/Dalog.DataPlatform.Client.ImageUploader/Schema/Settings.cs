using Dalog.DataPlatform.Client.ImageUploader.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dalog.DataPlatform.Client.ImageUploader.Schema
{
    internal class Settings : INotifyPropertyChanged
    {
        private string? _baseUrl;
        private string? _apiKey;
        private string? _folder;
        private string? _machineId;
        private string? _dalogId;
        private bool _disableSslChecks;
        private ImageType _imageType;
        private bool _useProxy;
        private string? _proxyAddress;
        private bool _proxyUseDefaultCredentials;
        private string? _proxyCredentialsUsername;
        private string? _proxyCredentialsPassword;
        private int _timeout;

        public event PropertyChangedEventHandler? PropertyChanged;

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
            ImageType = ImageType.Default;
            ProxyAddress = string.Empty;
            ProxyUseDefaultCredentials = true;
            ProxyCredentialsUsername = string.Empty;
            ProxyCredentialsPassword = string.Empty;
            Timeout = 30;
        }

        public HttpClient GetHttpClient()
        {
            var handler = new HttpClientHandler();
            if (DisableSslChecks)
            {
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => { return true; };
            }
            if (UseProxy)
            {
                handler.UseProxy = UseProxy;
                handler.Proxy = new WebProxy
                {
                    Address = new Uri(ProxyAddress ?? string.Empty),
                    UseDefaultCredentials = ProxyUseDefaultCredentials,
                    Credentials = new NetworkCredential(ProxyCredentialsUsername, ProxyCredentialsPassword)
                };
            }

            var result = new HttpClient(handler);
            result.BaseAddress = new Uri(SanitizeBaseUrl(BaseUrl ?? string.Empty));
            result.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ApiKey);
            result.Timeout = TimeSpan.FromSeconds(Timeout);

            return result;
        }

        protected void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged is not null) PropertyChanged(this, e);
        }

        private static string SanitizeBaseUrl(string baseUrl)
        {
            if (baseUrl.EndsWith("/")) { return baseUrl.Substring(0, baseUrl.Length - 1); };

            return baseUrl;
        }
    }
}
