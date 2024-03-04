
using System.Reactive;
using LeichtNote.Models;
using LeichtNote.ViewModels.SettingsViewModels;
using ReactiveUI;

namespace LeichtNote.ViewModels;

public class SettingsWindowViewModel : ViewModelBase
{
    #region Settings Properties
    
    private SettingsModel SettingsModel { get; }
    
    #endregion
    
    #region SettingsWindow Child ViewModels

    public PersoenlicheAngebenViewModel PersoenlicheAngebenViewModel { get; }
    public SchwierigkeitsgradeViewModel SchwierigkeitsgradeViewModel { get; }
    public FreifelderViewModel FreifelderViewModel { get; }
    public LagerViewModel LagerViewModel { get; }
    public SpaltenansichtViewModel SpaltenansichtViewModel { get; }
    public DatenimportViewModel DatenimportViewModel { get; }

    #endregion

    #region Settings Commands

    public ReactiveCommand<Unit, SettingsModel?> CloseSettingsCommand { get; }
    public ReactiveCommand<Unit, SettingsModel> SaveAndCloseSettingsCommand { get; }
    
    #endregion

    public SettingsWindowViewModel()
    {
        #region SettingsWindow Initialization

        SettingsModel = new SettingsModel();

        PersoenlicheAngebenViewModel = new PersoenlicheAngebenViewModel(SettingsModel);
        SchwierigkeitsgradeViewModel = new SchwierigkeitsgradeViewModel(SettingsModel);
        FreifelderViewModel = new FreifelderViewModel(SettingsModel);
        LagerViewModel = new LagerViewModel(SettingsModel);
        SpaltenansichtViewModel = new SpaltenansichtViewModel(SettingsModel);
        DatenimportViewModel = new DatenimportViewModel(SettingsModel);

        #endregion

        #region Settings Commands

        CloseSettingsCommand = ReactiveCommand.Create(() => default(SettingsModel));
        SaveAndCloseSettingsCommand = ReactiveCommand.Create(() =>
        {
            SettingsModel.Save();
            return SettingsModel;
        });

        #endregion
    }
}