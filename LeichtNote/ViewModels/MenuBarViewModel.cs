using System;
using System.Windows.Input;
using System.Reactive.Linq;
using Avalonia.Controls;
using LeichtNote.Models;
using ReactiveUI;

namespace LeichtNote.ViewModels;

public class MenuBarViewModel : Control
{
    private MainWindowViewModel _mainWindowViewModel { get; set; }
    public MenuBarViewModel(MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        
        #region Settings Dialog

        ShowSettingsDialogInteraction = new Interaction<SettingsWindowViewModel, SettingsModel?>();
        ShowSettingsDialogCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var settings = new SettingsWindowViewModel();
        
            var result = await ShowSettingsDialogInteraction.Handle(settings);
            Console.WriteLine(result);
        });

        #endregion
    }
    
    #region Settings Dialog Properties
    
    /// <summary>
    /// Gets the show settings dialog interaction
    /// </summary>
    public Interaction<SettingsWindowViewModel, SettingsModel?> ShowSettingsDialogInteraction { get; }
    
    public ICommand ShowSettingsDialogCommand { get; }
    
    #endregion
}