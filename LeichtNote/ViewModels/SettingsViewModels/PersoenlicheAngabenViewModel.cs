using LeichtNote.Models;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class PersoenlicheAngabenViewModel
{
    private SettingsModel SettingsModel { get; }
    public PersoenlicheAngabenViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
    }
}