using SportShop.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.ViewModels
{
    class ProductViewModel : BaseViewModel
    {
        public string Testak { get; set; }
        public string Test { get; set; }

        public ProductViewModel(string testak, string test)
        {
            Testak = testak;
            Test = test;
        }
    }
}
