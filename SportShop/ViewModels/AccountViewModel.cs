using SportShop.Commands;
using SportShop.Stores;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public ICommand LogOutCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public AccountViewModel()
        {
            LogOutCommand = new RelayCommand(ExecuteLogOutCommand, CanExecuteLogOutCommand);
            NavigateBackCommand = new NavigateCommand<HomeViewModel>(() => new HomeViewModel());
        }

        private void ExecuteLogOutCommand(object obj)
        {
            NavigationStore.CurrentViewModel = new LoginViewModel();
        }

        private bool CanExecuteLogOutCommand(object obj)
        {
            return true;
        }
    }
}
