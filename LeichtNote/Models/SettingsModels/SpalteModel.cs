using System;

namespace LeichtNote.Models.SettingsModels;

public class SpalteModel : ICloneable
{
    public string Name { get; set; }
    public bool Enabled { get; set; }

    public SpalteModel()
    {
        Name = "";
        Enabled = false;
    }
    
    #region ICloneable

    public object Clone()
    {
        var clonedName = (string)Name.Clone();
        var clonedEnabled = Enabled;
        var clonedSpalte = new SpalteModel()
        {
            Name = clonedName,
            Enabled = clonedEnabled,
        };
        return clonedSpalte;
    }

    #endregion
}