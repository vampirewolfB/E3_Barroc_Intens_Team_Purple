using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using BarrocIntens.Utility.Database;
using System.Diagnostics;
using BarrocIntens.Models;
using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using QuestPDF.Drawing;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using BarrocIntens.Utility;
using System.Collections.ObjectModel;
using Windows.Storage.Pickers;
using Windows.Storage.AccessCache;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Finance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InvoiceCreatePage : Page
    {
        private ObservableCollection<Company> companies;
        private ObservableCollection<Product> products;
        private Company chosenCompany;
       
        public InvoiceCreatePage()
        {
            this.InitializeComponent();

            using (AppDbContext db = new AppDbContext())
            {
                products = new ObservableCollection<Product>(db.Products.AsNoTracking());
                companies = new ObservableCollection<Company>(
                        db.Companies
                            .Include(c => c.User)
                            .AsNoTracking());
            }

            productsListView.ItemsSource = products;
        }

        // Allows that only numbers can be filled in for amount
        private void Quantity_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void CompanyAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                // Filter companies based on user input
                List<Company> filteredCompanies = companies
                    .Where(c => c.Name.Contains(sender.Text, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Set the filtered companies as the suggestions
                sender.ItemsSource = filteredCompanies;
            }
        }

        private void CompanyAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is Company company)
            {
                chosenCompany = company;

                sender.Text = company.Name;
            }
        }

        
        private List<Product> Get_Products()
        {
            List<Product> list = new List<Product> ();
            foreach (Product product in productsListView.SelectedItems.Cast<Product>())
            {
                list.Add(product);
            }
            foreach (Product product in list)
            {
                ListViewItem listViewItem = productsListView.ContainerFromItem(product) as ListViewItem;
                if (listViewItem != null)
                {
                    // Use VisualTreeHelper to find the TextBox within the ListViewItem
                    TextBox textBox = GetTextBoxFromListViewItem(listViewItem);
                    int quantity = 1;
                    if (!String.IsNullOrEmpty(textBox.Text) && textBox.Tag?.ToString() == product.Id.ToString())
                    {
                        quantity = int.Parse(textBox.Text);
                    }
                    product.Price = product.Price * quantity;
                }
            }
            return list;
        }

        private TextBox GetTextBoxFromListViewItem(DependencyObject parent)
        {
            // Loop through each child in the visual tree
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                if (child is TextBox textBox)
                {
                    return textBox;
                }

                TextBox result = GetTextBoxFromListViewItem(child);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
        
        private void Preview_PDF(object sender, RoutedEventArgs e)
        {
            if (chosenCompany != null)
            {
                string filePath = $"{Path.GetTempPath()}{chosenCompany.Name}_Preview.pdf";
                byte[] imageData = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Logo4_groot.png");
                InvoiceDocument document = new InvoiceDocument(chosenCompany, imageData, Get_Products());
                document.GeneratePdf(filePath);
                Process.Start("explorer.exe", filePath);
            }
            else
            {
                CompanyAutoSuggestBox.Text = "please be sure to choose a company...";
            }
        }

        private async void SavePDF_Click(object sender, RoutedEventArgs e)
        {
            //Set errorbox on empty
            ErrorTextBox.Visibility = Visibility.Visible;
            ErrorTextBox.Text = "";

            if (chosenCompany != null && productsListView.SelectedItems.Count > 0)
            {
                // Create a folder picker.
                FolderPicker openPicker = new Windows.Storage.Pickers.FolderPicker();

                //Retrieve the window handle of current window
                Window window = App.MainWindow;
                nint hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

                // Initialize the folder picker with window handle
                WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

                // Options for folder picker
                openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                openPicker.FileTypeFilter.Add("*");

                // Open the picker for the user to pick a folder
                StorageFolder folder = await openPicker.PickSingleFolderAsync();
                if (folder != null)
                {
                    StorageApplicationPermissions.FutureAccessList.AddOrReplace("InvoiceStore", folder);
                }
                else
                {
                    ErrorTextBox.Text = "Please select a folder to continue";
                    ErrorTextBox.Visibility = Visibility.Visible;
                    return;
                }

                int customId = 0;
                using (AppDbContext db = new AppDbContext())
                {
                    CustomInvoice customInvoice = new CustomInvoice { Date = DateTime.Now, CompanyId = chosenCompany.Id };
                    List<CustomInvoiceProduct> customInvoiceProducts = new List<CustomInvoiceProduct>();
                    db.CustomInvoices.Add(customInvoice);
                    db.SaveChanges();
                    customId = customInvoice.Id;
                    foreach (Product product in productsListView.SelectedItems)
                    {
                        int quantity = 1;
                        decimal price = 0;
                        foreach (CustomInvoiceProduct invoiceProduct in db.CustomInvoiceProducts)
                        {

                            if (invoiceProduct.ProductId != product.Id)
                            {
                                ListViewItem listViewItem = productsListView.ContainerFromItem(product) as ListViewItem;
                                if (listViewItem != null)
                                {
                                    // Use VisualTreeHelper to find the TextBox within the ListViewItem
                                    TextBox textBox = GetTextBoxFromListViewItem(listViewItem);

                                    if (!String.IsNullOrEmpty(textBox.Text) && textBox.Tag?.ToString() == product.Id.ToString())
                                    {
                                        quantity = int.Parse(textBox.Text);                                                                       
                                    }
                                    price = product.Price;
                                }
                            }

                        }
                        customInvoiceProducts.Add(new CustomInvoiceProduct { ProductId = product.Id, CustomInvoiceId = customInvoice.Id, Amount = quantity, PricePerProduct = price });
                    }
                    db.CustomInvoiceProducts.AddRange(customInvoiceProducts);
                    db.SaveChanges();

                    CustomInvoice invoice = db.CustomInvoices.Include(i => i.Company).ThenInclude(c => c.User).FirstOrDefault(ci => ci.Id == customId);
                    string filePath = $"{folder.Path}/{chosenCompany.Name}_{invoice.Id}.pdf";
                    byte[] imageData = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Logo4_groot.png");
                    InvoiceDocument document = new InvoiceDocument(invoice, imageData);
                    document.GeneratePdf(filePath);
                    Process.Start("explorer.exe", filePath);
                }

                this.Frame.Navigate(typeof(InvoicesPage));
            }
            else
            {
                if (chosenCompany == null)
                {
                    CompanyAutoSuggestBox.Text = "please be sure to choose a company...";
                }
                if (productsListView.SelectedItems.Count <= 0)
                {
                    productError.Visibility = Visibility.Visible;
                }
            }
                
        }
    }
}
