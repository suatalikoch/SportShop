using Business;
using SportShop.Commands;
using SportShop.Models;
using SportShop.Stores;
using System;
using System.Windows.Input;

namespace SportShop.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string? _firstName;
        private string? _lastName;
        private string? _email;
        private string? _password;
        private string? _confirmPassword;
        private bool _isConfirmedPrivacyPolicy;
        private bool _isSubscribedToNews;

        public ICommand NavigateLoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(() => new LoginViewModel());
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        }

        private void ExecuteRegisterCommand(object obj)
        {
            UserBusiness userBusiness = new();

            User user = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };

            try
            {
                userBusiness.Add(user);
            }
            catch (Exception e)
            {
                return;
            }

            NavigationStore.CurrentViewModel = new EmailConfirmationViewModel();
        }

        private bool CanExecuteRegisterCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                return false;
            }

            if (!IsConfirmedPrivacyPolicy)
            {
                return false;
            }

            return true;
        }

        public string? FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string? LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string? ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public bool IsConfirmedPrivacyPolicy
        {
            get => _isConfirmedPrivacyPolicy;
            set
            {
                _isConfirmedPrivacyPolicy = value;
                OnPropertyChanged(nameof(IsConfirmedPrivacyPolicy));
            }
        }

        public bool IsSubscribedToNews
        {
            get => _isSubscribedToNews;
            set
            {
                _isSubscribedToNews = value;
                OnPropertyChanged(nameof(IsSubscribedToNews));
            }
        }
    }
}
