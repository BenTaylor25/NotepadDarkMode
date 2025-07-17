using System.Windows.Input;

namespace NotepadDarkMode.Commands;

/// <summary>
/// I don't know if I actually need this but it's generally recommended,
/// so I'll keep it for now.
/// </summary>
public class RelayCommand(
    Action<object?> execute,
    Predicate<object?> canExecute
    ) : ICommand
{
    private readonly Action<object?> _execute = execute;
    private readonly Predicate<object?>? _canExecute = canExecute;

    public bool CanExecute(object? parameter) =>
        _canExecute?.Invoke(parameter) ?? true;

    public void Execute(object? parameter) => _execute(parameter);

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}
