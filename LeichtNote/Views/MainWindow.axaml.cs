using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using Avalonia.ReactiveUI;
using LeichtNote.ViewModels;
using ReactiveUI;

namespace LeichtNote.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    private static double AspectRatio => 16.0 / 9.0;
    private static double DefaultScale => 0.8;
    public MainWindow()
    {
        InitializeComponent();
        var screen = Screens.Primary;
        System.Console.WriteLine($"Views/MainWindow.axaml.cs:MainWindow()\tSystem Dims: {screen.Bounds.Width}x{screen.Bounds.Height}px");
        System.Console.WriteLine($"Views/MainWindow.axaml.cs:MainWindow()\tSystem Scale Factor: {screen.Scaling}");

        // Set window lower bounds dimensions
        MinHeight = 100;
        MinWidth = MinHeight * AspectRatio;
        // Set window upper bounds dimensions
        MaxHeight = 720;
        MaxWidth = MaxHeight * AspectRatio;
        // Set window default dimensions
        Height = screen.Bounds.Height * DefaultScale / screen.Scaling;
        Width = Height * AspectRatio;
        
        System.Console.WriteLine($"Views/MainWindow.axaml.cs:MainWindow()\tApp Dims: {(int)Width}x{(int)Height}px");

        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);

    }
}