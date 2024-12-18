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
using Windows.Security.ExchangeActiveSyncProvisioning;
using static BarrocIntens.Models.Contract;
using System.Collections.ObjectModel;

namespace BarrocIntens.Finance
{
    public sealed partial class LeaseContractCreatePage : Page
    {
        private ObservableCollection<Company> companies;
        private ObservableCollection<Product> products;
        private Company chosenCompany;

        public LeaseContractCreatePage()
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

        private void CompanyAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var filteredCompanies = companies
                    .Where(c => c.Name.Contains(sender.Text, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                sender.ItemsSource = filteredCompanies;
            }
        }

        private void Quantity_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void CompanyAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem is Company company)
            {
                chosenCompany = company;
                sender.Text = company.Name;
            }
        }

        private void CreateLeaseContract(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            CompanyErrorTextBlock.Visibility = Visibility.Collapsed;
            LeaseTypeErrorTextBlock.Visibility = Visibility.Collapsed;

            if (chosenCompany == null)
            {
                CompanyErrorTextBlock.Visibility = Visibility.Visible;
                isValid = false;
            }

            string selectedLeaseType = null;
            foreach (var control in LeaseTypePanel.Children)
            {
                if (control is RadioButton rb && rb.IsChecked == true)
                {
                    selectedLeaseType = rb.Content.ToString();
                    break;
                }
            }

            if (string.IsNullOrEmpty(selectedLeaseType))
            {
                LeaseTypeErrorTextBlock.Visibility = Visibility.Visible;
                isValid = false;
            }

            if (!isValid) return;

            if (!Enum.TryParse<Contract.PaymentTypes>(selectedLeaseType, out var paymentType))
            {
                LeaseTypeErrorTextBlock.Visibility = Visibility.Visible;
                return;
            }

            DateTimeOffset endDate;
            if (EndDatePicker?.Date >= DateTime.Now)
            {
                endDate = EndDatePicker.Date;
            }
            else
            {
                endDate = DateTimeOffset.Now.AddYears(1);
            }

            DateTimeOffset startDate;
            if (StartDatePicker?.Date >= DateTime.Now)
            {
                startDate = StartDatePicker.Date;
            }
            else
            {
                startDate = DateTime.Now;
            }

            var newContract = new Contract
            {
                CompanyId = chosenCompany.Id,
                Type = paymentType,
                StartDate = startDate.DateTime,
                EndDate = endDate.DateTime
            };

            var contractProducts = new List<ContractProduct>();

            using (var db = new AppDbContext())
            {
                db.Contracts.Add(newContract);
                db.SaveChanges();

                // Loop through selected products to retrieve quantity dynamically
                foreach (var product in productsListView.SelectedItems.Cast<Product>())
                {
                    int quantity = 1; // Default value

                    // Get the ListViewItem for the current product
                    ListViewItem listViewItem = productsListView.ContainerFromItem(product) as ListViewItem;
                    if (listViewItem != null)
                    {
                        // Use VisualTreeHelper to find the TextBox within the ListViewItem
                        TextBox textBox = GetTextBoxFromListViewItem(listViewItem);

                        // Retrieve the quantity from the TextBox, if available
                        if (!string.IsNullOrEmpty(textBox.Text) && textBox.Tag?.ToString() == product.Id.ToString())
                        {
                            quantity = int.Parse(textBox.Text);
                        }
                    }

                    // Add the contract product with the dynamically retrieved quantity
                    contractProducts.Add(new ContractProduct
                    {
                        ContractId = newContract.Id,
                        ProductId = product.Id,
                        Amount = quantity,
                        LeassedPrice = product.Price * quantity
                    });
                }

                db.ContractProducts.AddRange(contractProducts);
                db.SaveChanges();
            }

            Frame.Navigate(typeof(LeaseContractsPage));
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

    }
}
