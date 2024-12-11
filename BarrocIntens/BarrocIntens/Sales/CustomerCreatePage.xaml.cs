using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Diagnostics;
using BarrocIntens.Utility;
using BarrocIntens.Utility.Database;
using BCrypt.Net;
using BarrocIntens.Utility.Emails;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Sales
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerCreatePage : Page
    {
        public CustomerCreatePage()
        {
            this.InitializeComponent();
        }

        // Checks if input was enter if yes sends to create
        private void NameTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                CreateAccount();
            }
        }

        // Checks if input was enter if yes sends to create
        private void EmailTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                CreateAccount();
            }
        }

        // Sends to create if button was pressed
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount();
        }

        // Creates a new account
        private void CreateAccount()
        {
            // Set error boxes on empty and hidden
            NameErrorTextBlock.Visibility = Visibility.Collapsed;
            NameErrorTextBlock.Text = "";
            EmailErrorTextBlock.Visibility = Visibility.Collapsed;
            EmailErrorTextBlock.Text = "";

            // Validation
            bool validationCheck = false;
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                NameErrorTextBlock.Text = "Please fill in a name.";
                validationCheck = true;
            }
            if (NameTextBox.Text.Length > 45)
            {
                NameErrorTextBlock.Text = "Name is to long.";
                validationCheck = true;
            }
            if (!Helpers.EmailChecker(EmailTextBox.Text))
            {
                EmailErrorTextBlock.Text = "Please fill in a valid email";
                validationCheck = true;
            }
            if (EmailTextBox.Text.Length > 255)
            {
                EmailErrorTextBlock.Text = "Email is to long";
                validationCheck = true;
            }
            if (validationCheck)
            {
                NameErrorTextBlock.Visibility = Visibility.Visible;
                EmailErrorTextBlock.Visibility = Visibility.Visible;

                return;
            }

            int lenght = new Random().Next(1, 15);
            string password = Helpers.PasswordGen(lenght, new Random().Next(0, lenght));

            // Create new user.
            using (AppDbContext dbContext = new AppDbContext())
            {
                dbContext.User.Add(new Models.User
                {
                    Name = NameTextBox.Text,
                    Email = EmailTextBox.Text,
                    Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password),
                    FirstLogin = false,
                    RoleId = dbContext.Roles.Where(r => r.Name.ToLower() == "customer").FirstOrDefault().Id
                });
                dbContext.SaveChanges();
            }

            // Send to mail
            new RegisterEmail(NameTextBox.Text, EmailTextBox.Text, password);

            // Todo add overview page
            //this.Frame.Navigate(Customers);
        }
    }
}
