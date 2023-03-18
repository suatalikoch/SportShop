using SportShop.Commands;
using SportShop.Stores;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public ICommand LogOutCommand { get; }
        public ICommand NavigateBackCommand { get; }

        private NavigationStore _navigationStoreOuter;

        public AccountViewModel(NavigationStore navigationStoreOuter)
        {
            _navigationStoreOuter = navigationStoreOuter;

            LogOutCommand = new RelayCommand(ExecuteLogOutCommand, CanExecuteLogOutCommand);            
        }

        private void ExecuteLogOutCommand(object obj)
        {
            _navigationStoreOuter.CurrentViewModel = new LoginViewModel(_navigationStoreOuter);
        }

        private bool CanExecuteLogOutCommand(object obj)
        {
            return true;
        }
    }
}
