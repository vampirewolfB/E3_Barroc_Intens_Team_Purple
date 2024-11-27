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
            else if (selectedItem == LeaseContracts)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(LeaseContractsPage))
                {
                    ContentFrame.Navigate(typeof(LeaseContractsPage));
                }
            }
            else if (selectedItem == LeaseContractsCreate)
            {  //Todo: add connection for creating lease contract page
                //if (ContentFrame.CurrentSourcePageType != typeof())
                //{
                //    ContentFrame.Navigate(typeof());
                //}
            }
            else if (selectedItem == CreateInvoice)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(CreateInvoicePage))
                {
                    ContentFrame.Navigate(typeof(CreateInvoicePage));
                }
            }
            else if (selectedItem == MonthYearOverView)
            {
                if (ContentFrame.CurrentSourcePageType != typeof(MonthYearOverviewPage))
                {
                    ContentFrame.Navigate(typeof(MonthYearOverviewPage));
                }
            }
        }
    }
}
