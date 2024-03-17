using System.ComponentModel;
using LeichtNote.Models.SettingsModels;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class SchwierigkeitsgradViewModel : INotifyPropertyChanged
{
    // private float? _grad { get; set; }
    // public float? Grad
    // {
    //     get { return _grad; }
    //     set
    //     {
    //         _grad = value;
    //     }
    // }
    //
    // private string? _beschreibung { get; set; }
    // public string? Beschreibung
    // {
    //     get { return _beschreibung; }
    //     set
    //     {
    //         _beschreibung = value ?? "";
    //     }
    // }
    //
    // /// <summary>
    // /// Determines whether the object is a valid (usable) Schwierigkeitgrad
    // /// </summary>
    // /// <returns></returns>
    // public bool IsValid()   //TODO: Should probably move this method to a ViewModel
    // {
    //     return _grad != null && (_beschreibung != null || (_beschreibung != null && _beschreibung.Equals("")));
    // }
    //
    // /// <summary>
    // /// Determines whether the object contains any valid Schwierigkeitgrad data
    // /// </summary>
    // /// <returns></returns>
    // public bool IsEmpty()   //TODO: Should probably move this method to a ViewModel
    // {
    //     return _grad is null && (_beschreibung is null || _beschreibung.Equals(""));
    // }

    public bool IsEntry { get; set; }
    
    public float? Grad
    {
        get { return _schwierigkeitsgradModel.Grad; }
        set
        {
            _schwierigkeitsgradModel.Grad = value;
            OnPropertyChanged(nameof(Grad));
        }
    }

    public string Beschreibung
    {
        get { return _schwierigkeitsgradModel.Beschreibung; }
        set
        {
            _schwierigkeitsgradModel.Beschreibung = value;
            OnPropertyChanged(Beschreibung);
        }
    }
    
    public bool IsValid => Grad is not null;

    public bool IsEmpty => Grad is null && Beschreibung.Equals("");
    
    private SchwierigkeitsgradModel _schwierigkeitsgradModel { get; set; }

    public SchwierigkeitsgradViewModel(SchwierigkeitsgradModel schwierigkeitsgradModel, bool isEntry = false)
    {
        _schwierigkeitsgradModel = schwierigkeitsgradModel;
        IsEntry = isEntry;
    }

    public SchwierigkeitsgradModel GetModel()
    {
        return _schwierigkeitsgradModel;
    }
    
    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}