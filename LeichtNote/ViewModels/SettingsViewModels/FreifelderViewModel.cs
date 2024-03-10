using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using LeichtNote.Models;
using LeichtNote.Models.SettingsModels;
using LeichtNote.Utils;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class FreifelderViewModel : INotifyPropertyChanged
{
    public string Label =>
        "Hier können Sie fünf Felder beliebig frei definieren. " +
        "Wählen Sie, welche Freifelder Sie verwenden möchten " +
        "und geben Sie eine Bezeichnung ein.";
    
    private SettingsModel SettingsModel { get; }

    private IEnumerable<DictEntry<string?, FreifelderModel>> _viewFreifelder { get; set; }

    public IEnumerable<DictEntry<string?, FreifelderModel>> Freifelder
    {
        get { return _viewFreifelder;  }
        set
        {
            _viewFreifelder = value;
            SettingsModel.Freifelder = value;
            OnPropertyChanged(nameof(Freifelder));
        }
    }
    
    public FreifelderViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
        _viewFreifelder = new List<DictEntry<string?, FreifelderModel>>(SettingsModel.Freifelder);
    }
    
    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}