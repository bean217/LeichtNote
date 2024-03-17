using System;

namespace LeichtNote.Models.SettingsModels;

public class SchwierigkeitsgradModel : ICloneable
{
    public float? Grad { get; set; }
    public string Beschreibung;
    
    public SchwierigkeitsgradModel()
    {
        Grad = null;
        Beschreibung = "";
    }
    
    #region ICloneable

    public object Clone()
    {
        var clonedGrad = Grad;
        var clonedBeschreibung = (string)Beschreibung.Clone();
        var clonedSchwierigkeitsgrad = new SchwierigkeitsgradModel()
        {
            Grad = clonedGrad,
            Beschreibung = clonedBeschreibung,
            
        };
        return clonedSchwierigkeitsgrad;
    }

    #endregion
}