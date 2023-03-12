using SportShop.Commands;
using SportShop.Stores;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateEmailConfirmationCommand { get; }

        public RegisterViewModel(NavigationStore navigationStore)
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            NavigateEmailConfirmationCommand = new NavigateCommand<EmailConfirmationViewModel>(navigationStore, () => new EmailConfirmationViewModel(navigationStore));
        }
    }
}
