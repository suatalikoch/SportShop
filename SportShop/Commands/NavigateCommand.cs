using SportShop.Stores;
using SportShop.ViewModels;
using System;

namespace SportShop.Commands
{
    internal class NavigateCommand<TViewModel> : ViewModelCommand
        where TViewModel : BaseViewModel
    {
        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(Func<TViewModel> createViewModel)
        {
            _createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            NavigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
