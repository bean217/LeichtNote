using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using LeichtNote.ViewModels.SettingsViewModels;

namespace LeichtNote.Views.SettingsViews;

public partial class SpaltenansichtView : ReactiveUserControl<SpaltenansichtViewModel>
{
    public SpaltenansichtView()
    {
        InitializeComponent();
    }
}