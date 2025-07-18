namespace NotepadDarkMode.ViewModels;

public class MainVM : ViewModelBase
{
    public TextStateVM TextStateVM { get; }

    public MainVM()
    {
        TextStateVM = new TextStateVM();
    }
}
