using BarrocIntens.Models;
using BarrocIntens.Utility.Database;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Customer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerFirstLogin : Page
    {
        public CustomerFirstLogin()
        {
            this.InitializeComponent();
        }

        private void PasswordTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                UpdatePassword();
            }
        }

        private void PasswordConfirmTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                UpdatePassword();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            UpdatePassword();
        }

        // Updates the password
        private void UpdatePassword()
        {
            // Reset error message
            ErrorTextBox.Visibility = Visibility.Collapsed;
            ErrorTextBox.Text = "";

            // Validation
            if (string.IsNullOrWhiteSpace(PasswordTextBox.Password.ToString()) || string.IsNullOrWhiteSpace(PasswordConfirmTextBox.Password.ToString()))
            {
                ErrorTextBox.Text = "Please fill in both fields.";
                ErrorTextBox.Visibility = Visibility.Visible;
                return;
            }

            if (BCrypt.Net.BCrypt.EnhancedVerify(PasswordTextBox.Password.ToString(), User.LoggedInUser.Password))
            {
                ErrorTextBox.Text = "Please fill in a new password.";
                ErrorTextBox.Visibility = Visibility.Visible;
                return;
            }

            if (PasswordTextBox.Password.ToString() != PasswordConfirmTextBox.Password.ToString())
            {
                ErrorTextBox.Text = "Please fill in the same password twice to confirm.";
                ErrorTextBox.Visibility = Visibility.Visible;
                return;
            }
            
            // Save the updated password and set firstlogin on false
            using(AppDbContext dbContext = new AppDbContext())
            {
                User.LoggedInUser.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(PasswordConfirmTextBox.Password.ToString());
                User.LoggedInUser.FirstLogin = false;
                dbContext.Update(User.LoggedInUser);
                dbContext.SaveChanges();
            }

            this.Frame.Navigate(typeof(CustomerPage));
        }
    }
}
