using System.ComponentModel;
using LeichtNote.Models.SettingsModels;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class FreifeldViewModel : INotifyPropertyChanged
{
    #region Static Properties
    
    private static int _totalFreifeld = 0;

    #endregion

    #region ViewModel-Only Properties
    
    // integer representing the Freifeld's unique ID
    public readonly int id;

    // string ID shown in Settings/Freifelder view
    public string NameId => $"Freifeld {id}";
    
    public string SpalteName => Name.Equals("") ? NameId : Name;
    
    #endregion

    #region Model-Shared Properties

    // string indicating the Freifeld's set name
    public string Name
    {
        get { return _freifeldModel.Name; }
        set
        {
            _freifeldModel.Name = value;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(SpalteName));
        }
    }
    
    // boolean indicating whether Freifeld is enabled in Spaltenansicht view
    public bool Enabled
    {
        get { return _freifeldModel.Enabled; }
        set
        {
            _freifeldModel.Enabled = value;
            OnPropertyChanged(nameof(Enabled));
            _settingsWindowViewModel.CheckSpaltenUpdate();
        }
    }
    
    // boolean indicating whether Freifeld is shown/hidden in Spaltenansicht view
    public bool IsUsed
    {
        get { return _freifeldModel.IsUsed; }
        set
        {
            if (value == false)
            {
                // disable freifeld if it is no longer being used
                _freifeldModel.Enabled = value;
            }
            _freifeldModel.IsUsed = value;
            OnPropertyChanged(nameof(IsUsed));
        }
    }
    
    private SettingsWindowViewModel _settingsWindowViewModel { get; set; }

    #endregion
    
    #region Model
    
    private FreifeldModel _freifeldModel { get; set; }
    
    #endregion
    
    public FreifeldViewModel(FreifeldModel freifeldModel, SettingsWindowViewModel settingsWindowViewModel)
    {
        _totalFreifeld++;       // increment the total number of freifeld
        id = _totalFreifeld;    // assign unique ID to freifeld

        _freifeldModel = freifeldModel;     // set underlying data model
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