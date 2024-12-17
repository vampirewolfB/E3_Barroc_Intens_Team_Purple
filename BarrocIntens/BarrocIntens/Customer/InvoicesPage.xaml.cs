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
using BarrocIntens.Utility.Database;
using System.Collections.ObjectModel;
using BarrocIntens.Models;
using Microsoft.EntityFrameworkCore;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Customer
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

            using (AppDbContext dbContext = new AppDbContext())
            {
                // Look for all the contracts that the user can see
                invoices = new ObservableCollection<CustomInvoice>(
                        dbContext.CustomInvoices
                            .Include(c => c.Company)
                            .ThenInclude(c => c.User)
                            .Where(c => c.Company.User.Id == User.LoggedInUser.Id)
                            .OrderBy(c => c.Id)
                            .AsNoTracking()
                    );
            }

            InvoicesListView.ItemsSource = invoices;
        }

        // Go to show page
        private void InvoicesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomInvoice invoice = (CustomInvoice)e.ClickedItem;
            this.Frame.Navigate(typeof(InvoicePage), invoice);
        }
    }
}
