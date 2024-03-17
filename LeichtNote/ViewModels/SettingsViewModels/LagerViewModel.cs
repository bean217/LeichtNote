using System;
using System.Collections.Generic;
using System.ComponentModel;
using LeichtNote.Models;
using LeichtNote.Models.SettingsModels;
using LeichtNote.Utils;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class LagerViewModel : INotifyPropertyChanged
{
    #region Static Properties
    
    private static int _totalLager = 0;

    #endregion

    #region ViewModel-Only Properties
    
    // integer representing the Freifeld's unique ID
    public readonly int id;

    // string ID shown in Settings/Freifelder view
    public string NameId => $"Lager {id}";
    
    public string SpalteName => Name.Equals("") ? NameId : Name;
    
    #endregion

    #region Model-Shared Properties

    // string indicating the Freifeld's set name
    public string Name
    {
        get { return _lagerModel.Name; }
        set
        {
            _lagerModel.Name = value;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(SpalteName));
        }
    }
    
    // boolean indicating whether Freifeld is enabled in Spaltenansicht view
    public bool Enabled
    {
        get { return _lagerModel.Enabled; }
        set
        {
            _lagerModel.Enabled = value;
            OnPropertyChanged(nameof(Enabled));
            _settingsWindowViewModel.CheckSpaltenUpdate();
        }
    }
    
    // boolean indicating whether Freifeld is shown/hidden in Spaltenansicht view
    public bool IsUsed
    {
        get { return _lagerModel.IsUsed; }
        set
        {
            if (value == false)
            {
                // disable freifeld if it is no longer being used
                _lagerModel.Enabled = value;
            }
            _lagerModel.IsUsed = value;
            OnPropertyChanged(nameof(IsUsed));
        }
    }
    
    private SettingsWindowViewModel _settingsWindowViewModel { get; set; }

    #endregion
    
    #region Model
    
    private LagerModel _lagerModel { get; set; }
    
    #endregion
    
    public LagerViewModel(LagerModel lagerModel, SettingsWindowViewModel settingsWindowViewModel)
    {
        _totalLager++;       // increment the total number of freifeld
        id = _totalLager;    // assign unique ID to freifeld

        _lagerModel = lagerModel;     // set underlying data model
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