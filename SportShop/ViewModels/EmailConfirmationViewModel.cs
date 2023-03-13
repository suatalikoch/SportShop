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
    public class EmailConfirmationViewModel : BaseViewModel
    {
        public ICommand NavigateRegisterCommand { get; }

        public EmailConfirmationViewModel()
        {
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(() => new RegisterViewModel());
        }
    }
}
