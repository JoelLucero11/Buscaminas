using Buscaminas.Models;
using Core.Utilities;
using Buscaminas.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Buscaminas.ViewModels
{
    public class GameVM : BaseViewModel
    {
        private readonly GameModel _game;
        private readonly Action<object> _navigate;
        private bool _lost;
        private bool _won;

        // ── Timer ───
        private DispatcherTimer? _timer;
        private TimeSpan _elapsed;

        public string ElapsedTime => _elapsed.ToString(@"mm\:ss");

        // ── Constructor ───
        public GameVM(string difficulty, Action<object> navigate)
        {
            _navigate = navigate;
            _game = new GameModel();
            _game.StartGame(difficulty);
            _lost = false;
            _won = false;
            StatusMessage = string.Empty;
            Cells = new ObservableCollection<CellVM>();
            BuildCellViewModels();
            StartTimer();

            RevealCommand = new RelayCommand(obj => RevealCell(obj as CellVM));
            FlagCommand = new RelayCommand(obj => ToggleFlag(obj as CellVM));
            BackCommand = new RelayCommand(_ => { StopTimer(); _navigate(new MainMenuVM(_navigate)); });
            RestartCommand = new RelayCommand(_ =>
            {
                StopTimer();
                _game.StartGame(difficulty);
                _lost = false;
                _won = false;
                StatusMessage = string.Empty;
                BuildCellViewModels();
                StartTimer();
            });

        }

        //── Propiedades ───
        public ObservableCollection<CellVM> Cells { get; }

        private string _statusMessage;
        public string StatusMessage
        {
            get => _statusMessage;
            private set 
            { 
                _statusMessage = value; 
                OnPropertyChanged();
            }
        }

        public int Rows => _game.Rows;
        public int Columns => _game.Columns;

        public bool GameOver => _won || _lost;


        // ── Comandos ───
        public ICommand RevealCommand { get; }
        public ICommand FlagCommand { get; }
        public ICommand RestartCommand { get; }
        public ICommand BackCommand { get; }

        // ── Métodos privados ───
        private void BuildCellViewModels()
        {
            Cells.Clear();
            for (int i = 0; i < _game.Rows; i++)
                for (int j = 0; j < _game.Columns; j++)
                    Cells.Add(new CellVM(_game.Cells[i, j], i, j));
        }

        private void RevealCell(CellVM? cellVM)
        {
            if (cellVM == null || GameOver) return;
            if (cellVM.IsFlagged) return;
            if (cellVM.IsRevealed) return;

            if (cellVM.IsMine)
            {
                cellVM.IsRevealed = true;
                _lost = true;
                StopTimer();
                StatusMessage = "¡Oh, no! ¡Has perdido! 💣";
                RevealAllMines();
                return;
            }

            _game.RevealCell(cellVM.Row, cellVM.Column);
            SyncCellStates();

            if (_game.CheckVictory())
            {
                _won = true;
                StatusMessage = "¡Felicidades, ganaste! 🎉";
                StopTimer();
            }
        }

        private void ToggleFlag(CellVM? cellVM)
        {
            if (cellVM == null || GameOver) return;
            if (cellVM.IsRevealed) return;
            cellVM.IsFlagged = !cellVM.IsFlagged;
        }

        private void SyncCellStates()
        {
            foreach (var cellVM in Cells)
            {
                if (_game.Cells[cellVM.Row, cellVM.Column].IsRevealed)
                    cellVM.SyncCells();
            }
        }

        private void RevealAllMines()
        {
            foreach (var cellVM in Cells)
                if (cellVM.IsMine)
                    cellVM.IsRevealed = true;
        }

        private void StartTimer()
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
        private void StopTimer() => _timer?.Stop();

    }
}




