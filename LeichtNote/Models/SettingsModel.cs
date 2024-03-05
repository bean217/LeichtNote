using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using LeichtNote.Models.SettingsModels;
using LeichtNote.Models.SettingsModels.SpaltenansichtModels;
using ReactiveUI;

namespace LeichtNote.Models;

/// <summary>
/// Serializable data object containing LeichtNote settings configuration.
/// </summary>
public class SettingsModel : ReactiveObject
{
    private static string ConfigPath => "./config/";
    private static string FileName => "settings.json";
    public SpaltenansichtModel SpaltenansichtModel { get; set; }

    public SettingsModel()
    {
        SpaltenansichtModel = new SpaltenansichtModel();
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