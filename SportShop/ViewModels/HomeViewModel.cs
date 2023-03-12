using SportShop.Commands;
using SportShop.Stores;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
    }
}
