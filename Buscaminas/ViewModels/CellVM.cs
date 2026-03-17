using Buscaminas.Models;
using Buscaminas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Buscaminas.ViewModels
{
    internal class CellVM : BaseViewModel
    {
        private readonly CellModel _cell;

        public int Row { get; }
        public int Column { get; }

        public CellVM(CellModel cell, int row, int column)
        {
            _cell = cell ?? throw new ArgumentNullException(nameof(cell));
            Row = row;
            Column = column;
        }

        // Propiedades que reflejan el estado de la celda y notifican cambios para actualizar la UI
        public bool IsMine
        {
            get => _cell.IsMine;
            set 
            { 
                if (_cell.IsMine == value) return; 
                _cell.IsMine = value; 
                OnPropertyChanged(); 
            }
        }

        public bool IsRevealed
        {
            get => _cell.IsRevealed;
            set
            {
                if (_cell.IsRevealed == value) return;
                _cell.IsRevealed = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayText));
                OnPropertyChanged(nameof(ShowMine));
            }
        }

        public bool IsFlagged
        {
            get => _cell.IsFlagged;
            set
            {
                if (_cell.IsFlagged == value) return;
                _cell.IsFlagged = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public int AdjacentMines
        {
            get => _cell.AdjacentMines;
            set
            {
                if (_cell.AdjacentMines == value) return;
                _cell.AdjacentMines = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        // Propiedad calculada para mostrar el texto correcto según el estado de la celda
        public string DisplayText
        {
            get
            {
                if (IsFlagged == true && IsRevealed == false) return "F";
                else if (IsRevealed == true && IsMine == true) return "*";
                else if (IsRevealed == true && IsMine == false) return AdjacentMines > 0 ? AdjacentMines.ToString() : string.Empty;   
                else return string.Empty;
            }
        }
        public bool ShowMine => IsRevealed && IsMine;

        public void ForceSync()
        {
            OnPropertyChanged(nameof(IsRevealed));
            OnPropertyChanged(nameof(DisplayText));
            OnPropertyChanged(nameof(ShowMine));
        }
    }
}

