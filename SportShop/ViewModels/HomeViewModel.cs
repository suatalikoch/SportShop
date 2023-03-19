using SportShop.Commands;
using SportShop.Stores;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public string SearchText { get; set; }
        
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateFavouriteCommand { get; }
        public ICommand NavigateCartCommand { get; }
        public ICommand NavigateProductsCommand { get; }

        private readonly NavigationStore _navigationStoreInner;

        public HomeViewModel(NavigationStore navigationStore)
        {
            _navigationStoreInner = new NavigationStore
            {
                CurrentViewModel = new ProductsViewModel()
            };

            _navigationStoreInner.CurrentViewModelChanged += OnCurrentViewModelChanged;

            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(_navigationStoreInner, () => new AccountViewModel(navigationStore));
            NavigateFavouriteCommand = new NavigateCommand<FavouriteViewModel>(_navigationStoreInner, () => new FavouriteViewModel());
            NavigateCartCommand = new NavigateCommand<CartViewModel>(_navigationStoreInner, () => new CartViewModel());
            NavigateProductsCommand = new NavigateCommand<ProductsViewModel>(_navigationStoreInner, () => new ProductsViewModel());
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public BaseViewModel CurrentViewModel => _navigationStoreInner.CurrentViewModel;
    }
}
