using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportShop.ViewModels
{
    class CartViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Product> _products;

        public IEnumerable<Product> Products => _products;

        public CartViewModel()
        {
            _products = new ObservableCollection<Product>(new ProductBusiness().GetCartProducts(new UserBusiness().GetByEmail(Thread.CurrentPrincipal.Identity.Name).Id));
        }
    }
}
