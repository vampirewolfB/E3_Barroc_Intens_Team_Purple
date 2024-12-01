using BarrocIntens.Models;
using BarrocIntens.Uttility.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ScottPlot;
using ScottPlot.LegendLayouts;
using ScottPlot.WinUI;
using static BarrocIntens.Finance.MonthYearOverviewPage;
using Bogus.Bson;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Windows.UI;
using ScottPlot.TickGenerators.Financial;
using SkiaSharp;
using LiveChartsCore.Drawing;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BarrocIntens.Finance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MonthYearOverviewPage : Page
    {


        List<string> months = new List<string>
            {
                "Jan", "Feb", "Mar", "Apr", "May", "Jun", "jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            };

        public MonthYearOverviewPage()
        {
            this.InitializeComponent();
            year.Text = DateTime.Now.Year.ToString();


            CreateGraphDataYear(year.Text);
            CreateGraphDataColumn(year.Text);

            
            
        }
        private void Year_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void year_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(year.Text))
            {
                CreateGraphDataYear(year.Text);
                CreateGraphDataColumn(year.Text);
            }    
        }
        private void CreateGraphDataColumn(string year)
        {
            List<decimal> profit = new List<decimal>();
            List<decimal> expense = new List<decimal>();
            using (AppDbContext db = new AppDbContext())
            {
                List<CustomInvoice> invoices = db.CustomInvoices.Where(i => i.PaidAt.Value.Year == int.Parse(year)).Include(i => i.CustomInvoiceProducts).ThenInclude(ip => ip.Product).ToList();
                List<Quote> quotes = db.Quotes.Where(q => q.Date.Year == int.Parse(year)).Include(q => q.QuoteProducts).ThenInclude(qp => qp.Product).ToList();
                List<Expense> expenses = db.Expenses.Where(e => e.Date.Year == int.Parse(year) && e.IsApproved == true).Include(e => e.ExpenseProducts).ThenInclude(ep => ep.Product).ToList();
                for (int i = 1; i < months.Count; i++)
                {
                    decimal price = 0;
                    decimal expensePrice = 0;
                    //get the price from invoices
                    foreach (CustomInvoice invoice in invoices)
                    {
                        if (invoice.PaidAt.Value.Month == i)
                        {
                            foreach (CustomInvoiceProduct invoiceProduct in invoice.CustomInvoiceProducts)
                            {
                                price += invoiceProduct.Product.Price * invoiceProduct.Amount;
                            }
                        }
                    }
                    //get the price from quotes
                    foreach (Quote quote in quotes)
                    {
                        if (quote.Date.Month == i)
                        {
                            foreach (QuoteProduct quoteProduct in quote.QuoteProducts)
                            {
                                price += quoteProduct.Product.Price * quoteProduct.Quantity;
                            }
                        }
                    }
                    //get the expenseprice from expenses
                    foreach (Expense expense1 in expenses)
                    {
                        if (expense1.Date.Month == i)
                        {
                            foreach (ExpenseProduct expenseProduct in expense1.ExpenseProducts)
                            {
                                expensePrice += expenseProduct.Product.Price * expenseProduct.Quantity;
                            }
                        }
                    }
                    profit.Add(price);
                    expense.Add(expensePrice);
                }
            }

            // Create ColumnSeries for Sales (columns)
            ColumnSeries<decimal> profitSeries = new ColumnSeries<decimal>
            {
                Values = profit, // Sales data values
                Name = "Profit",
                Fill = new SolidColorPaint(SKColors.LightSkyBlue), // Column color
               
            };
            ColumnSeries<decimal> expenseSeries = new ColumnSeries<decimal>
            {
                Values = expense, // Sales data values
                Name = "Expense",
                Fill = new SolidColorPaint(SKColors.Red) // Column color
            };

            // Set up the chart with the ColumnSeries
            ColumnChartView.Series = new List<ISeries> { profitSeries, expenseSeries };

            // Set up X-Axis labels (Months)
            ColumnChartView.XAxes = new List<Axis>
            {
                new Axis
                {
                    Labels = new List<string>
                    {
                        "Profit|Expense"
                    },
                    LabelsPaint = new SolidColorPaint(SKColor.Parse("#ffd700")),
                    UnitWidth = ColumnChartView.Width / 2,
                }
            };
            // Set up Y-Axis for Sales Amount
            ColumnChartView.YAxes = new List<Axis>
            {
                new Axis
                {
                    Labeler = value => value.ToString("C"), // Format axis labels as currency
                    LabelsPaint = new SolidColorPaint(SKColor.Parse("#ffd700")),
                    MinLimit = 0,
                    SeparatorsPaint = new SolidColorPaint(SKColor.Parse("#ffd700")),
                }
            };

        }
        private void CreateGraphDataYear(string year)
        {
            List<decimal> profit = new List<decimal>();
            List<decimal> expense = new List<decimal>();
            using (AppDbContext db = new AppDbContext())
            {
                List<CustomInvoice> invoices = db.CustomInvoices.Where(i => i.PaidAt.Value.Year == int.Parse(year)).Include(i => i.CustomInvoiceProducts).ThenInclude(ip => ip.Product).ToList();
                List<Quote> quotes = db.Quotes.Where(q => q.Date.Year == int.Parse(year)).Include(q => q.QuoteProducts).ThenInclude(qp => qp.Product).ToList();
                List<Expense> expenses = db.Expenses.Where(e => e.Date.Year == int.Parse(year) && e.IsApproved == true).Include(e => e.ExpenseProducts).ThenInclude(ep => ep.Product).ToList();
                for (int i = 1; i < months.Count; i++)
                {
                    decimal price = 0;
                    decimal expensePrice = 0;
                    //get the price from invoices
                    foreach (CustomInvoice invoice in invoices)
                    {
                        if (invoice.PaidAt.Value.Month == i)
                        {
                            foreach (CustomInvoiceProduct invoiceProduct in invoice.CustomInvoiceProducts)
                            {
                                price += invoiceProduct.Product.Price * invoiceProduct.Amount;
                            }
                        }
                    }
                    //get the price from quotes
                    foreach (Quote quote in quotes)
                    {
                        if (quote.Date.Month == i)
                        {
                            foreach (QuoteProduct quoteProduct in quote.QuoteProducts)
                            {
                                price += quoteProduct.Product.Price * quoteProduct.Quantity;
                            }
                        }
                    }
                    //get the expenseprice from expenses
                    foreach (Expense expense1 in expenses)
                    {
                        if (expense1.Date.Month == i)
                        {
                            foreach (ExpenseProduct expenseProduct in expense1.ExpenseProducts)
                            {
                                expensePrice += expenseProduct.Product.Price * expenseProduct.Quantity;
                            }
                        }
                    }
                    profit.Add(price);
                    expense.Add(expensePrice);
                }
            }

            // Create LineSeries for Profit
            LineSeries<Decimal> profitSeries = new LineSeries<Decimal>
            {
                Values = profit,
                Name = "Profit",
                LineSmoothness = 0.5,
                Stroke = new SolidColorPaint(SkiaSharp.SKColors.LightSkyBlue), // Set color for the profit line
                Fill = new SolidColorPaint(SkiaSharp.SKColors.LightBlue),
                GeometryStroke = new SolidColorPaint(SkiaSharp.SKColors.LightSkyBlue),
                GeometryFill = new SolidColorPaint(SkiaSharp.SKColors.LightSkyBlue)
            };

            // Create LineSeries for Expense
            LineSeries<Decimal> expenseSeries = new LineSeries<Decimal>
            {
                Values = expense,
                Name = "Expense",
                LineSmoothness = 0.5,
                Stroke = new SolidColorPaint(SkiaSharp.SKColors.Red),
                Fill = new SolidColorPaint(SkiaSharp.SKColors.IndianRed),
                GeometryStroke = new SolidColorPaint(SkiaSharp.SKColors.Red),
                GeometryFill = new SolidColorPaint(SkiaSharp.SKColors.Red)
            };
            // Set up the chart with both series
            ChartView.Series = new List<ISeries> { profitSeries, expenseSeries };

            // Set up X-Axis labels (Months)
            ChartView.XAxes = new List<Axis>
            {
                new Axis
                {
                    Labels = months,
                    LabelsPaint = new SolidColorPaint(SKColor.Parse("#ffd700")),
                }
            };

            // Set up Y-Axis for Amount (linear scale)
            ChartView.YAxes = new List<Axis>
            {
                new Axis
                {
                    Labeler = value => value.ToString("C"), // Format axis labels as currency
                    LabelsPaint = new SolidColorPaint(SKColor.Parse("#ffd700")),
                    MinLimit = 0,
                    SeparatorsPaint = new SolidColorPaint(SKColor.Parse("#ffd700")),
                }
            };
        }
    }
}
