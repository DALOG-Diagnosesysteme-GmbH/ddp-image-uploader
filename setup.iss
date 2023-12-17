[Setup]
AppName=DALOG Image Uploader
AppVersion=0.0.1
DefaultDirName={autopf}\dalog-image-uploader
DefaultGroupName=DALOG
OutputDir=.\Output
OutputBaseFilename=YourAppName_Setup
Compression=lzma
SolidCompression=yes
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64

[Files]
Source: "path\to\your\build\output\*"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion

[Icons]
Name: "{group}\YourAppName"; Filename: "{app}\YourAppName.exe"

[Run]
Filename: "{app}\YourAppName.exe"; Description: "Launch YourAppName"; Flags: nowait postinstall skipifsilent
