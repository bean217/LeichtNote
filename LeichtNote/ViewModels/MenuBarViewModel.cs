using System.Windows.Input;
using System.Reactive.Linq;
using Avalonia.Controls;
using ReactiveUI;

namespace LeichtNote.ViewModels;

public class MenuBarViewModel : Control
{
    public MenuBarViewModel()
    {
        #region Settings Dialog

        ShowSettingsDialogInteraction = new Interaction<SettingsWindowViewModel, SettingsInfoViewModel?>();
        ShowSettingsDialogCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var settings = new SettingsWindowViewModel();
        
            var result = await ShowSettingsDialogInteraction.Handle(settings);
        });

        #endregion
    }
    
    #region Settings Dialog Properties
    
    /// <summary>
    /// Gets the show settings dialog interaction
    /// </summary>
    public Interaction<SettingsWindowViewModel, SettingsInfoViewModel?> ShowSettingsDialogInteraction { get; }
    
    public ICommand ShowSettingsDialogCommand { get; }
    
    #endregion
}