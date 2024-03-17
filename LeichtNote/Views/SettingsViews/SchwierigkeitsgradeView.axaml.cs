using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using LeichtNote.Models.SettingsModels.SchwierigkeitsgradeModels;
using LeichtNote.ViewModels;
using LeichtNote.ViewModels.SettingsViewModels;

namespace LeichtNote.Views.SettingsViews;

public partial class SchwierigkeitsgradeView : UserControl
{
    public SchwierigkeitsgradeView()
    {
        InitializeComponent();
    }


    private void DataGrid_OnCellEditEnded(object? sender, DataGridCellEditEndedEventArgs e)
    {
        if (DataContext is SettingsWindowViewModel vm)
        {
            vm.HandleCellEditEnded(e);
        }
    }
    


    private void DataGrid_OnCellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
    {
        if (DataContext is SettingsWindowViewModel vm)
        {
            vm.HandleCellEditEnding(e);
        }
    }
}