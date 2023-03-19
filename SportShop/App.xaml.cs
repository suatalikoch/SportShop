using SportShop.Stores;
using SportShop.ViewModels;
using SportShop.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SportShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new();
           
            if (SportShop.Properties.Settings.Default.Email.Equals("") && SportShop.Properties.Settings.Default.Password.Equals(""))
            {
                navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
            }
            else
            {
                //Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(SportShop.Properties.Settings.Default.Email), null);
                navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
            }

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
