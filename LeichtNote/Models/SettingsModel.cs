using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LeichtNote.Models.SettingsModels;
using LeichtNote.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReactiveUI;
using JsonSerializer = System.Text.Json.JsonSerializer;
using SchwierigkeitsgradModel = LeichtNote.Models.SettingsModels.SchwierigkeitsgradModel;
using SpalteModel = LeichtNote.Models.SettingsModels.SpalteModel;

namespace LeichtNote.Models;

/// <summary>
/// Serializable data object containing LeichtNote settings configuration.
/// </summary>
[XmlRoot]
public class SettingsModel : ReactiveObject, ICloneable
{
    #region Settings Data Storage Properties

    
    private static string ConfigPath => System.IO.Path.Join(Directory.GetCurrentDirectory(), "config");
    private static string FileName => "settings.xml";

    #endregion

    #region Settings Data
    
    [XmlIgnore]
    public IEnumerable<MandantModel> Mandanten { get; set; }

    [XmlElement]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public List<MandantModel> MandantenSurrogate
    {
        get { return Mandanten.ToList(); }
        set { Mandanten = value; }
    }
    
    
    [XmlIgnore]
    public IEnumerable<SpalteModel> Spalten { get; set; }

    [XmlElement]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public List<SpalteModel> SpaltenSurrogate
    {
        get { return Spalten.ToList(); }
        set { Spalten = value; }
    }
    
    [XmlIgnore]
    public IEnumerable<SchwierigkeitsgradModel> Schwierigkeitsgrade { get; set; }

    [XmlElement]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public List<SchwierigkeitsgradModel> SchwierigkeitsgradeSurrogate
    {
        get { return Schwierigkeitsgrade.ToList(); }
        set { Schwierigkeitsgrade = value; }
    }
    
    [XmlIgnore]
    public IEnumerable<FreifeldModel> Freifelder { get; set; }

    [XmlElement]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public List<FreifeldModel> FreifelderSurrogate
    {
        get { return Freifelder.ToList(); }
        set { Freifelder = value; }
    }
    
    [XmlIgnore]
    public IEnumerable<LagerModel> Lager { get; set; }

    [XmlElement]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public List<LagerModel> LagerSurrogate
    {
        get { return Lager.ToList(); }
        set { Lager = value; }
    }
    
    public bool AllesSpaltenUmschalten { get; set; }
    
    public string Datenbankpfad { get; set; }

    #endregion

    public SettingsModel()
    {
        #region Settings Data

        Mandanten = new List<MandantModel>()
        {
            new MandantModel()
            {
                Name = "TestMandant1"
            },
            new MandantModel()
            {
                Name = "TestMandant2"
            },
            new MandantModel()
            {
                Name = "TestMandant3"
            },
        };
        
        Spalten = new List<SpalteModel>()
        {
            new SpalteModel()
            {
                Name = "T1"
            },
            new SpalteModel()
            {
                Name = "T2"
            },
        };

        Schwierigkeitsgrade = new List<SchwierigkeitsgradModel>()
        {
            new SchwierigkeitsgradModel() { Grad = 1, Beschreibung = "Anfänger" },
            new SchwierigkeitsgradModel() { Grad = 2, Beschreibung = "Leicht" },
            new SchwierigkeitsgradModel() { Grad = 3, Beschreibung = "Mittel" },
            new SchwierigkeitsgradModel() { Grad = 4, Beschreibung = "Schwer" },
            new SchwierigkeitsgradModel() { Grad = 5, Beschreibung = "Sehr schwer" },
        };
        
        Freifelder = new List<FreifeldModel>()
        {
            new FreifeldModel() { Name = "T1" },
            new FreifeldModel() { Name = "T2" },
            new FreifeldModel() { Name = "T3" },
            new FreifeldModel() { Name = "T4" },
            new FreifeldModel() { Name = "T5" },
        };

        Lager = new List<LagerModel>()
        {
            new LagerModel { Name = "T1" },
            new LagerModel { Name = "T2" },
            new LagerModel { Name = "T3" },
        };

        AllesSpaltenUmschalten = false;

        Datenbankpfad = Directory.GetCurrentDirectory();

        #endregion
    }

    #region Save Settings Tasks

    public void Save()
    {
        if (!Directory.Exists(ConfigPath))
        {
            Directory.CreateDirectory(ConfigPath);
        }

        using (var writer = new StreamWriter(Path.Join(ConfigPath, FileName)))
        {
            var serializer = new XmlSerializer(typeof(SettingsModel));
            serializer.Serialize(writer, this);
        }
    }

    /// <summary>
    /// Saves SettingsModel object asynchronously
    /// </summary>
    public async Task SaveAsync()
    {
        var task = Task.Run(() => Save());
        await task;
    }

    #endregion

    #region Load Settings Tasks

    public static SettingsModel LoadSettings()
    {
        if (File.Exists(Path.Join(ConfigPath, FileName)))
        {
            using (var reader = new StreamReader(Path.Join(ConfigPath, FileName)))
            {
                var serializer = new XmlSerializer(typeof(SettingsModel));
                var data = (SettingsModel)serializer.Deserialize(reader)!;
                if (data is null)
                {
                    // error occurred while deserializing
                    throw new JsonException(
                        $"Failed to deserialize object `{nameof(SettingsModel)}` from file {Path.Join(ConfigPath, FileName)}"); 
                }
                return data;
            }
        }
        // settings file doesn't exist
        throw new FileNotFoundException($"Could not locate {Path.Join(ConfigPath, FileName)}");
        
    }

    public static async Task<SettingsModel> LoadSettingsAsync()
    {
        return await Task.Run(() => LoadSettings());
    }

    #endregion

    #region ICloneable

    public object Clone()
    {
        var clonedSpalten = new List<SpalteModel>();
        foreach (var s in Spalten)
        {
            clonedSpalten.Add((SpalteModel)s.Clone());
        }

        var clonedFreifelder = new List<FreifeldModel>();
        foreach (var f in Freifelder)
        {
            clonedFreifelder.Add((FreifeldModel)f.Clone());
        }

        var clonedLager = new List<LagerModel>();
        foreach (var l in Lager)
        {
            clonedLager.Add((LagerModel)l.Clone());
        }

        var clonedSchwierigkeitsgrade = new List<SchwierigkeitsgradModel>();
        foreach (var s in Schwierigkeitsgrade)
        {
            clonedSchwierigkeitsgrade.Add((SchwierigkeitsgradModel)s.Clone());
        }
        
        // primitive type is passed by value
        var clonedAllesSpaltenUmschalten = AllesSpaltenUmschalten;
        
        var clonedSettingsModel = new SettingsModel()
        {
            Spalten = clonedSpalten,
            Freifelder = clonedFreifelder,
            Lager = clonedLager,
            Schwierigkeitsgrade = clonedSchwierigkeitsgrade,
            AllesSpaltenUmschalten = clonedAllesSpaltenUmschalten,
        };
        return clonedSettingsModel;
    }

    #endregion
}