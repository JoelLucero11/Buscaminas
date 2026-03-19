using Buscaminas.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Buscaminas.ViewModels
{
    internal class HowToPlayVM : BaseViewModel
    {
        public HowToPlayVM(Action<object> navigate) 
        {
                BackCommand = new RelayCommand(_ => navigate(new MainMenuVM(navigate)));

        }

        public ICommand BackCommand { get; }
    }
}
