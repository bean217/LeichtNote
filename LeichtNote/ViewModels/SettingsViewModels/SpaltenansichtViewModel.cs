using System.ComponentModel;
using LeichtNote.Models;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class SpaltenansichtViewModel : ViewModelBase, INotifyPropertyChanged
{
    private SettingsModel _settingsModel { get; set; }
    public SettingsModel SettingsModel
    {
        get { return _settingsModel; }
        set
        {
            _settingsModel = value;
            OnPropertyChanged(nameof(SettingsModel));
        }
    }
    
    
    public SpaltenansichtViewModel(SettingsModel settingsModel)
    {
        _settingsModel = settingsModel;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}