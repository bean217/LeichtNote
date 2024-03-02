using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia.ReactiveUI;
using LeichtNote.Views;
using ReactiveUI;

namespace LeichtNote.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    #region MainWindow Child ViewModels

    public MenuBarViewModel MenuBarViewModel { get; }
    public MainViewModel MainViewModel { get; }

    #endregion
    
    #region Navigation Properties
    
    // Manages navigation between main window views
    public RoutingState Router { get; } = new RoutingState();
    
    #endregion
    
    public MainWindowViewModel()
    {
        #region MainWindow Initialization

        MenuBarViewModel = new MenuBarViewModel();
        MainViewModel = new MainViewModel(this);

        #endregion
        
        #region Navigation Construction
        
        Router.Navigate.Execute(new MainViewModel(this));
        
        #endregion
    }
}
