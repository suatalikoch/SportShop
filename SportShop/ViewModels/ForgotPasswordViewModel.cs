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
    public class ForgotPasswordViewModel : BaseViewModel
    {
        public ICommand RecoverPasswordCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public ForgotPasswordViewModel()
        {
            RecoverPasswordCommand = new ViewModelCommand(ExecuteRecoverPasswordCommand, CanExecuteRecoverPasswordCommand);
            NavigateBackCommand = new NavigateCommand<LoginViewModel>(() => new LoginViewModel());
        }

        private void ExecuteRecoverPasswordCommand(object obj)
        {
            NavigationStore.CurrentViewModel = new HomeViewModel();
        }

        private bool CanExecuteRecoverPasswordCommand(object obj)
        {
            return true;
        }
    }
}
