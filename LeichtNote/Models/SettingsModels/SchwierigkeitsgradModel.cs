namespace LeichtNote.Models.SettingsModels;

public class SchwierigkeitsgradModel
{
    public float? Grad { get; set; }
    public string Beschreibung;
    
    public SchwierigkeitsgradModel(float? grad = null, string beschreibung = "")
    {
        Grad = grad;
        Beschreibung = beschreibung;
    }
}