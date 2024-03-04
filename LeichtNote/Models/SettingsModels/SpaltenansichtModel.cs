using System.Collections.Generic;
using LeichtNote.Models.SettingsModels.SpaltenansichtModels;
using ReactiveUI;

namespace LeichtNote.Models.SettingsModels;

public class SpaltenansichtModel : ReactiveObject
{
    public List<SpalteModel> Spalten { get; set; }

    public SpaltenansichtModel()
    {
        Spalten = new List<SpalteModel>()
        {
            new SpalteModel { Name = "Test 1", Enabled = true },
            new SpalteModel { Name = "Test 2", Enabled = false },
        };
    }
}