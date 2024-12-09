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

namespace BarrocIntens.Sales
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SalesPage : Page
    {
        public SalesPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(LogoPage));
        }

        // Navigation controller for the sales page
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
            else if (selectedItem == Quotes)
            {
                // Todo add quotes overview page navigation
                //if (ContentFrame.CurrentSourcePageType != typeof())
                //{
                //    ContentFrame.Navigate(typeof());
                //}
            }
            else if (selectedItem == QuotesCreate)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(QuoteCreatePage))
                {
                    ContentFrame.Navigate(typeof(QuoteCreatePage));
                }
            }
            else if (selectedItem == Customers)
            {
                // Todo add customers overview page navigation
                //if (ContentFrame.CurrentSourcePageType != typeof())
                //{
                //    ContentFrame.Navigate(typeof());
                //}
            }
            else if (selectedItem == CustomerCreate)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(CustomerCreatePage))
                {
                    ContentFrame.Navigate(typeof(CustomerCreatePage));
                }
            }
        }

        // Sets the navigationview correctly even if on page that's not in the list there.
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (ContentFrame.SourcePageType == typeof(LogoPage))
            {
                NavigationViewControl.SelectedItem = Home;
            }
            // Todo add quotes page so it can adjust as well.
            //else if (ContentFrame.SourcePageType != typeof())
            //{
            //    NavigationViewControl.SelectedItem = Quotes;
            //}
            else if (ContentFrame.SourcePageType != typeof(QuoteCreatePage))
            {
                NavigationViewControl.SelectedItem = QuotesCreate;
            }
            // Todo add customer page so it can adjust as well.
            //else if (ContentFrame.SourcePageType != typeof())
            //{
            //    NavigationViewControl.SelectedItem = Customers;
            //}
            else if (ContentFrame.SourcePageType != typeof(CustomerCreatePage))
            {
                NavigationViewControl.SelectedItem = CustomerCreate;
            }
        }
    }
}
