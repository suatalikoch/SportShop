using SportShop.Commands;
using SportShop.Stores;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand NavigateRegisterCommand { get; }
        public ICommand NavigateHomeCommand { get; }

        public ICommand NavigateForgotPasswordCommand { get; }


        public LoginViewModel(NavigationStore navigationStore)
        {
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore));
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
            NavigateForgotPasswordCommand=new NavigateCommand<ForgotPasswordViewModel>(navigationStore, () => new ForgotPasswordViewModel(navigationStore));
        }
    }
}
