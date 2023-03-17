using SportShop.Stores;
using SportShop.ViewModels;
using System;

namespace SportShop.Commands
{
    internal class NavigateCommand<TViewModel> : RelayCommand
        where TViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;

        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
