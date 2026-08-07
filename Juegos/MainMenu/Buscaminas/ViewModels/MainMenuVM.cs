using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Buscaminas.ViewModels
{
    public class MainMenuVM : BaseViewModel
    {
        public ICommand GameCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand HowToPlayCommand { get; }

        public MainMenuVM(Action<object> navigate)
        {
            GameCommand = new RelayCommand(_ => navigate(new DifficultySelectionVM(navigate)));
            BackCommand = new RelayCommand(_ => navigate("MainMenu"));
            HowToPlayCommand = new RelayCommand(_ => navigate(new HowToPlayVM(navigate)));
        }

    }
}
