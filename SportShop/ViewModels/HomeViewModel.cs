using SportShop.Commands;
using SportShop.Stores;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand NavigateAccountCommand { get; }

        public HomeViewModel()
        {
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(() => new AccountViewModel());
        }
    }
}
