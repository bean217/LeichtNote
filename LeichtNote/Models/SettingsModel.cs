using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using LeichtNote.Models.SettingsModels;
using LeichtNote.Models.SettingsModels.SchwierigkeitsgradeModels;
using LeichtNote.Models.SettingsModels.SpaltenansichtModels;
using LeichtNote.Utils;
using ReactiveUI;
using SchwierigkeitsgradModel = LeichtNote.Models.SettingsModels.SchwierigkeitsgradModel;
using SpalteModel = LeichtNote.Models.SettingsModels.SpalteModel;

namespace LeichtNote.Models;

/// <summary>
/// Serializable data object containing LeichtNote settings configuration.
/// </summary>
public class SettingsModel : ReactiveObject
{
    #region Settings Data Storage Properties

    
    private static string ConfigPath => "./config/";
    private static string FileName => "settings.json";

    #endregion

    #region Settings Data
    
    public IEnumerable<SpalteModel> Spalten { get; set; }
    public IEnumerable<SchwierigkeitsgradModel> Schwierigkeitsgrade { get; set; }
    public IEnumerable<FreifeldModel> Freifelder { get; set; }
    public IEnumerable<LagerModel> Lager { get; set; }
    
    public bool AllesSpaltenUmschalten { get; set; }

    #endregion

    public SettingsModel()
    {
        #region Settings Data
        
        Spalten = new List<SpalteModel>()
        {
            new SpalteModel("T1"),
            new SpalteModel("T2"),
        };

        Schwierigkeitsgrade = new List<SchwierigkeitsgradModel>()
        {
            new SchwierigkeitsgradModel(grad: 1, beschreibung: "Anfänger"),
            new SchwierigkeitsgradModel(grad: 2, beschreibung: "Leicht"),
            new SchwierigkeitsgradModel(grad: 3, beschreibung: "Mittel"),
            new SchwierigkeitsgradModel(grad: 4, beschreibung: "Schwer"),
            new SchwierigkeitsgradModel(grad: 5, beschreibung: "Sehr schwer"),
        };
        
        Freifelder = new List<FreifeldModel>()
        {
            new FreifeldModel(name:"T1"),
            new FreifeldModel(name:"T2"),
            new FreifeldModel(name:"T3"),
            new FreifeldModel(name:"T4"),
            new FreifeldModel(name:"T5"),
        };

        Lager = new List<LagerModel>()
        {
            new LagerModel(name: "T1"),
            new LagerModel(name: "T2"),
            new LagerModel(name: "T3"),
        };

        AllesSpaltenUmschalten = false;

        #endregion
    }

    #region Save Settings Tasks

    public async Task SaveAsync()
    {
        if (!Directory.Exists(ConfigPath))
        {
            Directory.CreateDirectory(ConfigPath);
        }

        using (var fs = File.OpenWrite(ConfigPath + FileName))
        {
            await SaveToStreamAsync(this, fs);
        }
    }

    public static async Task SaveToStreamAsync(SettingsModel data, Stream stream)
    {
        await JsonSerializer.SerializeAsync(stream, data).ConfigureAwait(false);
    }

    #endregion

    #region Load Settings Tasks

    public static async Task<SettingsModel> LoadFromStream(Stream stream)
    {
        return (await JsonSerializer.DeserializeAsync<SettingsModel>(stream).ConfigureAwait(false))!;
    }

    public static async Task<SettingsModel> LoadSettingsAsync()
    {
        if (!Directory.Exists(ConfigPath))
        {
            Directory.CreateDirectory(ConfigPath);
        }

        var results = default(SettingsModel);

        foreach (var file in Directory.EnumerateFiles(ConfigPath))
        {
            if (FileName.Equals(new DirectoryInfo(file).FullName))
            {
                await using var fs = File.OpenRead(file);
                results = await SettingsModel.LoadFromStream(fs).ConfigureAwait(false);
            }
        }

        if (results is null)
        {
            throw new FileNotFoundException($"Could not locate {ConfigPath + FileName}");
        }

        return results;
    }

    #endregion
}