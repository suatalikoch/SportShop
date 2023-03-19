using Business;
using Data.Models;
using SportShop.Commands;
using SportShop.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class FavouriteViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Product> _products;

        public IEnumerable<Product> Products => _products;

        public FavouriteViewModel()
        {
            _products = new ObservableCollection<Product>(new ProductBusiness().GetFavouriteProducts(new UserBusiness().GetByEmail(Thread.CurrentPrincipal.Identity.Name).Id));
        }
    }
}
