using Business;
using Data.Models;
using SportShop.Commands;
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

        private readonly ObservableCollection<Product> _products;

        public IEnumerable<Product> Products => _products;

        public HomeViewModel()
        {
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(() => new AccountViewModel());
            NavigateFavouriteCommand = new NavigateCommand<FavouriteViewModel>(() => new FavouriteViewModel());
            NavigateCartCommand = new NavigateCommand<CartViewModel>(() => new CartViewModel());

            _products = new ObservableCollection<Product>(new ProductBusiness().GetAll());
        }
    }
}
