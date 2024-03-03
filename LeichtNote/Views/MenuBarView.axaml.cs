using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using LeichtNote.Models;
using LeichtNote.ViewModels;
using ReactiveUI;

namespace LeichtNote.Views;

public partial class MenuBarView : ReactiveUserControl<MenuBarViewModel>
{
    public MenuBarView()
    {
        InitializeComponent();
        
        #region Settings Dialog Initialization
        
        this.WhenActivated(action => 
            action(
                ViewModel!
                    .ShowSettingsDialogInteraction
                    .RegisterHandler(DoShowSettingsDialogAsync)
            )
        );

        #endregion
    }
    
    #region Settings Dialog
    
    private async Task DoShowSettingsDialogAsync(InteractionContext<SettingsWindowViewModel, SettingsModel?> context)
    {
        // Get a reference to our TopLevel (the parent window)
        var topLevel = TopLevel.GetTopLevel(this);

        var dialog = new SettingsWindow
        {
            DataContext = context.Input
        };

        var result = await dialog.ShowDialog<SettingsModel?>((Window)topLevel!);
        context.SetOutput(result);
    }
    
    #endregion
}