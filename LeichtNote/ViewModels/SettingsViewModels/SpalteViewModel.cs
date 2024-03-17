using System.ComponentModel;
using LeichtNote.Models.SettingsModels;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class SpalteViewModel : INotifyPropertyChanged
{
    #region Model-Shared Properties

    // string indicating the Freifeld's set name
    public string Name
    {
        get { return _spalteModel.Name; }
        set
        {
            _spalteModel.Name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    
    // boolean indicating whether Freifeld is enabled in Spaltenansicht view
    public bool Enabled
    {
        get { return _spalteModel.Enabled; }
        set
        {
            _spalteModel.Enabled = value;
            OnPropertyChanged(nameof(Enabled));
            _settingsWindowViewModel.CheckSpaltenUpdate();
        }
    }
    
    private SettingsWindowViewModel _settingsWindowViewModel { get; set; }
    
    #endregion
    
    #region Model
    
    private SpalteModel _spalteModel { get; set; }
    
    #endregion
    
    public SpalteViewModel(SpalteModel spalteModel, SettingsWindowViewModel settingsWindowViewModel)
    {
        _spalteModel = spalteModel;     // set underlying data model
        _settingsWindowViewModel = settingsWindowViewModel;
    }
    
    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}