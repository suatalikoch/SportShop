using Business;
using SportShop.Commands;
using SportShop.Stores;
using System.Windows;
using System.Windows.Input;
using BC = BCrypt.Net.BCrypt;

namespace SportShop.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;

        public ICommand NavigateRegisterCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand NavigateForgotPasswordCommand { get; }

        private NavigationStore _navigationStore;

        public LoginViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            LoginCommand = new RelayCommand(ExecuteLoginCommand);
            NavigateForgotPasswordCommand = new NavigateCommand<ForgotPasswordViewModel>(navigationStore, () => new ForgotPasswordViewModel(navigationStore));
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore));            
        }

        private bool CheckCredentials()
        {
            UserBusiness userBusiness = new();

            if (userBusiness.GetByEmail(Email) is null)
            {
                MessageBox.Show("Email is not registered in database!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            if (Password is null || !BC.Verify(Password, userBusiness.GetByEmail(Email).Password))
            {
                MessageBox.Show("Password doesn't match the email!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            MessageBox.Show("Login credentials are matched!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            return true;
        }

        private void LogUserIn()
        {
            if (CheckCredentials())
            {
                _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            }
        }

        private void ExecuteLoginCommand(object obj)
        {
            LogUserIn();
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }
}
