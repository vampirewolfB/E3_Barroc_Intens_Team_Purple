using BarrocIntens.Models;
using BarrocIntens.Uttility.Database;
using Microsoft.EntityFrameworkCore;
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
    public sealed partial class InvoicesPage : Page
    {
        private ObservableCollection<CustomInvoice> invoices;

        public InvoicesPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Load all invoices and set them to listview
            using (AppDbContext dbContext = new AppDbContext())
            {
                invoices = new ObservableCollection<CustomInvoice>(
                        dbContext.CustomInvoices
                                .Include(c => c.Company)
                    );
            }

            InvoicesListView.ItemsSource = invoices;
        }

        // Company search
        private void CompanySearch_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                InvoicesListView.ItemsSource = invoices.Where(
                    i => i.Company.Name.Contains(sender.Text, StringComparison.OrdinalIgnoreCase)
                );
            }
        }

        private void InvoicesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomInvoice invoice = (CustomInvoice)e.ClickedItem;
            this.Frame.Navigate(typeof(ShowInvoicePage), invoice);
        }
    }
}
