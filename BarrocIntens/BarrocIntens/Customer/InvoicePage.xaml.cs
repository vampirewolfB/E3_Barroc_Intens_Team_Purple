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
using BarrocIntens.Models;
using BarrocIntens.Utility.Database;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Customer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InvoicePage : Page
    {
        private CustomInvoice invoice;

        public InvoicePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            invoice = (CustomInvoice)e.Parameter;

            // Get all invoice lines and set them
            ObservableCollection<CustomInvoiceProduct> customInvoiceProducts;
            using (AppDbContext dbContext = new AppDbContext())
            {
                customInvoiceProducts = new ObservableCollection<CustomInvoiceProduct>(
                        dbContext.CustomInvoiceProducts
                            .Include(c => c.Product)
                            .Where(c => c.CustomInvoiceId == invoice.Id)
                            .AsNoTracking()
                    );
            }

            // Set total amount
            decimal total = 0.00M;

            foreach (CustomInvoiceProduct customInvoiceProduct in customInvoiceProducts)
            {
                total = +customInvoiceProduct.PricePerProduct * customInvoiceProduct.Amount;
            }

            totalAmountTextBlock.Text = total.ToString();

            InvoiceLinesListView.ItemsSource = customInvoiceProducts;
        }
    }
}
