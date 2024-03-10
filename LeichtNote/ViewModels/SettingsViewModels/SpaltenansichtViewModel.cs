using System;
using System.ComponentModel;
using LeichtNote.Models;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class SpaltenansichtViewModel : ViewModelBase
{
    public SettingsModel SettingsModel { get; set; }
    public SpaltenansichtViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
    }
}