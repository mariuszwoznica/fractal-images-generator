using System.Windows.Input;

namespace FractalImagesGenerator.WPF.Infrastructure;

public class RelayCommand(Action execute, Func<bool> canExecute = null) : ICommand
{
    private readonly Action _execute = execute;
    private readonly Func<bool> _canExecute = canExecute;

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

    public void Execute(object? parameter) => _execute();
}

public class AsyncRelayCommand<T>(Func<T, Task> execute, Func<T, bool> canExecute = null) : ICommand
{
    private readonly Func<T, Task> _execute = execute;
    private readonly Func<T, bool> _canExecute = canExecute;

    private bool _isExecuting;
    private EventHandler? _canExecuteChanged;

    public bool IsExecuting
    {
        get => _isExecuting;
        set
        {
            _isExecuting = value;
            _canExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object? parameter) => !_isExecuting && _canExecute.Invoke((T)parameter);

    public async void Execute(object? parameter) => await ExecuteAsync((T)parameter);

    public async Task ExecuteAsync(T parameter)
    {
        _isExecuting = true;
        await _execute(parameter);
        _isExecuting = false;
    }
}
