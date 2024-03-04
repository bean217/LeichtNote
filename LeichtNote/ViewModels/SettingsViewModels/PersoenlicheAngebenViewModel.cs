using LeichtNote.Models;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class PersoenlicheAngebenViewModel
{
    private SettingsModel SettingsModel { get; }
    public PersoenlicheAngebenViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
    }
}