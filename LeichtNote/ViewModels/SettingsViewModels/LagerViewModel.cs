using System.Collections.Generic;
using System.ComponentModel;
using LeichtNote.Models;
using LeichtNote.Models.SettingsModels;
using LeichtNote.Utils;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class LagerViewModel : INotifyPropertyChanged
{
    public string Label =>
        "Hier können Sie wählen, welche Lagerplätze Sie verwenden " +
        "möchten.\nAußerdem können Sie die Bezeichnungen für Ihr " +
        "Lager eingeben.\n(z.B. Regal / Fach / Ordner /Schrank etc.)";
    
    private SettingsModel SettingsModel { get; }
    
    private IEnumerable<DictEntry<string?, LagerModel>> _viewLager { get; set; }

    public IEnumerable<DictEntry<string?, LagerModel>> Lager
    {
        get { return _viewLager;  }
        set
        {
            _viewLager = value;
            SettingsModel.Lager = value;
            OnPropertyChanged(nameof(Lager));
        }
    }
    
    public LagerViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
        _viewLager = new List<DictEntry<string?, LagerModel>>(SettingsModel.Lager);
    }
    
    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}