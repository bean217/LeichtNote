using System.Collections.ObjectModel;
using LeichtNote.Models.SettingsModels;
using LeichtNote.Models.SettingsModels.SpaltenansichtModels;
using ReactiveUI;

namespace LeichtNote.Models;

/// <summary>
/// Serializable data object containing LeichtNote settings configuration.
/// </summary>
public class SettingsModel : ReactiveObject
{
    public SpaltenansichtModel SpaltenansichtModel { get; set; }

    public SettingsModel()
    {
        SpaltenansichtModel = new SpaltenansichtModel();
    }
    
    public void Save()
    {
    }
}