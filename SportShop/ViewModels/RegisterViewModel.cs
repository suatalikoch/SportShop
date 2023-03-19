using Business;
using Microsoft.EntityFrameworkCore;
using SportShop.Commands;
using SportShop.Stores;
using System.Windows;
using System.Windows.Input;
using BC = BCrypt.Net.BCrypt;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System;
using Data.Models;

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

        private NavigationStore _navigationStore;

        public RegisterViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            RegisterCommand = new RelayCommand(ExecuteRegisterCommand);
        }

        private void RegisterUser()
        {
            if (Password is null || ConfirmPassword is null)
            {
                return;
            }

            if (!Password.Equals(ConfirmPassword))
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            UserBusiness userBusiness = new();

            User user = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = BC.HashPassword(Password, BC.GenerateSalt())
            };

            try
            {
                userBusiness.Add(user);
            }
            catch (DbUpdateException e)
            {
                MessageBox.Show(e.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            _navigationStore.CurrentViewModel = new EmailConfirmationViewModel(_navigationStore);
        }

        private void SendConfirmationEmail()
        {
            if (FirstName is null || LastName is null || Email is null)
            {
                return;
            }

            var email = new MimeMessage();

            int code = new Random().Next(100000, 1000000);

            email.From.Add(new MailboxAddress("SportShop Support", "sportshophelp@gmail.com"));
            email.To.Add(new MailboxAddress($"{FirstName} {LastName}", Email));
            email.Subject = "Confirm your email";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Code: <b>{code.ToString().Insert(3, "-")}</b>"
            };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, true);
            smtp.Authenticate("smtp_username", "sportshop999");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        private void ExecuteRegisterCommand(object obj)
        {
            RegisterUser();
            SendConfirmationEmail();
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
