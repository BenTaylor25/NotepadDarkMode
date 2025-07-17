namespace NotepadDarkMode.ViewModels;

public class TextStateVM : ViewModelBase
{
    private string _textEditorText = "hello";
    public string TextEditorText
    {
        get => _textEditorText;
        set
        {
            _textEditorText = value;
            OnPropertyChanged();
        }
    }
}
