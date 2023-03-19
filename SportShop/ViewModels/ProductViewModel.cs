using Business;
using Data.Models;
using SportShop.Commands;
using SportShop.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    class ProductViewModel : BaseViewModel
    {
        public ICommand AddToCartCommand { get; }
        public ICommand FavouriteCommand { get; }

        public ProductViewModel()
        {
            AddToCartCommand = new RelayCommand(ExecuteAddToCartCommand);
            FavouriteCommand = new RelayCommand(ExecuteFavouriteCommand);
        }

        private void ExecuteAddToCartCommand(object obj)
        {
            UserBusiness userBusiness = new();
            CartBusiness cartBusiness = new();

            Cart cart = new()
            {
                UserId = userBusiness.GetByEmail(Thread.CurrentPrincipal.Identity.Name).Id,
                ProductId = 1
            };

            cartBusiness.Add(cart);
        }

        private void ExecuteFavouriteCommand(object obj)
        {
            UserBusiness userBusiness = new();
            FavouriteBusiness favouriteBusiness = new();

            Favourite favourite = new()
            {
                UserId = userBusiness.GetByEmail(Thread.CurrentPrincipal.Identity.Name).Id,
                ProductId = 1
            };

            favouriteBusiness.Add(favourite);
        }
    }
}
