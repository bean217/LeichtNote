using LeichtNote.Models;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class LagerViewModel
{
    public string Label =>
        "Hier können Sie wählen, welche Lagerplätze Sie verwenden " +
        "möchten.\nAußerdem können Sie die Bezeichnungen für Ihr " +
        "Lager eingeben.\n(z.B. Regal / Fach / Ordner /Schrank etc.)";
    
    private SettingsModel SettingsModel { get; }
    public LagerViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
    }
}