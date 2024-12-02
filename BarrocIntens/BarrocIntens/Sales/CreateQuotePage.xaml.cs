using BarrocIntens.Uttility.Database;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using BarrocIntens.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.EntityFrameworkCore;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Sales
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateQuotePage : Page
    {
        List<User> clients;
        User chosenClient;
        public CreateQuotePage()
        {
            this.InitializeComponent();
            using(AppDbContext db = new AppDbContext())
            {
                Debug.WriteLine($"{db.Products.Count()}");
                products.ItemsSource = db.Products.ToList();
                clients = db.User
                    .Where(u => u.RoleId == 5)
                    .ToList();
            }
        }
        private void Quantity_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
        private void ClientAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                // Filter companies based on user input
                List<User> filteredClients = clients
                    .Where(c => c.Name.Contains(sender.Text, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Set the filtered companies as the suggestions
                sender.ItemsSource = filteredClients;
            }
        }
        private void ClientAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is User client)
            {
                chosenClient = client;

                sender.Text = client.Name;
            }
        }
        private List<Product> Get_Products()
        {
            List<Product> list = new List<Product>();
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

        private void SaveQuote_Click(object sender, RoutedEventArgs e)
        {
            if (chosenClient != null && products.SelectedItems.Count > 0)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    Quote quote = new Quote { Date = DateTime.Now, UserId = chosenClient.Id };
                    List<QuoteProduct> quoteProducts = new List<QuoteProduct>();
                    db.Quotes.Add(quote);
                    db.SaveChanges();
                    foreach (Product product in products.SelectedItems)
                    {
                        int quantity = 0;
                        foreach (QuoteProduct quoteProduct in db.QuoteProducts)
                        {
                            if (quoteProduct.ProductId != product.Id)
                            {
                                ListViewItem listViewItem = products.ContainerFromItem(product) as ListViewItem;
                                if (listViewItem != null)
                                {
                                    // Use VisualTreeHelper to find the TextBox within the ListViewItem
                                    TextBox textBox = GetTextBoxFromListViewItem(listViewItem);

                                    if (!String.IsNullOrEmpty(textBox.Text) && textBox.Tag?.ToString() == product.Id.ToString())
                                    {
                                        quantity = int.Parse(textBox.Text);
                                    }
                                }
                            }
                        }
                        quoteProducts.Add(new QuoteProduct {ProductId = product.Id, QuoteId = quote.Id, Quantity = quantity});
                    }
                    db.QuoteProducts.AddRange(quoteProducts);
                    db.SaveChanges();
                    savedNote.Visibility = Visibility.Visible;
                }
                    

            }
            else
            {
                if (chosenClient == null)
                {
                    ClientAutoSuggestBox.Text = "please be sure to choose a company...";
                }
                if (products.SelectedItems.Count <= 0)
                {
                    productError.Visibility = Visibility.Visible;
                }
            }

        }

        private void products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            decimal totalPrice = 0;

            foreach (Product product in Get_Products())
            {
                totalPrice += product.Price;
            }
            totalPriceText.Text = $"{totalPrice}";
        }
    }
}
