; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Remote Desktop Manager"
#define MyAppVersion "v0.5.2"
#define MyAppPublisher "KRtkovo.eu design studio"
#define MyAppURL "http://github.com/KRtkovo-eu/rdman"
#define MyAppExeName "rdman.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{E9C41DBB-22B8-4AB8-96B3-0AB9F1180236}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=C:\git\rdman\LICENSE
OutputDir=C:\git\rdman\rdman\publish
OutputBaseFilename=Remote Desktop Manager v0.5.2 setup
SetupIconFile=C:\git\rdman\rdman\icons\unknown.ico
Compression=lzma
SolidCompression=yes
ChangesAssociations=yes
AppCopyright=GNU General Public License v3.0
ShowLanguageDialog=no
CloseApplicationsFilter=*.exe
CreateUninstallRegKey=yes
UninstallDisplayName=Remote Desktop Manager
AppModifyPath={app}
UninstallDisplayIcon={app}\rdman.exe
VersionInfoVersion=0.5.2
VersionInfoCompany=KRtkovo.eu design studio
VersionInfoTextVersion=v0.5.2
VersionInfoCopyright=GNU General Public License v3.0
VersionInfoProductName=Remote Desktop Manager
VersionInfoProductVersion=0.5.2
VersionInfoProductTextVersion=v0.5.2
ArchitecturesInstallIn64BitMode=x64
ArchitecturesAllowed=x86 x64
WizardImageFile=C:\git\rdman\installerBig.bmp
WizardSmallImageFile=C:\git\rdman\installerSmall.bmp

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\git\rdman\rdman\publish\Remote Desktop Manager\rdman.exe"; DestDir: "{app}"; Flags: ignoreversion; Components: RDMan
Source: "C:\git\rdman\rdman\publish\Remote Desktop Manager\rdman.application"; DestDir: "{app}"; Flags: ignoreversion; Components: RDMan
Source: "C:\git\rdman\rdman\publish\Remote Desktop Manager\rdman.exe"; DestDir: "{app}"; Flags: ignoreversion; Components: RDMan
Source: "C:\git\rdman\rdman\publish\Remote Desktop Manager\rdman.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion; Components: RDMan
Source: "C:\git\rdman\rdman\publish\Remote Desktop Manager\sources.rdman"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist; Components: RDMan
Source: "C:\git\rdman\rdman\publish\Remote Desktop Manager\LICENSE"; DestDir: "{app}"; Flags: ignoreversion; Components: RDMan
Source: "C:\git\rdman\rdman\publish\Remote Desktop Manager\asciiGraphics\*"; DestDir: "{app}\asciiGraphics"; Flags: ignoreversion recursesubdirs createallsubdirs; Components: RDMan
Source: "C:\git\rdman\rdman\publish\Remote Desktop Manager\icons\*"; DestDir: "{app}\icons"; Flags: ignoreversion recursesubdirs createallsubdirs; Components: RDMan
Source: "C:\git\rdman\rdman\publish\Remote Desktop Manager\csved\*"; DestDir: "{app}\csved"; Flags: ignoreversion recursesubdirs createallsubdirs; Components: CSVed
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:ProgramOnTheWeb,{#MyAppName}}"; Filename: "{#MyAppURL}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Registry]
Root: HKCR; Subkey: ".rdman"; ValueType: string; ValueName: ""; ValueData: "rdman_database_file"; Flags: uninsdeletevalue 
Root: HKCR; Subkey: "rdman_database_file"; ValueType: string; ValueName: ""; ValueData: "Remote Desktop Manager database"; Flags: uninsdeletekey 
Root: HKCR; Subkey: "rdman_database_file\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\icons\code.ico" 
Root: HKCR; Subkey: "rdman_database_file\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\rdman.exe"" ""%1""" 

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Components]
Name: "CSVed"; Description: "CSVed module for editing database"; Types: custom full
Name: "RDMan"; Description: "Remote Desktop Manager"; Types: full custom compact; Flags: checkablealone fixed

[Types]
Name: "full"; Description: "Install Remote Desktop Manager with CSVed for editing database file."
Name: "custom"; Description: "Install Remote Desktop Manager and optionally CSVed."; Flags: iscustom
Name: "compact"; Description: "Install only Remote Desktop Manager."
