namespace LeichtNote.Models.SettingsModels;

public class LagerModel
{
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public bool IsUsed { get; set; }

    public LagerModel(string name = "", bool enabled = false, bool isUsed = false)
    {
        Name = name;
        Enabled = enabled;
        IsUsed = isUsed;
    }
}