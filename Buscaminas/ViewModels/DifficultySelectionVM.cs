using Buscaminas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Buscaminas.ViewModels
{
    class DifficultySelectionVM : BaseViewModel
    {
        private string? _selectedDifficulty;
        public string? SelectedDifficulty
        {
            get => _selectedDifficulty;
            set
            {
                _selectedDifficulty = value;
                OnPropertyChanged();
            }
        }

        public ICommand EasyCommand { get; }
        public ICommand MediumCommand { get; }
        public ICommand HardCommand { get; }

        public ICommand BackCommand { get; }

        public DifficultySelectionVM(Action<object> navigate)
        {
            EasyCommand = new RelayCommand(_ => navigate(new GameVM("easy")));
            MediumCommand = new RelayCommand(_ => navigate(new GameVM("medium")));
            HardCommand = new RelayCommand(_ => navigate(new GameVM("hard")));

            BackCommand = new RelayCommand(_ => navigate(new MainMenuVM(navigate)));
        }

    }
}
