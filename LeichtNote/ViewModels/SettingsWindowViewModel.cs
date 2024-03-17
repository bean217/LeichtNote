using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using DynamicData;
using LeichtNote.Models;
using LeichtNote.Models.SettingsModels;
using LeichtNote.ViewModels.SettingsViewModels;
using ReactiveUI;

namespace LeichtNote.ViewModels;

public class SettingsWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    #region ViewLabels

    public string FreifelderLabel =>
        "Hier können Sie fünf Felder beliebig frei definieren. " +
        "Wählen Sie, welche Freifelder Sie verwenden möchten " +
        "und geben Sie eine Bezeichnung ein.";
    
    public string LagerLabel =>
    "Hier können Sie wählen, welche Lagerplätze Sie verwenden " +
    "möchten.\nAußerdem können Sie die Bezeichnungen für Ihr " +
    "Lager eingeben.\n(z.B. Regal / Fach / Ordner /Schrank etc.)";
    
    public string SchwierigkeitsgradeFooter => "Zum Bearbeiten \"Doppelklick\"";

    #endregion
    
    #region Settings Models
    
    private SettingsModel SettingsModel { get; }
    
    #endregion
    
    #region Settings ViewModels
    
    public ObservableCollection<SpalteViewModel> Spalten { get; set; }

    private IEnumerable<SchwierigkeitsgradViewModel> _schwierigkeiten { get; set; }
    public IEnumerable<SchwierigkeitsgradViewModel> Schwierigkeiten
    {
        get { return _schwierigkeiten; }
        set
        {
            // set collection (sorted by ascending Grad values)
            _schwierigkeiten = SortSchwierigkeiten(value);
            // modify actual data
            SettingsModel.Schwierigkeitsgrade = _schwierigkeiten
                    .Where(x => !x.IsEmpty)
                    .Select(x => x.GetModel());
            // notify the UI
            OnPropertyChanged(nameof(Schwierigkeiten));

        }
    }
    public ObservableCollection<FreifeldViewModel> Freifelder { get; set; }
    public ObservableCollection<LagerViewModel> Lager { get; set; }

    public bool AllesSpaltenUmschalten
    {
        get { return SettingsModel.AllesSpaltenUmschalten; }
        set
        {
            SettingsModel.AllesSpaltenUmschalten = value;
            foreach (var s in Spalten)
            {
                s.Enabled = value;
            }

            foreach (var s in Freifelder)
            {
                s.Enabled = value;
            }

            foreach (var s in Lager)
            {
                s.Enabled = value;
            }
            OnPropertyChanged(nameof(AllesSpaltenUmschalten));
        }
    }
    
    #endregion
    
    #region SettingsWindow Child ViewModels

    public PersoenlicheAngebenViewModel PersoenlicheAngebenViewModel { get; }
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
        DatenimportViewModel = new DatenimportViewModel(SettingsModel);

        #endregion
        
        #region ViewModel Initialization
        
        var schwierigkeiten = new List<SchwierigkeitsgradViewModel>();
        foreach (var skm in SettingsModel.Schwierigkeitsgrade)
        {
            schwierigkeiten.Add(new SchwierigkeitsgradViewModel(skm));
        }
        Schwierigkeiten =
            schwierigkeiten.Append(
                new SchwierigkeitsgradViewModel(
                    new SchwierigkeitsgradModel(), 
                    isEntry: true)
                );
        
        Spalten = new ObservableCollection<SpalteViewModel>();
        foreach (var sm in SettingsModel.Spalten)
        {
            Spalten.Add(new SpalteViewModel(sm, this));
        }
        Freifelder = new ObservableCollection<FreifeldViewModel>();
        foreach (var fm in SettingsModel.Freifelder)
        {
            Freifelder.Add(new FreifeldViewModel(fm, this));
        }
        Lager = new ObservableCollection<LagerViewModel>();
        foreach (var lm in SettingsModel.Lager)
        {
            Lager.Add(new LagerViewModel(lm, this));
        }

        AllesSpaltenUmschalten = SettingsModel.AllesSpaltenUmschalten;
        #endregion
        
        #region Settings Commands

        CloseSettingsCommand = ReactiveCommand.Create(() => default(SettingsModel));
        SaveAndCloseSettingsCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await SettingsModel.SaveAsync();
            return SettingsModel;
        });

        #endregion
    }




    public void HandleCellEditEnded(DataGridCellEditEndedEventArgs e)
    {
        // cell view data
        if (e.Row.DataContext is SchwierigkeitsgradViewModel row)
        {
            if (row.IsEntry) // is the entry field row
            {
                // if the new row becomes non-empty
                if (!row.IsEmpty)
                {
                    // then declare it non-entry
                    row.IsEntry = false;
                    // sort and add a new entry row
                    Schwierigkeiten =
                        Schwierigkeiten.Append(
                            new SchwierigkeitsgradViewModel(
                                new SchwierigkeitsgradModel(),
                                isEntry: true)
                        );
                }
                else
                {
                    // entry row is empty
                    // since it is an entry row, ignore
                }
            }
            else // is a pre-existing schwierigkeit
            {
                // if the current non-entry row becomes empty
                if (row.IsEmpty)
                {
                    // remove it
                    Schwierigkeiten =
                        Schwierigkeiten.Except(
                            Schwierigkeiten.Where(x => x.Equals(row))
                        );
                }
                else
                {
                    // the current non-entry row is non-empty
                    // resort it in the event it was changed
                    Schwierigkeiten = Schwierigkeiten;
                }
            }
        }
    }
    
    public void HandleCellEditEnding(DataGridCellEditEndingEventArgs e)
    {
        // cell view data
        if (e.EditingElement is TextBox cell)
        {
            // get its viewmodel
            var columnName = e.Column.Header;
            var data = (SchwierigkeitsgradViewModel)e.Row.DataContext!;

            if (columnName.Equals(nameof(SchwierigkeitsgradViewModel.Grad)))
            {
                // if the input valid already exists as a grad, then increment it to a unique value
                float gradVal;
                while (float.TryParse(cell.Text, out gradVal) && 
                       Schwierigkeiten
                           .Where((x, i) => !x.Equals(data))
                           .Any(x => x.Grad != null && Equals(x.Grad, gradVal)))
                {
                    cell.Text = String.Format("{0:0.0}", gradVal + 0.1);
                }
            }
        }
    }
    
    private static IEnumerable<SchwierigkeitsgradViewModel> SortSchwierigkeiten(IEnumerable<SchwierigkeitsgradViewModel> schwierigkeiten)
    {
        var schwierigkeitsgradViewModels = schwierigkeiten.ToList();
        var entryRow = schwierigkeitsgradViewModels           // the entry row
            .Where(x => x.IsEntry);
        var invalidRows = schwierigkeitsgradViewModels  // rows without a grad
            .Where(x => !x.IsValid && !x.IsEntry)
            .OrderBy(x => x.Beschreibung);                              // sorted by beschreibung
        var validRows = schwierigkeitsgradViewModels    // rows with a grad
            .Where(x => x.IsValid)
            .OrderBy(x => x.Grad);                                      // sorted by grad
        return validRows.Concat(invalidRows).Concat(entryRow);
    }



    /// <summary>
    /// Checks whether AllesSpaltenUmschalten should be toggled based on the enabled states
    /// of all spalten in spaltenansicht.
    /// </summary>
    public void CheckSpaltenUpdate()
    {
        var allChecked = Spalten.Select(x => x.Enabled).All(x => x) &&
                         Freifelder.Select(x => x.Enabled).All(x => x) &&
                         Lager.Select(x => x.Enabled).All(x => x);
        if (AllesSpaltenUmschalten && !allChecked)
        {
            SettingsModel.AllesSpaltenUmschalten = false;
            OnPropertyChanged(nameof(AllesSpaltenUmschalten));
        }
        else if (!AllesSpaltenUmschalten && allChecked)
        {
            SettingsModel.AllesSpaltenUmschalten = true;
            OnPropertyChanged(nameof(AllesSpaltenUmschalten));
        }
    }
    


    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}