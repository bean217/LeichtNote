using LeichtNote.Models.SettingsModels.SpaltenansichtModels;

namespace LeichtNote.Models.SettingsModels;

public class FreifelderModel
{
    public SpalteModel Spalte { get; set; }
    // private string? _name { get; set; }
    //
    // public string? Name
    // {
    //     get { return _name; }
    //     set
    //     {
    //         _name = value;
    //     }
    // }
    //
    // private bool? _enabled { get; set; }
    //
    // public bool? Enabled
    // {
    //     get { return _enabled; }
    //     set
    //     {
    //         _enabled = value;
    //     }
    // }
    
    private bool? _enabled { get; set; }
    
    public bool? Enabled
    {
        get { return _enabled; }
        set
        {
            _enabled = value;
        }
    }
    
    public FreifelderModel(string? name = null)
    {
        Spalte = new SpalteModel
        {
            Name = name ?? "",
            Enabled = false
        };
        _enabled = false;
    }
}