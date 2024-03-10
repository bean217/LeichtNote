using System;
using System.Collections.Generic;
using System.ComponentModel;
using LeichtNote.Models;
using LeichtNote.Models.SettingsModels;
using LeichtNote.Models.SettingsModels.SpaltenansichtModels;
using LeichtNote.Utils;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class SpaltenansichtViewModel : ViewModelBase, INotifyPropertyChanged
{
    public SettingsModel SettingsModel { get; set; }
    
    private IEnumerable<SpalteModel> _viewSpalten { get; set; }
    public IEnumerable<SpalteModel> Spalten
    {
        get { return _viewSpalten; }
        set
        {
            Console.WriteLine("UPDATED SPALTEN");
            _viewSpalten = value;
            SettingsModel.Spalten = _viewSpalten;
            OnPropertyChanged(nameof(Spalten));
        }
    }

    private IEnumerable<DictEntry<string?, FreifelderModel>> _viewFreifelder { get; set; }
    public IEnumerable<DictEntry<string?, FreifelderModel>> Freifelder
    {
        get { return _viewFreifelder; }
        set
        {
            _viewFreifelder = value;
            SettingsModel.Freifelder = _viewFreifelder;
            OnPropertyChanged(nameof(Freifelder));
        }
    }

    private IEnumerable<DictEntry<string?, LagerModel>> _viewLager { get; set; }
    public IEnumerable<DictEntry<string?, LagerModel>> Lager
    {
        get { return _viewLager; }
        set
        {
            _viewLager = value;
            SettingsModel.Lager = _viewLager;
            OnPropertyChanged(nameof(Lager));
        }
    }

    private bool _allesUmschalten { get; set; }
    public bool AllesUmschalten
    {
        get { return SettingsModel.AllesSpaltenUmschalten; }
        set
        {
            Console.Write("TOGGLED");
            _allesUmschalten = value;
            SettingsModel.AllesSpaltenUmschalten = _allesUmschalten;
            OnPropertyChanged(nameof(AllesUmschalten));
            // update all standardspalten
            foreach (var spalte in Spalten)
            {
                spalte.Enabled = _allesUmschalten;
            }
            // update all freifeldspalten
            foreach (var freifeldDictEntry in Freifelder)
            {
                freifeldDictEntry.Value.Spalte.Enabled = _allesUmschalten;
            }
            // update all lagerspalten
            foreach (var lagerDictEntry in Lager)
            {
                lagerDictEntry.Value.Spalte.Enabled = _allesUmschalten;
            }
            
        }
    }
    
    public SpaltenansichtViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
        _allesUmschalten = settingsModel.AllesSpaltenUmschalten;
        _viewSpalten = SettingsModel.Spalten;
        _viewFreifelder = SettingsModel.Freifelder;
        _viewLager = SettingsModel.Lager;
    }
    
    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}