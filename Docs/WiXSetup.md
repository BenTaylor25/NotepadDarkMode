
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
        Compressed="yes"
    >

        <Media Id="1" Cabinet="media1.cab" EmbedCab="yes" />

        <StandardDirectory Id="ProgramFilesFolder">
            <Directory Id="INSTALLFOLDER" Name="NotepadDarkMode">
                <Component
                    Id="AppFiles"
                    Guid="2dba8a97-9de6-40be-9ed5-d9163a43db9b"
                >
                    <File
                        Source="../NotepadDarkMode/bin/Release/net8.0-windows/NotepadDarkMode.exe"
                        Id="MainExe"
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
                    <File
                        Source="../NotepadDarkMode/bin/Release/net8.0-windows/NotepadDarkMode.deps.json"
                    />
                </Component>
            </Directory>
        </StandardDirectory>

        <StandardDirectory Id="ProgramMenuFolder">
            <Directory
                Id="ApplicationProgramsFolder"
                Name="Notepad Dark Mode"
            >
                <Component
                    Id="StartMenuShortcut"
                    Guid="ea493183-f1f6-4836-9e77-15cd402bcfce"
                >

                    <Shortcut
                        Id="StartMenuShortcut"
                        Name="Notepad Dark Mode"
                        Target="[INSTALLFOLDER]NotepadDarkMode.exe"
                        WorkingDirectory="INSTALLFOLDER"
                        />

                    <RemoveFolder
                        Id="RemoveShortcutFolder"
                        On="uninstall"
                    />

                    <RegistryValue
                        Root="HKCU"
                        Key="Software\NotepadDarkMode"
                        Name="installed"
                        Type="integer"
                        Value="1"
                        KeyPath="yes"
                    />

                </Component>
            </Directory>
        </StandardDirectory>

        <Feature
            Id="ProductFeature"
            Title="Notepad Dark Mode"
            Level="1"
        >
            <ComponentRef Id="AppFiles" />
            <ComponentRef Id="StartMenuShortcut" />
        </Feature>

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
