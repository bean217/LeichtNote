using LeichtNote.Models;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class SchwierigkeitsgradeViewModel
{
    private SettingsModel SettingsModel { get; }
    public SchwierigkeitsgradeViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
    }
}