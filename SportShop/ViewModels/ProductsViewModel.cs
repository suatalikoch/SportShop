using Business;
using Data.Models;
using SportShop.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.ViewModels
{
    internal class ProductsViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Product> _products;
        public IEnumerable<Product> Products => _products;

        public ProductsViewModel()
        {
            _products = new ObservableCollection<Product>(new ProductBusiness().GetAll());
        }
    }
}
