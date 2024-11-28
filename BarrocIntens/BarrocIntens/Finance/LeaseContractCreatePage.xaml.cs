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
using Windows.Security.ExchangeActiveSyncProvisioning;
using static BarrocIntens.Models.Contract;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Finance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LeaseContractCreatePage : Page
    {
        private List<Company> companies;
        private Company chosenCompany;

        public LeaseContractCreatePage()
        {
            this.InitializeComponent();
            using (AppDbContext db = new AppDbContext())
            {
                companies = db.Companies
                    .Include(c => c.User)
                    .ToList();
            }
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

            // Validate lease type selection
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

            // Parse lease type
            if (!Enum.TryParse<Contract.PaymentTypes>(selectedLeaseType, out var paymentType))
            {
                LeaseTypeErrorTextBlock.Visibility = Visibility.Visible;
                return;
            }

            // Check if the EndDate is set
            DateTimeOffset endDate;
            if (EndDatePicker?.Date >= DateTime.Now)
            {
                endDate = EndDatePicker.Date;
            }
            else
            {
                endDate = DateTimeOffset.Now.AddYears(1);
            }

            // Check if the StartDate is set
            DateTimeOffset startDate;
            if (StartDatePicker?.Date >= DateTime.Now)
            {
                startDate = StartDatePicker.Date;
            }
            else
            {
                startDate = DateTime.Now;
            }

            // Create new contract
            var newContract = new Contract
            {
                CompanyId = chosenCompany.Id,
                Type = paymentType,
                StartDate = startDate.DateTime,
                EndDate = endDate.DateTime
            };

            // Save contract to the database
            using (var db = new AppDbContext())
            {
                db.Contracts.Add(newContract);
                db.SaveChanges();
            }

            // Navigate to the LeaseContractsPage
            Frame.Navigate(typeof(LeaseContractsPage));
        }

    }
}
