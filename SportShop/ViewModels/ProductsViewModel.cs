using Business;
using Data.Models;
using SportShop.Commands;
using SportShop.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    internal class ProductsViewModel : BaseViewModel
    {
        public ICommand NavigateProductCommand { get; }

        private readonly ObservableCollection<Product> _products;
        public IEnumerable<Product> Products => _products;

        public ProductsViewModel(NavigationStore navigationStore)
        {
            _products = new ObservableCollection<Product>(new ProductBusiness().GetAll());

            NavigateProductCommand = new NavigateCommand<ProductViewModel>(navigationStore, () => new ProductViewModel());
        }
    }
}
