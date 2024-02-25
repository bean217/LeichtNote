using System.Reactive.Linq;
using Avalonia.ReactiveUI;
using LeichtNote.Views;
using ReactiveUI;

namespace LeichtNote.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

    public RoutingState Router { get; } = new RoutingState();
    public MainWindowViewModel()
    {
        Router.Navigate.Execute(new MainViewModel(this));
    }
}
