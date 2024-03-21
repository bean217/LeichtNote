using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using LeichtNote.ViewModels.DialogViewModels;
using ReactiveUI;

namespace LeichtNote.Views.DialogViews;

public partial class InputDialog : ReactiveWindow<InputDialogViewModel>
{
    public InputDialog()
    {
        InitializeComponent();
        
        #region Commands
        
        this.WhenActivated(action => action(ViewModel!.AcceptAndCloseDialogCommand.Subscribe(Close)));
        
        #endregion
    }
}