using SportShop.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public BaseViewModel CurrentViewModel => NavigationStore.CurrentViewModel; 
    }
}
