using SportShop.Stores;
using SportShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportShop.Commands
{
    internal class LoginCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public LoginCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (true)
            {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            }
        }
    }
}
