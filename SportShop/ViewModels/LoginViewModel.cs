using Business;
using SportShop.Commands;
using SportShop.Stores;
using System;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;

        public ICommand NavigateRegisterCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand NavigateForgotPasswordCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            NavigateForgotPasswordCommand = new NavigateCommand<ForgotPasswordViewModel>(() => new ForgotPasswordViewModel());
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(() => new RegisterViewModel());
        }

        private bool CheckCredentials()
        {
            UserBusiness userBusiness = new();

            bool check = false;

            try
            {
                check = userBusiness.GetByEmail(Email).Password.Equals(Password);
            }
            catch (Exception e)
            {
                return false;
            }

            return check;
        }

        private void LogUserIn()
        {
            if (CheckCredentials())
            {
                NavigationStore.CurrentViewModel = new HomeViewModel();
            }
        }

        private void ExecuteLoginCommand(object obj)
        {
            LogUserIn();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                return false;
            }

            if (string.IsNullOrEmpty(Password))
            {
                return false;
            }

            return true;
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
