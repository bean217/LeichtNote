using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using LeichtNote.ViewModels;
using ReactiveUI;
using System;

namespace LeichtNote.Views;

public partial class SettingsWindow : ReactiveWindow<SettingsWindowViewModel>
{
    public SettingsWindow()
    {
        InitializeComponent();

        #region Commands
        
        this.WhenActivated(action => action(ViewModel!.CloseSettingsCommand.Subscribe(Close)));
        this.WhenActivated(action => action(ViewModel!.SaveAndCloseSettingsCommand.Subscribe(Close)));
        
        #endregion
    }
}