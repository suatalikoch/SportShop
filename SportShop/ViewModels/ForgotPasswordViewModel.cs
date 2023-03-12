using SportShop.Commands;
using SportShop.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    internal class ForgotPasswordViewModel : BaseViewModel
    {
        public ICommand NavigateRegisterCommand { get; }
        public ForgotPasswordViewModel(NavigationStore navigationStore)
        {
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore));
        }
    
    }
}
