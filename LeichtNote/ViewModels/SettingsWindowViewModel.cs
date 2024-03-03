using System;
using LeichtNote.ViewModels.SettingsViewModels;

namespace LeichtNote.ViewModels;

public class SettingsWindowViewModel : ViewModelBase
{
    #region SettingsWindow Child ViewModels

    public PersoenlicheAngebenViewModel PersoenlicheAngebenViewModel { get; }
    public SchwierigkeitsgradeViewModel SchwierigkeitsgradeViewModel { get; }
    public FreifelderViewModel FreifelderViewModel { get; }
    public LagerViewModel LagerViewModel { get; }
    public SpaltenansichtViewModel SpaltenansichtViewModel { get; }
    public DatenimportViewModel DatenimportViewModel { get; }

    #endregion

    public SettingsWindowViewModel()
    {
        #region SettingsWindow Initialization

        PersoenlicheAngebenViewModel = new PersoenlicheAngebenViewModel();
        SchwierigkeitsgradeViewModel = new SchwierigkeitsgradeViewModel();
        FreifelderViewModel = new FreifelderViewModel();
        LagerViewModel = new LagerViewModel();
        SpaltenansichtViewModel = new SpaltenansichtViewModel();
        DatenimportViewModel = new DatenimportViewModel();

        #endregion
    }
}