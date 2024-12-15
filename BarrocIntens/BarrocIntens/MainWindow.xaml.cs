using BarrocIntens.Customer;
using BarrocIntens.Finance;
using BarrocIntens.Models;
using BarrocIntens.Purchase;
using BarrocIntens.Sales;
using BarrocIntens.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.InitializeComponent();            
            this.SetTitleBar(AppTitleBar);

            // Check de enviorment en zet de menu correct.
            // Als het local is toon de dev titlebar.
            // Zo niet toon de noramele app bar.
            if (AppSettingLoader.Configuration["AppEnviorment"].ToLower() == "local")
            {
                AppTitle.Text = "Baroc Intents Dev";

                ObservableCollection<string> menu = [
                    "Login",
                    "Finance", 
                    "Sales", 
                    "Inkoop", 
                    "Maintenance", 
                    "Customer"
                    ];

                MenuSelectComboBox.ItemsSource = menu;
                MenuSelectComboBox.Visibility = Visibility.Visible;
            }
            else
            {
                AppTitle.Text = "Baroc Intents";
                MenuSelectComboBox.Visibility = Visibility.Collapsed;
            }

            // Navigeer naar de eerste frame.
            rootFrame.Navigate(typeof(LoginPage));
        }

        // Development tool om snel tussen pagina's te gaan zonder inloggen.
        private void MenuSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox; 
            switch (comboBox.SelectedItem.ToString().ToLower())
            {
                case "login":
                    rootFrame.Navigate(typeof(LoginPage));
                    break;
                case "finance":
                    rootFrame.Navigate(typeof(FinancePage));
                    break;
                case "sales":
                    rootFrame.Navigate(typeof(SalesPage));
                    break;
                case "inkoop":
                    rootFrame.Navigate(typeof(PurchasePage));
                    break;
                case "maintenance":
                    rootFrame.Navigate(typeof(MaintenancePage));
                    break;
                case "customer":
                    rootFrame.Navigate(typeof(CustomerPage));
                    break;
                default:
                    break;
            }
        }
    }
}
