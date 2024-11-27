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
using BarrocIntens.Uttility.Database;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Finance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowInvoicePage : Page
    {
        private CustomInvoice invoice;

        public ShowInvoicePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            invoice = (CustomInvoice)e.Parameter;
            
            // Get all the invoice lines and set them.
            ObservableCollection<CustomInvoiceProduct> customInvoiceProducts;
            using(AppDbContext dbContext  = new AppDbContext())
            {
                customInvoiceProducts = new ObservableCollection<CustomInvoiceProduct>(
                        dbContext.CustomInvoiceProducts
                            .Include(c => c.Product)
                            .Where(c => c.CustomInvoiceId == invoice.Id)
                            .ToList()
                    );
            }

            InvoiceLinesListView.ItemsSource = customInvoiceProducts;

            // Set total amount
            decimal total = 0.00M;
            foreach (CustomInvoiceProduct customInvoiceProduct in customInvoiceProducts)
            {
                total =+ customInvoiceProduct.PricePerProduct * customInvoiceProduct.Amount;
            }
            totalAmountTextBlock.Text = total.ToString();

            // Check if PaidAt is null if so show panel to set paid at
            if (invoice.PaidAt is null)
            {
                paidAtStackPanel.Orientation = Orientation.Vertical;
                paidAtTextBlock.Visibility = Visibility.Collapsed;
                datePickerStackPanel.Visibility = Visibility.Visible;
                DatePicker.MaxYear = DateTimeOffset.Now;
            }
            else
            {
                paidAtTextBlock.Visibility = Visibility.Visible;
                datePickerStackPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void SetPaidButton_Click(object sender, RoutedEventArgs e)
        {
            errorTextBlock.Visibility = Visibility.Collapsed;
            if (DatePicker.SelectedDate is null || TimePicker.SelectedTime is null)
            {
                errorTextBlock.Text = "Date or Time not filled in";
                errorTextBlock.Visibility = Visibility.Visible;
                return;
            }

            DateTime paidAt = new DateTime(
                    DatePicker.Date.Year,
                    DatePicker.Date.Month,
                    DatePicker.Date.Day,
                    TimePicker.Time.Hours,
                    TimePicker.Time.Minutes,
                    TimePicker.Time.Seconds
                );

            using (AppDbContext dbContext = new AppDbContext())
            {
                invoice.PaidAt = paidAt;
                dbContext.Update(invoice);
                dbContext.SaveChanges();
            }

            paidAtTextBlock.Visibility = Visibility.Visible;
            paidAtTextBlock.Text = paidAt.ToString();
            datePickerStackPanel.Visibility = Visibility.Collapsed;
            paidAtStackPanel.Orientation = Orientation.Horizontal;
        }
    }
}
