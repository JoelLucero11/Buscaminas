using Buscaminas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Buscaminas.ViewModels
{
    internal class SettingsVM : BaseViewModel
    {
        public ICommand BackCommand { get; }
        public SettingsVM(Action<object> navigate)
        {
            BackCommand = new RelayCommand(_ => navigate(new MainMenuVM(navigate)));
        }
    }
}
