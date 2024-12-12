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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Sales
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NoteCreatePage : Page
    {
        private ObservableCollection<Company> companies;
        private Company chosenCompany;

        public NoteCreatePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            using (AppDbContext db = new AppDbContext())
            {
                companies = new ObservableCollection<Company>(
                    db.Companies
                        .Include(c => c.User)
                        .AsNoTracking());
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

        private void NoteCreate_Click(object sender, RoutedEventArgs e)
        {
            // Validate chosen company
            if (chosenCompany == null)
            {
                CompanyErrorTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                CompanyErrorTextBlock.Visibility = Visibility.Collapsed;
            }

            // Validate notes text
            if (string.IsNullOrWhiteSpace(NotesTextBox.Text))
            {
                NoteErrorTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                NoteErrorTextBlock.Visibility = Visibility.Collapsed;
            }

            // Exit if there are validation errors
            if (chosenCompany == null || string.IsNullOrWhiteSpace(NotesTextBox.Text))
            {
                return;
            }

            // Save the note to the database
            using (AppDbContext db = new AppDbContext())
            {
                Note newNote = new Note
                {
                    Notes = NotesTextBox.Text,
                    CompanyId = chosenCompany.Id,
                    Date = DateTime.Now,
                    UserId = User.LoggedInUser.Id
                };

                db.Notes.Add(newNote);
                db.SaveChanges();
            }

            // Navigate to NotesPage
            Frame.Navigate(typeof(NotesPage));
        }
    }
}
