using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainMenu.ViewModels
{
        internal class WelcomeVM : BaseViewModel
    {
        public WelcomeVM(Action<object> navigate)
        {
            StartCommand = new RelayCommand(_ => navigate(new MainMenuVM(navigate)));
        }
        public ICommand StartCommand { get; }
    }
}
