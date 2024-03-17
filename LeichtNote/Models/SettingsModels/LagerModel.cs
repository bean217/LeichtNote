using System;

namespace LeichtNote.Models.SettingsModels;

public class LagerModel : ICloneable
{
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public bool IsUsed { get; set; }

    public LagerModel()
    {
        Name = "";
        Enabled = false;
        IsUsed = false;
    }
    
    #region ICloneable

    public object Clone()
    {
        var clonedName = (string)Name.Clone();
        var clonedEnabled = Enabled;
        var clonedIsUsed = IsUsed;
        var clonedLager = new LagerModel()
        {
            Name = clonedName,
            Enabled = clonedEnabled,
            IsUsed = clonedIsUsed
        };
        return clonedLager;
    }

    #endregion
}