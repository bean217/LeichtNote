using System;
using System.Windows.Input;
using System.Reactive.Linq;
using Avalonia.Controls;
using LeichtNote.Models;
using ReactiveUI;

namespace LeichtNote.ViewModels;

public class MenuBarViewModel : Control
{
    public MainWindowViewModel MainWindowViewModel { get; set; }
    public MenuBarViewModel(MainWindowViewModel mainWindowViewModel)
    {
        MainWindowViewModel = mainWindowViewModel;
        
        #region Settings Dialog

        ShowSettingsDialogInteraction = new Interaction<SettingsWindowViewModel, SettingsModel?>();
        ShowSettingsDialogCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var settings = new SettingsWindowViewModel((SettingsModel)MainWindowViewModel.SettingsModel.Clone());
        
            var result = await ShowSettingsDialogInteraction.Handle(settings);
            if (result is not null)
            {
                MainWindowViewModel.SettingsModel = result;
            }
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