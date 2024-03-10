using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using LeichtNote.Models;
using LeichtNote.Models.SettingsModels.SchwierigkeitsgradeModels;
using ReactiveUI;

namespace LeichtNote.ViewModels.SettingsViewModels;

public class SchwierigkeitsgradeViewModel : INotifyPropertyChanged
{
    public SettingsModel SettingsModel { get; set; }

    // TODO: DataGridView is broken for ObservableCollection, so implement INotifyPropertyChanged instead
    private IEnumerable<SchwierigkeitsgradModel> _viewSchwierigkeiten { get; set; }
    public IEnumerable<SchwierigkeitsgradModel> Schwierigkeiten
    {
        get
        {
            return _viewSchwierigkeiten;
        }
        set
        {
            // set view collection
            _viewSchwierigkeiten = value;
            // modify actual data
            SettingsModel.Schwierigkeitsgrade = _viewSchwierigkeiten.Where(x => x.IsValid());
            OnPropertyChanged(nameof(Schwierigkeiten));
        }
    }
    
    public SchwierigkeitsgradeViewModel(SettingsModel settingsModel)
    {
        SettingsModel = settingsModel;
        _viewSchwierigkeiten = (new List<SchwierigkeitsgradModel>(SettingsModel.Schwierigkeitsgrade))
            .Append(new SchwierigkeitsgradModel()
            {
                Grad = null,
                Beschreibung = null
            });
    }
    
    public void HandleCellEditEnded(DataGridCellEditEndedEventArgs e)
    {
        // cell view data
        if (e.Row is { } row)
        {
            // if modified row becomes empty and is not the last row, then remove it from _viewSchwierigkeiten
            int index = row.GetIndex();
            // the modified row is not the last row
            if (index != _viewSchwierigkeiten.Count() - 1)
            {
                // if modified row becomes empty, then remove it from _viewSchwierigkeiten
                if (row.DataContext is SchwierigkeitsgradModel data && data.IsEmpty() )
                {
                    var newVals = _viewSchwierigkeiten.Where((val, ind) => ind != index);
                    Schwierigkeiten = newVals;
                }
            }
            // the modified row is the last row
            else
            {
                // if the last row becomes non-empty, then add a new row
                if (row.DataContext is SchwierigkeitsgradModel data && !data.IsEmpty())
                {
                    var newVals = _viewSchwierigkeiten.Append(new SchwierigkeitsgradModel()
                    {
                        Grad = null,
                        Beschreibung = null
                    });
                    Schwierigkeiten = newVals;
                }
            }
        }
    }

    public void HandleCellEditEnding(DataGridCellEditEndingEventArgs e)
    {
        // cell view data
        if (e.EditingElement is TextBox cellContent)
        {
            // model data bound to the cell
            var columnName = e.Column.Header;
            var data = (SchwierigkeitsgradModel)e.Row.DataContext!;
        
            if (columnName.Equals(nameof(SchwierigkeitsgradModel.Grad)))
            {
                // if the input value already exists as a grad, then increment it to a unique value
                float gradVal;
                while (float.TryParse(cellContent.Text, out gradVal) && _viewSchwierigkeiten.Any(x =>
                    {
                        return x.Grad != null && Equals(x.Grad, gradVal);
                    }))
                {
                    cellContent.Text = $"{gradVal + 0.1}";
                }
            }
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