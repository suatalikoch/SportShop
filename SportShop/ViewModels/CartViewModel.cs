using Business;
using Data.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace SportShop.ViewModels
{
    class CartViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Product> _products;

        public IEnumerable<Product> Products => _products;

        public CartViewModel()
        {
            _products = new ObservableCollection<Product>(new ProductController().GetCartProducts(new UserController().GetByEmail(Thread.CurrentPrincipal.Identity.Name).Id));
        }
    }
}
