using BarrocIntens.Customer;
using BarrocIntens.Finance;
using BarrocIntens.Models;
using BarrocIntens.Purchase;
using BarrocIntens.Sales;
using BarrocIntens.Utility.Database;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void EmailTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                LoginUser();
            }
        }

        // Allow for enter to be used as input as well.
        private void PasswordTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                LoginUser();
            }
        }

        // Allow for enter to be used as input
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginUser();
        }

        private void LoginUser()
        {
            // Zet de error textbox zichtbaarheid op collapsed en checkt of de velden zijn ingevuld
            ErrorTextBox.Visibility = Visibility.Collapsed;
            if (String.IsNullOrEmpty(EmailTextBox.Text) || String.IsNullOrEmpty(PasswordTextBox.Password.ToString()))
            {
                ErrorTextBox.Text = "Een of meer velden niet ingevuld";
                ErrorTextBox.Visibility = Visibility.Visible;
                return;
            }

            // Ophalen van juiste gebruiker.
            using (AppDbContext dbContext = new AppDbContext())
            {
                User.LoggedInUser = dbContext.User
                    .Where(u => u.Email == EmailTextBox.Text.ToString())
                    .Include(u => u.Role)
                    .AsNoTracking()
                    .FirstOrDefault();
            }

            // Check of de gebruiker bestaat en het wachtwoord correct is.
            if (User.LoggedInUser is null)
            {
                ErrorTextBox.Text = "Email of wachtwoord incorect.";
                ErrorTextBox.Visibility = Visibility.Visible;
                return;
            }
            if (!BCrypt.Net.BCrypt.EnhancedVerify(PasswordTextBox.Password.ToString(), User.LoggedInUser.Password))
            {
                ErrorTextBox.Text = "Email of wachtwoord incorect.";
                ErrorTextBox.Visibility = Visibility.Visible;
                return;
            }

            // Doorsturen van de gebruiker naar de juiste dashboard
            switch (User.LoggedInUser.Role.Name.ToLower())
            {
                case "finance":
                    this.Frame.Navigate(typeof(FinancePage));
                    break;
                case "sales":
                    this.Frame.Navigate(typeof(SalesPage));
                    break;
                case "inkoop":
                    this.Frame.Navigate(typeof(PurchasePage));
                    break;
                case "maintenance":
                    this.Frame.Navigate(typeof(MaintenancePage));
                    break;
                case "customer":
                    if (User.LoggedInUser.FirstLogin)
                    {
                        this.Frame.Navigate(typeof(CustomerFirstLogin));
                        break;
                    }
                    this.Frame.Navigate(typeof(CustomerPage));
                    break;
                default:
                    ErrorTextBox.Text = "Er is een probleem opgetreden probeer opnieuw.";
                    ErrorTextBox.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}

