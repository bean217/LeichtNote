using LeichtNote.Models;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class DatenimportViewModel
{
    private SettingsModel SettingsModel { get; }
    public DatenimportViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
    }
}