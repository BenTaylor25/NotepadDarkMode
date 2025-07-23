cd ..\NotepadDarkMode
dotnet clean
dotnet build --configuration Release

cd ..\NotepadDarkMode.Installer
dotnet clean
dotnet build --configuration Release

mkdir MSIOutput
copy bin\Release\NotepadDarkMode.msi MSIOutput
