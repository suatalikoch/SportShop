using SportShop.Commands;
using SportShop.Stores;
using System.Threading;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public ICommand LogOutCommand { get; }
        public ICommand NavigateEditPasswordCommand { get; }

        private readonly NavigationStore _navigationStoreOuter;

        public AccountViewModel(NavigationStore navigationStoreOuter)
        {
            _navigationStoreOuter = navigationStoreOuter;

            LogOutCommand = new RelayCommand(ExecuteLogOutCommand);
            NavigateEditPasswordCommand = new NavigateCommand<EditPasswordViewModel>(navigationStoreOuter, () => new EditPasswordViewModel()); 
        }

        private void ExecuteLogOutCommand(object obj)
        {
            Thread.CurrentPrincipal = null;

            _navigationStoreOuter.CurrentViewModel = new LoginViewModel(_navigationStoreOuter);
        }
    }
}
