using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Buscaminas.Utilities;

namespace Buscaminas.ViewModels
{
    internal class WelcomeVM : BaseViewModel
    {
        public ICommand StartCommand { get; }

        public WelcomeVM(Action<object> navigate)
        {
            StartCommand = new RelayCommand(_ => navigate(new MainMenuVM(navigate)));
        }

    }
}
