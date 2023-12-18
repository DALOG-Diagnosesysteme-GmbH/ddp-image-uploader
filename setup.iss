[Setup]
AppName=DALOG Image Uploader
AppVersion=x.x.x
WizardStyle=modern
DefaultDirName={autopf}\dalog-image-uploader
DefaultGroupName=DALOG
OutputDir=.\Output
OutputBaseFilename=Dalog.DataPlatform.Client.ImageUploader_Setup
Compression=lzma
SolidCompression=yes
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64
SetupIconFile=output\logo.ico

[Files]
Source: "output\*"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion

[Icons]
Name: "{group}\DALOG Image Uploader"; Filename: "{app}\Dalog.DataPlatform.Client.ImageUploader.exe"

[Run]
Filename: "{app}\Dalog.DataPlatform.Client.ImageUploader.exe"; Description: "Launch DALOG Image Uploader"; Flags: nowait postinstall skipifsilent
