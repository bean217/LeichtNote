namespace LeichtNote.Models.SettingsModels;

public class SpalteModel
{
    public string Name { get; set; }
    public bool Enabled { get; set; }
    
    public SpalteModel(string name = "", bool enabled = false)
    {
        Name = name;
        Enabled = enabled;
    }
}