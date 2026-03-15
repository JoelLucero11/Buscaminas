using Buscaminas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Buscaminas.ViewModels
{
    internal class MainMenuVM : BaseViewModel
    {
        public ICommand GameCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand ExitCommand { get; }

        public MainMenuVM(Action<object> navigate)
        {
            GameCommand = new RelayCommand(_ => navigate(new DifficultySelectionVM(navigate)));
            SettingsCommand = new RelayCommand(_ => navigate(new SettingsVM(navigate)));
            ExitCommand = new RelayCommand(_ => Application.Current.Shutdown());
        }

    }
}
