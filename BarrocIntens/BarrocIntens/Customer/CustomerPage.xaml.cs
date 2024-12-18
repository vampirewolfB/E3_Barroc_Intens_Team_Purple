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
    public sealed partial class CustomerPage : Page
    {
        public CustomerPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ContentFrame.Navigate(typeof(LogoPage));

            using (AppDbContext dbContext = new AppDbContext())
            {
                Company company = dbContext.Companies.FirstOrDefault(c => c.UserId == User.LoggedInUser.Id);
                if (company is null)
                {
                    Invoices.Visibility = Visibility.Collapsed;
                    Contracts.Visibility = Visibility.Collapsed;
                }
            }
        }

        //Customer navigationview control
        private void NavigationViewControl_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItemBase selectedItem = args.SelectedItemContainer;
            if (selectedItem == Home)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(LogoPage))
                {
                    ContentFrame.Navigate(typeof(LogoPage));
                }
            }
            else if (selectedItem == Contracts)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(ContractOverViewPage))
                {
                    ContentFrame.Navigate(typeof(ContractOverViewPage));
                }
            }
            else if (selectedItem == Invoices)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(InvoicesPage))
                {
                    ContentFrame.Navigate(typeof(InvoicesPage));
                }
            }
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (ContentFrame.CurrentSourcePageType == typeof(LogoPage))
            {
                NavigationViewControl.SelectedItem = Home;
            }
            else if (ContentFrame.CurrentSourcePageType == typeof(ContractOverViewPage))
            {
                NavigationViewControl.SelectedItem = Contracts;
            }
            //else if (ContentFrame.CurrentSourcePageType == typeof(ContractDetailPage))
            //{
            //    NavigationViewControl.SelectedItem = null;
            //}
            else if (ContentFrame.CurrentSourcePageType == typeof(InvoicesPage))
            {
                NavigationViewControl.SelectedItem = Invoices;
            }
            else if (ContentFrame.CurrentSourcePageType == typeof(InvoicePage))
            {
                NavigationViewControl.SelectedItem = null;
            }
        }
    }
}
