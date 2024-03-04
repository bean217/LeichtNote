using LeichtNote.Models;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class FreifelderViewModel
{
    public string Label =>
        "Hier können Sie fünf Felder beliebig frei definieren. " +
        "Wählen Sie, welche Freifelder Sie verwenden möchten " +
        "und geben Sie eine Bezeichnung ein.";
    
    private SettingsModel SettingsModel { get; }
    public FreifelderViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
    }
}