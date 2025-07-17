using System.Windows.Input;

using NotepadDarkMode.Commands;

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

    public ICommand UpdateTempCommand { get; }
    private void UpdateTemp()
    {
        TempProperty = "Clicked at " + DateTime.Now.ToLongTimeString();
    }

    public MainVM()
    {
        UpdateTempCommand = new RelayCommand(_ => UpdateTemp());
    }
}
