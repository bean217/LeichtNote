using System;
using LeichtNote.ViewModels;
using LeichtNote.Views;
using ReactiveUI;

namespace LeichtNote
{
    public class ViewRouter : IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
        {
            MainViewModel context => new MainView { DataContext = context },
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}   