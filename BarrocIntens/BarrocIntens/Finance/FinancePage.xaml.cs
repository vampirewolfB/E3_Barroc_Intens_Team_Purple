using BarrocIntens.Finance;
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

namespace BarrocIntens.Finance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FinancePage : Page
    {
        public FinancePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ContentFrame.Navigate(typeof(LogoPage));
        }

        // Finance navigation view controller
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
            else if (selectedItem == MonthYearOverView)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(MonthYearOverviewPage))
                {
                    ContentFrame.Navigate(typeof(MonthYearOverviewPage));
                }
            }
            else if (selectedItem == LeaseContracts)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(LeaseContractsPage))
                {
                    ContentFrame.Navigate(typeof(LeaseContractsPage));
                }
            }
            else if (selectedItem == LeaseContractsCreate)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(LeaseContractCreatePage))
                {
                    ContentFrame.Navigate(typeof(LeaseContractCreatePage));
                }
            }
            else if (selectedItem == Invoices)
            {
                if (ContentFrame.CurrentSourcePageType != (typeof(InvoicesPage)))
                {
                    ContentFrame.Navigate(typeof(InvoicesPage));
                }
            }
            else if (selectedItem == InvoiceCreate)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(InvoiceCreatePage))
                {
                    ContentFrame.Navigate(typeof(InvoiceCreatePage));
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
            else if (ContentFrame.SourcePageType == typeof(MonthYearOverviewPage))
            {
                NavigationViewControl.SelectedItem = MonthYearOverView;
            }
            else if (ContentFrame.SourcePageType == typeof(LeaseContractsPage))
            {
                NavigationViewControl.SelectedItem = LeaseContracts;
            }
            else if (ContentFrame.SourcePageType == typeof(LeaseContractCreatePage))
            {
                NavigationViewControl.SelectedItem = LeaseContractsCreate;
            }
            else if (ContentFrame.SourcePageType == typeof(LeaseContractsEditPage))
            {
                NavigationViewControl.SelectedItem = null;
            }
            else if (ContentFrame.SourcePageType == typeof(InvoicesPage))
            {
                NavigationViewControl.SelectedItem = Invoices;
            }
            else if (ContentFrame.SourcePageType == typeof(ShowInvoicePage))
            {
                NavigationViewControl.SelectedItem = null;
            }
            else if (ContentFrame.SourcePageType == typeof(InvoiceCreatePage))
            {
                NavigationViewControl.SelectedItem = InvoiceCreate;
            }
        }
    }
}
