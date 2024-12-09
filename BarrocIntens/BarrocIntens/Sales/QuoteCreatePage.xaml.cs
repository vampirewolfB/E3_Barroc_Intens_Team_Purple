using BarrocIntens.Utility.Database;
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
using Windows.System;
using System.Runtime.CompilerServices;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Sales
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuoteCreatePage : Page
    {
        List<Models.User> clients;
        Models.User chosenClient;
        Quote sentQuote = new Quote();
        List<QuoteProduct> quoteProducts = new List<QuoteProduct>();

        public QuoteCreatePage()
        {
            this.InitializeComponent();
            using(AppDbContext db = new AppDbContext())
            {
                Debug.WriteLine($"{db.Products.Count()}");
                products.ItemsSource = db.Products
                    .Where(p => p.ProductCategoryId == 1)
                    .Include(p => p.QuoteProducts)
                    .ToList();
                clients = db.User
                    .Where(u => u.RoleId == 5)
                    .Include(u => u.Quotes)
                    .ThenInclude(q => q.QuoteProducts)
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
                List<Models.User> filteredClients = clients
                    .Where(c => c.Name.Contains(sender.Text, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Set the filtered companies as the suggestions
                sender.ItemsSource = filteredClients;
            }
        }

        private void ClientAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is Models.User client)
            {
                chosenClient = client;

                sender.Text = client.Name;
            }
        }

        private List<Product> Get_Products()
        {
            int quantity = 1;
            decimal totalPrice = 0;
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
                    
                    if (!String.IsNullOrEmpty(textBox.Text) && textBox.Tag?.ToString() == product.Id.ToString())
                    {
                        quantity = int.Parse(textBox.Text);
                    }
                    totalPrice += product.Price * quantity;
                }
            }
           
            totalPriceText.Text = $"{totalPrice}";
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
            productError.Visibility = Visibility.Collapsed;
            if (chosenClient != null && products.SelectedItems.Count > 0)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    Quote quote = new Quote { Date = DateTime.Now, UserId = chosenClient.Id };
                    quoteProducts = new List<QuoteProduct>();
                    db.Quotes.Add(quote);
                    db.SaveChanges();
                    sentQuote = quote;
                    foreach (Product product in products.SelectedItems)
                    {
                        int quantity = 1;
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

                sendEmail(chosenClient);
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
        private async void sendEmail(Models.User client)
        {
            
            string emailAdress = $"{client.Email}";
            string bodyText = "Thank you for your purchase, below you will see a summary of your purchase.\n\n";
            bodyText += "Product Name - Qty - Price - Subtotal\n";
            bodyText += "-------------------------------------------------------------\n";
            using (AppDbContext db = new AppDbContext())
            {
                
                foreach (Product product in Get_Products())
                {
                    Debug.WriteLine($"{product.QuoteProducts.Count}");
                    bodyText += $"{product.Name} - {quoteProducts.FirstOrDefault(qp => qp.QuoteId == sentQuote.Id && qp.ProductId == product.Id).Quantity} - €{product.Price} - €{product.Price * quoteProducts.FirstOrDefault(qp => qp.QuoteId == sentQuote.Id && qp.ProductId == product.Id).Quantity}\n";
                }
            }
            bodyText += "-------------------------------------------------------------\n";
            bodyText += $"Total Price :  €{totalPriceText.Text}";
            string emailBody = Uri.EscapeDataString(bodyText);

            // Construct the mailto URI
            string email = $"mailto:{emailAdress}?subject=Your%20Order%20Summary&body={emailBody}";
            Uri emailUri = new Uri(email);
            bool success = await Launcher.LaunchUriAsync(emailUri);
        }

        private void products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Get_Products();
        }
    }
}
