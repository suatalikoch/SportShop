using Business;
using Data.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace SportShop.ViewModels
{
    public class FavouriteViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Product> _products;

        public IEnumerable<Product> Products => _products;

        public FavouriteViewModel()
        {
            _products = new ObservableCollection<Product>(new ProductController().GetFavouriteProducts(new UserController().GetByEmail(Thread.CurrentPrincipal.Identity.Name).Id));
        }
    }
}
