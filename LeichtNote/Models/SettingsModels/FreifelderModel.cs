namespace LeichtNote.Models.SettingsModels;

public class FreifelderModel
{
    private string? _name { get; set; }

    public string? Name
    {
        get { return _name; }
        set
        {
            _name = value;
        }
    }
    
    private bool? _enabled { get; set; }

    public bool? Enabled
    {
        get { return _enabled; }
        set
        {
            _enabled = value;
        }
    }
}