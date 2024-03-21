using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using LeichtNote.ViewModels;
using LeichtNote.ViewModels.DialogViewModels;
using LeichtNote.ViewModels.SettingsViewModels;
using LeichtNote.Views.DialogViews;
using ReactiveUI;

namespace LeichtNote.Views.SettingsViews;

public partial class PersoenlicheAngabenView : ReactiveUserControl<SettingsWindowViewModel>
{
    public PersoenlicheAngabenView()
    {
        InitializeComponent();

        #region Mandant Dialog Initializations

        this.WhenActivated(action => 
            action(
                ViewModel!
                    .ShowNewMandantDialogInteraction
                    .RegisterHandler(DoShowNewMandantDialogAsync)
            )
        );
        
        this.WhenActivated(action => 
            action(
                ViewModel!
                    .ShowEditMandantDialogInteraction
                    .RegisterHandler(DoShowEditMandantDialogAsync)
            )
        );
        
        this.WhenActivated(action => 
            action(
                ViewModel!
                    .ShowDeleteMandantDialogInteraction
                    .RegisterHandler(DoShowDeleteMandantDialogAsync)
            )
        );

        #endregion
    }

    private void DeleteMandant(object? sender, RoutedEventArgs e)
    {
        if (DataContext is SettingsWindowViewModel vm)
        {
            vm.HandleDeleteMandant();
        }
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.Source is StackPanel sp && sp.DataContext is MandantViewModel mvm)
        {
            // Debug.WriteLine($"Pressed: {mvm.Name}");
            if (DataContext is SettingsWindowViewModel vm)
            {
                vm.HandleFocusMandant(mvm);
            }
        }
    }

    private void InputElement_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        if (e.Source is StackPanel sp && sp.DataContext is MandantViewModel mvm)
        {
            // Debug.WriteLine($"DoubleTapped: {mvm.Name}");
            if (DataContext is SettingsWindowViewModel vm)
            {
                vm.ShowEditMandantDialogCommand.Execute(null);
            }
        }
    }

    #region New Mandant Dialog

    private async Task DoShowNewMandantDialogAsync(InteractionContext<InputDialogViewModel, string> context)
    {
        // Get a reference to our TopLevel (the parent window, SettingsWindowViewModel)
        var topLevel = TopLevel.GetTopLevel(this);
        
        var dialog = new InputDialog()
        {
            DataContext = context.Input
        };

        var result = await dialog.ShowDialog<string>((Window)topLevel!);
        context.SetOutput(result);
    }

    #endregion

    #region Edit Mandant Dialog

    private async Task DoShowEditMandantDialogAsync(InteractionContext<InputDialogViewModel, string> context)
    {
        // Get a reference to our TopLevel (the parent window, SettingsWindowViewModel)
        var topLevel = TopLevel.GetTopLevel(this);
        
        var dialog = new InputDialog()
        {
            DataContext = context.Input
        };

        var result = await dialog.ShowDialog<string>((Window)topLevel!);
        context.SetOutput(result);
    }

    #endregion

    #region Delete Mandant Confirmation Dialog

    private async Task DoShowDeleteMandantDialogAsync(InteractionContext<ConfirmationDialogViewModel, MandantViewModel?> context)
    {
        // Get a reference to our TopLevel (the parent window, SettingsWindowViewModel)
        var topLevel = TopLevel.GetTopLevel(this);
        
        var dialog = new InputDialog()
        {
            DataContext = context.Input
        };

        var result = await dialog.ShowDialog<MandantViewModel?>((Window)topLevel!);
        context.SetOutput(result);
    }

    #endregion
}