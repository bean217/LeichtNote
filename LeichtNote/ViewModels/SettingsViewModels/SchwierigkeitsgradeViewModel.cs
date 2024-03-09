using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using LeichtNote.Models;
using LeichtNote.Models.SettingsModels.SchwierigkeitsgradeModels;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class SchwierigkeitsgradeViewModel //: INotifyPropertyChanged
{
    public SettingsModel SettingsModel { get; set; }
    public SchwierigkeitsgradeViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
    }
}