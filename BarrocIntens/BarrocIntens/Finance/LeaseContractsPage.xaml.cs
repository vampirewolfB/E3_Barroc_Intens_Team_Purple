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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static BarrocIntens.Models.Contract;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Finance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LeaseContractsPage : Page
    {
        private ObservableCollection<Contract> contracts;

        public LeaseContractsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Load all contracts and set them to listview
            using (AppDbContext dbContext = new AppDbContext())
            {
                contracts = new ObservableCollection<Contract>(
                        dbContext.Contracts
                                .Include(c => c.Company
                    ));
            }

            // Collection for sort
            ObservableCollection<string> paymentTypes = new ObservableCollection<string>();
            paymentTypes.Add("Select all");
            paymentTypes.Add(PaymentTypes.Monthly.ToString());
            paymentTypes.Add(PaymentTypes.Perodic.ToString());

            ContractsListView.ItemsSource = contracts;
            TypeSortComboBox.ItemsSource = paymentTypes;
            TypeSortComboBox.SelectedIndex = 0;
        }

        private void ContractsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Todo: Add way to edit page where you can also delete 
            Contract contract = (Contract)e.ClickedItem;
            //this.Frame.Navigate(typeof(), contract);
        }
        
        // Filter for the contract type
        private void TypeSortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Filter for the type works in combination with the company search
            ComboBox comboBox = (ComboBox)sender;
            if (String.IsNullOrEmpty(CompanySearch.Text))
            {
                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        ContractsListView.ItemsSource = contracts;
                        break;
                    case 1:
                        ContractsListView.ItemsSource = contracts.Where(c => c.Type == PaymentTypes.Monthly);
                        break;
                    case 2:
                        ContractsListView.ItemsSource = contracts.Where(c => c.Type == PaymentTypes.Perodic);
                        break;
                    default:
                        ContractsListView.ItemsSource = contracts;
                        break;
                }
            }
            else
            {
                switch (TypeSortComboBox.SelectedIndex)
                {
                    case 0:
                        ContractsListView.ItemsSource = contracts.Where(c =>
                            c.Company.Name.Contains(CompanySearch.Text, StringComparison.OrdinalIgnoreCase
                        ));
                        break;
                    case 1:
                        ContractsListView.ItemsSource = contracts.Where(c =>
                            c.Type == PaymentTypes.Monthly &&
                            c.Company.Name.Contains(CompanySearch.Text, StringComparison.OrdinalIgnoreCase)
                        );
                        break;
                    case 2:
                        ContractsListView.ItemsSource = contracts.Where(c =>
                            c.Type == PaymentTypes.Perodic &&
                            c.Company.Name.Contains(CompanySearch.Text, StringComparison.OrdinalIgnoreCase)

                        );
                        break;
                    default:
                        ContractsListView.ItemsSource = contracts.Where(c =>
                            c.Company.Name.Contains(CompanySearch.Text, StringComparison.OrdinalIgnoreCase
                        ));
                        break;
                }
            }

        }

        //Company search
        private void CompanySearch_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //Filter for companies works in sync with the type sorter
                switch (TypeSortComboBox.SelectedIndex)
                {
                    case 0:
                        ContractsListView.ItemsSource = contracts.Where(c =>
                            c.Company.Name.Contains(sender.Text, StringComparison.OrdinalIgnoreCase
                        ));
                        break;
                    case 1:
                        ContractsListView.ItemsSource = contracts.Where(c =>
                            c.Type == PaymentTypes.Monthly &&
                            c.Company.Name.Contains(sender.Text, StringComparison.OrdinalIgnoreCase)
                        );
                        break;
                    case 2:
                        ContractsListView.ItemsSource = contracts.Where(c =>
                            c.Type == PaymentTypes.Perodic &&
                            c.Company.Name.Contains(sender.Text, StringComparison.OrdinalIgnoreCase)

                        );
                        break;
                    default:
                        ContractsListView.ItemsSource = contracts.Where(c =>
                            c.Company.Name.Contains(sender.Text, StringComparison.OrdinalIgnoreCase
                        ));
                        break;
                }
            }
        }
    }
}
