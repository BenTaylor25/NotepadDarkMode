
The WiX Toolkit allows you to package applications as installers.

Make sure you have the WiX Toolkit.
```bat
dotnet install --global wix
```

From the project root:
```bat
mkdir NotepadDarkMode.Installer
cd NotepadDarkMode.Installer

.> NotepadDarkMode.wixproj
.> Pacakge.wxs

ECHO bin/>.gitignore
ECHO obj/>>.gitignore
```

Paste the following into `NotepadDarkMode.wixproj`:
```xml
<Project Sdk="WixToolset.Sdk/6.0.1">
</Project>
```

and the following into `Package.wxs`:
```xml
<Wix xmlns="http://wixtoolset.org/schemas/v4/wxs">
    <Package
        Id="BenTaylor.NotepadDarkMode"
        Name="Notepad Dark Mode"
        Manufacturer="BenTaylor25"
        Version="0.0.1"
    >
        <File
            Source="../NotepadDarkMode/bin/Release/net8.0-windows/NotepadDarkMode.deps.json"
        />
        <File
            Source="../NotepadDarkMode/bin/Release/net8.0-windows/NotepadDarkMode.exe"
        />
        <File
            Source="../NotepadDarkMode/bin/Release/net8.0-windows/NotepadDarkMode.dll"
        />
        <File
            Source="../NotepadDarkMode/bin/Release/net8.0-windows/NotepadDarkMode.pdb"
        />
        <File
            Source="../NotepadDarkMode/bin/Release/net8.0-windows/NotepadDarkMode.runtimeconfig.json"
        />
    </Package>
</Wix>
```

```bat
dotnet build
```

_If this fails, make sure you have a release build of NotepadDarkMode:_
```bat
cd ..\NotepadDarkMode

dotnet build --configuration Release

cd ..\NotepadDarkMode.Installer
dotnet build
```

You should find the MSI file under
`NotepadDarkMode.Installer/Debug/NotepadDarkMode.msi`.

## Known Issues
- Program does not appear on start menu once installed.
- No installation confirmation.
