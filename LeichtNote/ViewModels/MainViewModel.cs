using ReactiveUI;
using System;

namespace LeichtNote.ViewModels;

public class MainViewModel : ReactiveObject, IRoutableViewModel
{
    // Reference to IScreen that owns the routable view model.
    public IScreen HostScreen { get; }
    
    // Unique identifier for the routable view model.
    public string UrlPathSegment => "first";

    public MainViewModel(IScreen screen)
    {
        HostScreen = screen;
    }

}