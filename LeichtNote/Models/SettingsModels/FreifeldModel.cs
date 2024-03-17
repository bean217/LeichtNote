using System;

namespace LeichtNote.Models.SettingsModels;

public class FreifeldModel : ICloneable
{
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public bool IsUsed { get; set; }

    public FreifeldModel()
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
        var clonedFreifeld = new FreifeldModel()
        {
            Name = clonedName,
            Enabled = clonedEnabled,
            IsUsed = clonedIsUsed
        };
        return clonedFreifeld;
    }

    #endregion
}