using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using LeichtNote.ViewModels;
using ReactiveUI;

namespace LeichtNote.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
        
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}