using System;
using System.Collections.ObjectModel;
using LeichtNote.Models;
using LeichtNote.Models.SettingsModels.SpaltenansichtModels;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class SpaltenansichtViewModel : ViewModelBase
{
    public SettingsModel SettingsModel { get; }
    public SpaltenansichtViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
    }
}