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

        private readonly NavigationStore _navigationStore;

        public ForgotPasswordViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            RecoverPasswordCommand = new RelayCommand(ExecuteRecoverPasswordCommand, CanExecuteRecoverPasswordCommand);
            NavigateBackCommand = new NavigateCommand<LoginViewModel>(navigationStore , () => new LoginViewModel(navigationStore));
        }

        private void ExecuteRecoverPasswordCommand(object obj)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        private bool CanExecuteRecoverPasswordCommand(object obj)
        {
            return true;
        }
    }
}
