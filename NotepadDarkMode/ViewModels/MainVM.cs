using NotepadDarkMode.ViewModels;

namespace NotepadDarkMode.ViewModels;

public class MainVM : ViewModelBase
{
    private string _tempProperty = "temp";
    public string TempProperty
    {
        get => _tempProperty;
        set
        {
            _tempProperty = value;
            OnPropertyChanged();
        }
    }
}