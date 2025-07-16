
```bat
mkdir NotepadDarkMode
cd NotepadDarkMode

dotnet new wpf -n NotepadDarkMode

.>README.md

mkdir Docs
.>Docs\InitialSetup.md

git init
git add .
git commit -m "Project init"

git remote add origin https://github.com/BenTaylor25/NotepadDarkMode.git
git push origin master
```
