using BarrocIntens.Models;
using BarrocIntens.Utility.Database;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Customer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContractOverViewPage : Page
    {
        ObservableCollection<Contract> contracts;
        public ContractOverViewPage()
        {
            this.InitializeComponent();
            using(AppDbContext db = new AppDbContext())
            {
                //User.LoggedInUser
                List<Contract> contractList = db.Contracts
                .Include(c => c.ContractProducts)
                .ThenInclude(cop => cop.Product)
                .Include(c => c.Company)
                .Where(c => c.Company.UserId == User.LoggedInUser)
                .ToList();

                // Initialize the ObservableCollection
                contracts = new ObservableCollection<Contract>(contractList);
            }
            contractsView.ItemsSource = contracts;
            ContentFrame.Navigate(typeof(ContractDetailPage), contracts.FirstOrDefault());
        }

        private void contractsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contractsView.SelectedItem is Contract selectedContract)
            {
                ContentFrame.Navigate(typeof(ContractDetailPage), selectedContract);
            }
        }
    }
}
