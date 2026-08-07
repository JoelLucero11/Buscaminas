using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainMenu.ViewModels
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
            Action<object>? navigate = null;
                
                navigate = vm =>
            {
                if (vm is string s && s == "MainMenu")
                {
                    CurrentView = new MainMenuVM(navigate!);
                }
                else
                {
                    CurrentView = vm;
                }
            };

            // Inicializar con el menú principal
            CurrentView = new WelcomeVM(navigate);
        }

    }
}
