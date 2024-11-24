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
using BarrocIntens.Uttility.Database;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Finance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateInvoicePage : Page
    {
        List<Company> companies;
        private Company chosenCompany;
       
        public CreateInvoicePage()
        {
            this.InitializeComponent();
            using (AppDbContext db = new AppDbContext())
            {
                Debug.WriteLine($"{db.Products.Count()}");
                products.ItemsSource = db.Products.ToList();
                companies = db.Companies
                    .Include(c => c.User)
                    .ToList();
            }            
        }

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
            foreach (Product product in products.SelectedItems)
            {
                list.Add(product);
            }
            foreach (Product product in list)
            {
                ListViewItem listViewItem = products.ContainerFromItem(product) as ListViewItem;
                if (listViewItem != null)
                {
                    // Use VisualTreeHelper to find the TextBox within the ListViewItem
                    TextBox textBox = GetTextBoxFromListViewItem(listViewItem);

                    if (String.IsNullOrEmpty(textBox.Text) && textBox.Tag?.ToString() == product.Id.ToString())
                    {
                         product.Price = product.Price * int.Parse(textBox.Text);
                    }
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
            else{
                CompanyAutoSuggestBox.Text = "please be sure to choose a company...";
            }
        }

        private void SavePDF_Click(object sender, RoutedEventArgs e)
        {
            if (chosenCompany != null && products.SelectedItems.Count > 0)
            {
                int customId = 0;
                using (AppDbContext db = new AppDbContext())
                {
                    CustomInvoice customInvoice = new CustomInvoice { Date = DateTime.Now, CompanyId = chosenCompany.Id };
                    List<CustomInvoiceProduct> customInvoiceProducts = new List<CustomInvoiceProduct>();
                    db.CustomInvoices.Add(customInvoice);
                    db.SaveChanges();
                    customId = customInvoice.Id;
                    foreach (Product product in products.SelectedItems)
                    {
                        int quantity = 0;
                        decimal price = 0;
                        foreach (CustomInvoiceProduct invoiceProduct in db.CustomInvoiceProducts)
                        {

                            if (invoiceProduct.ProductId != product.Id)
                            {
                                ListViewItem listViewItem = products.ContainerFromItem(product) as ListViewItem;
                                if (listViewItem != null)
                                {
                                    // Use VisualTreeHelper to find the TextBox within the ListViewItem
                                    TextBox textBox = GetTextBoxFromListViewItem(listViewItem);

                                    if (textBox != null && textBox.Tag?.ToString() == product.Id.ToString())
                                    {
                                        Debug.WriteLine("found this bitch");
                                        quantity = int.Parse(textBox.Text);
                                        price = product.Price;
                                    }
                                }
                            }

                        }
                        customInvoiceProducts.Add(new CustomInvoiceProduct { ProductId = product.Id, CustomInvoiceId = customInvoice.Id, Amount = quantity, PricePerProduct = price });
                    }
                    db.CustomInvoiceProducts.AddRange(customInvoiceProducts);
                    db.SaveChanges();

                    CustomInvoice invoice = db.CustomInvoices.Include(i => i.Company).ThenInclude(c => c.User).FirstOrDefault(ci => ci.Id == customId);
                    string filePath = $"{Path.GetTempPath()}{chosenCompany.Name}_{invoice.Id}.pdf";
                    byte[] imageData = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/Assets/Logo4_groot.png");
                    InvoiceDocument document = new InvoiceDocument(invoice, imageData);
                    document.GeneratePdf(filePath);
                    Process.Start("explorer.exe", filePath);
                }
            }
            else
            {
                if (chosenCompany == null)
                {
                    CompanyAutoSuggestBox.Text = "please be sure to choose a company...";
                }
                if (products.SelectedItems.Count <= 0)
                {
                    productError.Visibility = Visibility.Visible;
                }
            }
                
        }
    }
}
