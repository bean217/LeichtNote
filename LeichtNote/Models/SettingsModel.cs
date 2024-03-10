using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using LeichtNote.Models.SettingsModels;
using LeichtNote.Models.SettingsModels.SchwierigkeitsgradeModels;
using LeichtNote.Models.SettingsModels.SpaltenansichtModels;
using ReactiveUI;

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

    #endregion

    public SettingsModel()
    {
        #region Settings Data
        
        Spalten = new List<SpalteModel>()
        {
            new SpalteModel { Name = "Test 1", Enabled = true },
            new SpalteModel { Name = "Test 2", Enabled = false },
        };

        Schwierigkeitsgrade = new List<SchwierigkeitsgradModel>()
        {
            new SchwierigkeitsgradModel { Grad = 1, Beschreibung = "Anfänger"},
            new SchwierigkeitsgradModel { Grad = 2, Beschreibung = "Leicht"},
            new SchwierigkeitsgradModel { Grad = 3, Beschreibung = "Mittel"},
            new SchwierigkeitsgradModel { Grad = 4, Beschreibung = "Schwer"},
            new SchwierigkeitsgradModel { Grad = 5, Beschreibung = "Sehr schwer"}
        };

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