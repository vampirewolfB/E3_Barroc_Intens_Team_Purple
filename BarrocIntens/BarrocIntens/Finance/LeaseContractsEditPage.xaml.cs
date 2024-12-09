using BarrocIntens.Models;
using BarrocIntens.Uttility.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Finance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LeaseContractsEditPage : Page
    {
        internal Contract SelectedContract { get; private set; }
        private List<Company> companies;
        private Company chosenCompany;

        public LeaseContractsEditPage()
        {
            this.InitializeComponent();
            using (AppDbContext db = new AppDbContext())
            {
                companies = db.Companies
                    .Include(c => c.User)
                    .ToList();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Contract contract)
            {
                SelectedContract = contract;
                LeaseContractEdit.DataContext = this;
            }
            UpdateRadioButtons();
        }
        private void UpdateRadioButtons()
        {
            if (SelectedContract != null)
            {
                // Check if the contract type is "Periodic"
                PerodicRadioButton.IsChecked = SelectedContract.Type == Contract.PaymentTypes.Perodic; ;

                // Check if the contract type is "Monthly"
                MonthlyRadioButton.IsChecked = SelectedContract.Type == Contract.PaymentTypes.Monthly; ;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            CompanyErrorTextBlock.Visibility = Visibility.Collapsed;
            LeaseTypeErrorTextBlock.Visibility = Visibility.Collapsed;

            // Validate selected company
            if (chosenCompany == null)
            {
                CompanyErrorTextBlock.Text = "Please select a valid company.";
                CompanyErrorTextBlock.Visibility = Visibility.Visible;
                isValid = false;
            }

            // Validate lease type selection
            Contract.PaymentTypes? selectedLeaseType = null;
            if (PerodicRadioButton.IsChecked == true)
            {
                selectedLeaseType = Contract.PaymentTypes.Perodic;
            }
            else if (MonthlyRadioButton.IsChecked == true)
            {
                selectedLeaseType = Contract.PaymentTypes.Monthly;
            }

            if (selectedLeaseType == null)
            {
                LeaseTypeErrorTextBlock.Text = "Please select a lease type.";
                LeaseTypeErrorTextBlock.Visibility = Visibility.Visible;
                isValid = false;
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

            // Check if all validations pass
            if (!isValid)
            {
                return;
            }

            using (AppDbContext db = new AppDbContext())
            {
                var contractToUpdate = db.Contracts
                    .Include(c => c.Company)
                    .FirstOrDefault(c => c.Id == SelectedContract.Id);

                contractToUpdate.CompanyId = chosenCompany.Id;
                contractToUpdate.Type = selectedLeaseType.Value;
                contractToUpdate.StartDate = startDate.Date;
                contractToUpdate.EndDate = endDate.Date;

                db.SaveChanges();
                Frame.Navigate(typeof(LeaseContractsPage));
            }   
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var contractToDelete = db.Contracts
                    .Include(c => c.Company)
                    .FirstOrDefault(c => c.Id == SelectedContract.Id);

                if (contractToDelete != null)
                {
                    db.Contracts.Remove(contractToDelete);
                    db.SaveChanges();
                    Frame.Navigate(typeof(LeaseContractsPage));
                }
            }
        }
    }
}
