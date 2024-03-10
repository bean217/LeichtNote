using System.Collections;
using System.Collections.Generic;
using LeichtNote.Models;
using LeichtNote.Models.SettingsModels;
using LeichtNote.Utils;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class FreifelderViewModel
{
    public string Label =>
        "Hier können Sie fünf Felder beliebig frei definieren. " +
        "Wählen Sie, welche Freifelder Sie verwenden möchten " +
        "und geben Sie eine Bezeichnung ein.";
    
    private SettingsModel SettingsModel { get; }

    private IEnumerable<DictEntry<string?, FreifelderModel>> _viewFreifelder { get; set; }

    public IEnumerable<DictEntry<string?, FreifelderModel>> Freifelder
    {
        get { return _viewFreifelder;  }
        set
        {
            _viewFreifelder = value;
        }
    }
    
    public FreifelderViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
        _viewFreifelder = new List<DictEntry<string?, FreifelderModel>>()
        {
            new DictEntry<string?, FreifelderModel>("Freifelder 1", new FreifelderModel { Name = "T1", Enabled = false }),
            new DictEntry<string?, FreifelderModel>("Freifelder 2", new FreifelderModel { Name = "T2", Enabled = false }),
            new DictEntry<string?, FreifelderModel>("Freifelder 3", new FreifelderModel { Name = "T3", Enabled = false }),
            new DictEntry<string?, FreifelderModel>("Freifelder 4", new FreifelderModel { Name = "T3", Enabled = false }),
            new DictEntry<string?, FreifelderModel>("Freifelder 5", new FreifelderModel { Name = "T5", Enabled = false }),
        };
        // _viewFreifelder = new List<FreifelderModel>()
        // {
        //     new FreifelderModel { Name = "F1", Enabled = false },
        //     new FreifelderModel { Name = "F2", Enabled = false },
        //     new FreifelderModel { Name = "F3", Enabled = false },
        //     new FreifelderModel { Name = "F4", Enabled = false },
        //     new FreifelderModel { Name = "F5", Enabled = false },
        // };
    }
}