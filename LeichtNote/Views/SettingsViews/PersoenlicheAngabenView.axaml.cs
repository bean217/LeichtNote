using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using LeichtNote.ViewModels;
using LeichtNote.ViewModels.SettingsViewModels;

namespace LeichtNote.Views.SettingsViews;

public partial class PersoenlicheAngabenView : UserControl
{
    public PersoenlicheAngabenView()
    {
        InitializeComponent();
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DataContext is SettingsWindowViewModel vm)
        {
            // vm.HandleSelectionChanged(e);
        }
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
        // throw new System.NotImplementedException();
    }

    private void InputElement_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        if (e.Source is StackPanel sp && sp.DataContext is MandantViewModel mvm)
        {
            // Debug.WriteLine($"DoubleTapped: {mvm.Name}");
        }
    }
}