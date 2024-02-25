using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using LeichtNote.ViewModels;
using LeichtNote.Views;

namespace LeichtNote;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow //MyView //ViewActivationView
            {
                DataContext = new MainWindowViewModel(), //MyViewModel(), //ViewActivationViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}