using System;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.ReactiveUI;
using LeichtNote.Models;
using LeichtNote.Views;
using ReactiveUI;

namespace LeichtNote.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    #region MainWindow Child ViewModels

    public MenuBarViewModel MenuBarViewModel { get; }
    public MainViewModel MainViewModel { get; }
    
    public SettingsModel SettingsModel { get; set; }

    #endregion
    
    #region Navigation Properties
    
    // Manages navigation between main window views
    public RoutingState Router { get; } = new RoutingState();
    
    #endregion
    
    public MainWindowViewModel()
    {
        #region MainWindow Initialization

        MenuBarViewModel = new MenuBarViewModel(this);
        MainViewModel = new MainViewModel(this);

        // TODO: Create a loading screen and change this to async later
        SettingsModel = SettingsModel.LoadSettings();
        // Console.WriteLine(Directory.GetCurrentDirectory());
        // foreach (var d in Directory.GetFiles(Directory.GetCurrentDirectory()))
        // {
        //     Console.WriteLine(d);
        // }
        
        #endregion
        
        #region Navigation Construction
        
        Router.Navigate.Execute(new MainViewModel(this));
        
        #endregion
    }
}
