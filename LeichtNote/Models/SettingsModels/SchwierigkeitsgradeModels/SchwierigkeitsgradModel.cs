using System;
using System.ComponentModel;
using Avalonia.Media;

namespace LeichtNote.Models.SettingsModels.SchwierigkeitsgradeModels;

public class SchwierigkeitsgradModel
{
    private float? _grad { get; set; }
    public float? Grad
    {
        get { return _grad; }
        set
        {
            _grad = value;
            Console.Write($"Empty: {IsEmpty()}, ");
        }
    }
    
    private string? _beschreibung { get; set; }
    public string? Beschreibung
    {
        get { return _beschreibung; }
        set
        {
            _beschreibung = value ?? "";
            Console.WriteLine($"Empty: {IsEmpty()}");
        }
    }

    /// <summary>
    /// Determines whether the object is a valid (usable) Schwierigkeitgrad
    /// </summary>
    /// <returns></returns>
    public bool IsValid()   //TODO: Should probably move this method to a ViewModel
    {
        return _grad != null && (_beschreibung != null || (_beschreibung != null && _beschreibung.Equals("")));
    }
    
    /// <summary>
    /// Determines whether the object contains any valid Schwierigkeitgrad data
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()   //TODO: Should probably move this method to a ViewModel
    {
        return _grad is null && (_beschreibung is null || _beschreibung.Equals(""));
    }
}