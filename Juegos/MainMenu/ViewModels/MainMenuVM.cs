using System;
using System.Collections.Generic;
using Core.Utilities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MainMenu.ViewModels
{
    internal class MainMenuVM : BaseViewModel
    {
        public ICommand PuzzleGridCommand { get; }
        public ICommand BuscaminasCommand { get; }
        public ICommand ExitCommand { get; }

        public MainMenuVM(Action<object> navigate)
        {
            PuzzleGridCommand = new RelayCommand(_ => navigate(new Buscaminas.ViewModels.MainMenuVM(navigate)));
            BuscaminasCommand = new RelayCommand(_ => navigate(new Buscaminas.ViewModels.MainMenuVM(navigate)));
            ExitCommand = new RelayCommand(_ => Application.Current.Shutdown());
        }

    }
}
