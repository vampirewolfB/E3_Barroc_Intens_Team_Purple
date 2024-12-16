using ABI.Windows.UI;
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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Purchase
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductOverviewPage : Page
    {
        private ObservableCollection<Product> products;
        public ProductOverviewPage()
        {
            this.InitializeComponent();
            
            using (AppDbContext db = new AppDbContext())
            {
                CategoryBox.ItemsSource = db.ProductCategories.ToList();
                products = new ObservableCollection<Product>(db.Products.Include(p => p.ProductCategory));
            }
            productsView.ItemsSource = products;
        }

        private void CategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductCategory productCategory = (ProductCategory)CategoryBox.SelectedItem;
            productsView.ItemsSource = products
                .Where(p => p.ProductCategoryId == productCategory.Id);
        }

        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            productsView.ItemsSource = products;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            // actual code for user id: UserId = User.LoggedInUser.Id
            Expense expense = new Expense {Date = DateTime.Now, UserId = 1 };
            List<ExpenseProduct> expenseProducts = new List<ExpenseProduct>();
            using (AppDbContext db = new AppDbContext())
            {
                db.Expenses.Add(expense);
                db.SaveChanges();
            }
            foreach (Product product in products)
            {
                int quantity = 0;
                decimal price = 0;
                ListViewItem listViewItem = productsView.ContainerFromItem(product) as ListViewItem;
                if (listViewItem != null)
                {
                    // Use VisualTreeHelper to find the TextBox within the ListViewItem
                    TextBox textBox = GetTextBoxFromListViewItem(listViewItem);

                    if (!String.IsNullOrEmpty(textBox.Text) && textBox.Tag?.ToString() == product.Id.ToString())
                    {
                        quantity = int.Parse(textBox.Text);
                    }
                }
                if (quantity > 0)
                {
                    price = product.Price;
                    ExpenseProduct expenseProduct = new ExpenseProduct {Quantity = quantity, ExpenseId = expense.Id, ProductId = product.Id };
                    expenseProducts.Add(expenseProduct);
                    using (AppDbContext db = new AppDbContext())
                    {
                        db.Products.FirstOrDefault(p => p.Id == expenseProduct.ProductId).InStock += quantity;
                        db.SaveChanges();
                    }
                    products.FirstOrDefault(p => p.Id == expenseProduct.ProductId).InStock += quantity;
                }
                
            }
            using (AppDbContext db = new AppDbContext())
            {    
                db.ExpenseProducts.AddRange(expenseProducts);
                db.SaveChanges();
                
            }
            messageOrder.Visibility = Visibility.Visible;
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
