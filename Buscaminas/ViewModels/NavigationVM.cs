using Buscaminas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Buscaminas.ViewModels
{
    internal class NavigationVM : BaseViewModel
    {
        private object? _currentView;
        public object? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }

        }

        public NavigationVM()
        {
            Action<object> navigate = vm => CurrentView = vm;

            // Inicializar con el menú principal
            CurrentView = new WelcomeVM(navigate);
        }
    }
}
