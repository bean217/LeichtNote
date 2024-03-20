using System.ComponentModel;
using LeichtNote.Models.SettingsModels;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class MandantViewModel : INotifyPropertyChanged
{
    #region Static Properties

    
    
    #endregion

    #region ViewModel-Only Properties
    
    
    
    #endregion

    #region Model-Shared Properties

    // string indicating the Mandant's set name
    public string Name
    {
        get { return _mandantModel.Name; }
        set
        {
            _mandantModel.Name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    

    #endregion
    
    #region Model
    
    private MandantModel _mandantModel { get; set; }
    
    #endregion
    
    public MandantViewModel(MandantModel mandantModel)
    {
        _mandantModel = mandantModel;
    }
    
    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}