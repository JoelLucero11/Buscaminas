using Buscaminas.Models;
using Buscaminas.Utilities;
using Buscaminas.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Input;
using System.Windows.Threading;

namespace Buscaminas.ViewModels
{
    internal class GameVM : BaseViewModel
    {

        private readonly CellModel _cell;
        private readonly GameModel _game;
        private readonly bool _win;
        private bool _lost;

        public ObservableCollection<CellModel> Cells { get; }
        public int Row { get; }
        public int Column { get; }

        public GameVM(string difficulty)
        {
            _game = new GameModel();
            _game.StartGame(difficulty);
            Column = _game.Columns;
            Row = _game.Rows;
            Cells = new ObservableCollection<CellModel>();
            BuildCellViewModels();
            StartTimer();
            RightClickCommand = new RelayCommand(_ => IsFlagged = !IsFlagged);
            LeftClickCommand = new RelayCommand(_ => IsRevealed = !IsRevealed);
        }

        public ICommand RightClickCommand { get; }

        public ICommand LeftClickCommand { get; }

        private void BuildCellViewModels()
        {
            Cells.Clear();

            for (int i = 0; i < _game.Rows; i++)
                for (int j = 0; j < _game.Columns; j++)
                    Cells.Add(_cell);
        }

        public bool IsMine
        {
            get => _cell.IsMine;
            set { if (_cell.IsMine == value) return; _cell.IsMine = value; OnPropertyChanged(); }
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

        public string DisplayText
        {
            get
            {
                if (!IsRevealed && IsFlagged) return "a";
                if (!IsRevealed) return "b";
                if (AdjacentMines > 0) return AdjacentMines.ToString();
                return string.Empty;
            }
        }

        /*private void RevealAllMines()
        {
            foreach (var cell in Cells)
            {
                if (cell.IsMine)
                    cell.IsRevealed = true;
            }
        }*/

        private DispatcherTimer _timer;
        private TimeSpan _elapsed;

        public string ElapsedTime => _elapsed.ToString(@"mm\:ss");

        public void StartTimer()
        {
            _elapsed = TimeSpan.Zero;
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (s, e) =>
            {
                _elapsed = _elapsed.Add(TimeSpan.FromSeconds(1));
                OnPropertyChanged(nameof(ElapsedTime));
            };
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer?.Stop();
        }
    }

}


