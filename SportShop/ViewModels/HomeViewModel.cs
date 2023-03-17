using Business;
using Data.Models;
using SportShop.Commands;
using SportShop.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateFavouriteCommand { get; }
        public ICommand NavigateCartCommand { get; }
        public ICommand NavigateProductsCommand { get; }

        private NavigationStore _navigationStoreInner;

        public HomeViewModel(NavigationStore navigationStore)
        {
            _navigationStoreInner = new NavigationStore();
            _navigationStoreInner.CurrentViewModel = new ProductsViewModel();

            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(_navigationStoreInner, () => new AccountViewModel(navigationStore));
            NavigateFavouriteCommand = new NavigateCommand<FavouriteViewModel>(_navigationStoreInner, () => new FavouriteViewModel());
            NavigateCartCommand = new NavigateCommand<CartViewModel>(_navigationStoreInner, () => new CartViewModel());
            NavigateProductsCommand = new NavigateCommand<ProductsViewModel>(_navigationStoreInner, () => new ProductsViewModel());
        }

        public BaseViewModel CurrentViewModel => _navigationStoreInner.CurrentViewModel;
    }
}
