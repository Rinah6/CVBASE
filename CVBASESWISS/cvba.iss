; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "CVBase"
#define MyAppVersion "1.0"
#define MyAppPublisher "SOFTWELL"
#define MyAppExeName "CVBASESWISS.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{F4BF459A-C4BA-4764-9DBB-684BF11A65BC}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\SoftwellINFO\Desktop
OutputBaseFilename=mysetup
SetupIconFile=C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\LOGOICO.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\CVBASESWISS.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\CVBASESWISS.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\CVBASESWISS.vshost.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\CVBASESWISS.vshost.exe.Config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\CVBASESWISS.vshost.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\EntityFramework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\EntityFramework.SqlServer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\EntityFramework.SqlServer.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\EntityFramework.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\SoftwellINFO\Desktop\SWISS\CVBASESWISS\CVBASESWISS\bin\x86\Release\test.txt"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

