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
        List<Company> companies;
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
            string selectedLeaseType = null;

            // Access the StackPanel that contains the RadioButtons
            StackPanel leaseTypePanel = (StackPanel)FindName("LeaseTypePanel");
            if (leaseTypePanel != null)
            {
                foreach (var control in leaseTypePanel.Children)
                {
                    if (control is RadioButton rb && rb.IsChecked == true)
                    {
                        selectedLeaseType = rb.Content.ToString();
                        break;
                    }
                }
            }

            // Parse the selected lease type to the corresponding enum
            if (!Enum.TryParse<Contract.PaymentTypes>(selectedLeaseType, out var paymentType))
            {
                Debug.WriteLine($"Invalid lease type: {selectedLeaseType}");
                return;
            }

            // Get the end date from the DatePicker
            DateTimeOffset? endDate = EndDatePicker?.Date;

            // Create new contract
            var newContract = new Contract
            {
                CompanyId = chosenCompany.Id,
                Type = paymentType,
                StartDate = DateTime.Now,
                EndDate = endDate.Value.DateTime
            };

            // Save the contract to the database
            using (var db = new AppDbContext())
            {
                db.Contracts.Add(newContract);
                db.SaveChanges();
            }
        }
    }
}
