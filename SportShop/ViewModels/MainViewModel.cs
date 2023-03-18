using SportShop.Commands;
using SportShop.Stores;
using System.Drawing;
using System.Windows;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public Color BorderColor { get; set; }
        public string MaximizeContent { get; set; }
        public ICommand MinimizeCommand { get; }
        public ICommand MaximizeCommand { get; }
        public ICommand CloseCommand { get; }

        private NavigationStore _navigationStore;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            MinimizeCommand = new RelayCommand(ExecuteMinimizeCommand);
            MaximizeCommand = new RelayCommand(ExecuteMaximizeCommand);
            CloseCommand = new RelayCommand(ExecuteCloseCommand);

            BorderColor = Color.Black;
            MaximizeContent = "\xE739";
            OnPropertyChanged(nameof(MaximizeContent));
            _navigationStore = navigationStore;
        }

        private void ExecuteMinimizeCommand(object obj)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ExecuteMaximizeCommand(object obj)
        {
            SwitchWindowState();
        }

        private void ExecuteCloseCommand(object obj)
        {
            Application.Current.MainWindow.Close();
        }

        private void SwitchWindowState()
        {
            switch (Application.Current.MainWindow.WindowState)
            {
                case WindowState.Normal:
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    MaximizeContent = "\xE923";
                    OnPropertyChanged(nameof(MaximizeContent));
                    break;
                case WindowState.Maximized:
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                    MaximizeContent = "\xE739";
                    OnPropertyChanged(nameof(MaximizeContent));
                    break;
                default:
                    break;
            }
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel; 
    }
}
