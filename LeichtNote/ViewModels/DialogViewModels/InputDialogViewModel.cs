using System;
using System.ComponentModel;
using System.Reactive;
using ReactiveUI;

namespace LeichtNote.ViewModels.DialogViewModels;

public class InputDialogViewModel : INotifyPropertyChanged
{
    public string Label { get; }
    public string ButtonText { get; }
    private string _input { get; set; }
    public string Input
    {
        get { return _input; }
        set
        {
            _input = value;
            OnPropertyChanged(Input);
            OnPropertyChanged(nameof(CanAcceptInput));
        }
    }
    public Func<string, bool>? ValidateInput { get; set; }
    public bool CanAcceptInput => (ValidateInput == null) || (ValidateInput != null && ValidateInput(Input));

    #region Commands
    public ReactiveCommand<Unit, string> AcceptAndCloseDialogCommand { get; }

    #endregion
    
    public InputDialogViewModel(string label, string buttonText, string? initialInput = null, Func<string, bool>? validateInput = null)
    {
        Label = label;
        ButtonText = buttonText;

        _input = initialInput ?? "";

        ValidateInput = validateInput;
        
        AcceptAndCloseDialogCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            return Input;
        });
    }
    
    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}