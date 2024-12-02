using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using BarrocIntens.Models;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using SkiaSharp;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BarrocIntens.Utility.Database;
using Microsoft.EntityFrameworkCore;

namespace BarrocIntens.Utility
{
    public class InvoiceDocument : IDocument
    {
        Models.Company company;
        CustomInvoice invoice = null;
        List<Product> products = new List<Product>();
        List<Product> checkProducts = new List<Product>();
        List<CustomInvoiceProduct> invoiceProducts = new List<CustomInvoiceProduct>();
        byte[] logoData;
        internal InvoiceDocument(Company chosenCompany, byte[] imageData, List<Product> products)
        {
            company = chosenCompany;
            logoData = imageData;
            this.products = products;
            using (AppDbContext db = new AppDbContext())
            {
                checkProducts = db.Products.ToList();
            }
        }
        internal InvoiceDocument(CustomInvoice customInvoice, byte[] imageData)
        {
            invoice = customInvoice;
            logoData = imageData;

            using (AppDbContext db = new AppDbContext())
            {
                company = db.Companies.Include(c => c.User).FirstOrDefault(c => c.Id == invoice.CompanyId);
                invoiceProducts = db.CustomInvoiceProducts.Where(p => p.CustomInvoiceId == invoice.Id).Include(ip => ip.Product).ThenInclude(p => p.CustomInvoiceProducts).ToList();

                foreach (CustomInvoiceProduct invoiceProduct in invoiceProducts)
                {
                    products.Add(db.Products.FirstOrDefault(p => p.Id == invoiceProduct.ProductId));
                }
            }
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
        .Page(page =>
        {
            page.Margin(50);

            page.Header().Element(ComposeHeader);

            page.Content().Element(ComposeContent);

            page.Footer().AlignCenter().Text(text =>
            {
                text.CurrentPageNumber();
                text.Span(" / ");
                text.TotalPages();
            });
        });
        }
        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column
                        .Item().Text($"Invoice")
                        .FontSize(20).SemiBold();
                    column.Item().Text(text =>
                    {
                        text.Span($"{company.Name}").Bold();
                    });
                    column.Item().Text(text =>
                    {
                        text.Span($"{company.Street}");
                        text.Span($"{company.HouseNumber}");
                    });
                    column.Item().Text(text =>
                    {
                        text.Span($"{company.CountryCode},");
                        text.Span($"{company.City}");
                    });
                    column.Item().Element(e => e.Height(20));
                    column.Item().Text(text =>
                    {
                        text.Span("Period:").SemiBold();
                        text.Span($"{DateTime.Now:d}");
                    });
                    column.Item().Text(text =>
                    {
                        text.Span("Clientnr.:").SemiBold();
                        text.Span($"{company.User.Id}");

                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Due date: ").SemiBold();
                        text.Span($"{DateTime.Now.AddDays(14)}");
                    });
                    column.Item().Text(text =>
                    {
                        text.Span("InvoiceNr: ").SemiBold();
                        if (invoice == null)
                        {
                            text.Span($"Preview");
                        }
                        else
                        {
                            text.Span($"{invoice.Id}");
                        }
                    });
                });
                row.RelativeItem().Column(column =>
                {
                    column.Item().Width(175).Image(logoData);
                    column.Item().AlignRight().Text("Barroc Intens").FontSize(12).Italic();
                    column.Item().AlignRight().Text("Terheijdenseweg 350").FontSize(12).Italic();
                    column.Item().AlignRight().Text("4826 AA Breda").FontSize(12).Italic();
                });

            });
        }
        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(5);
                column.Item().Background(Colors.Yellow.Medium).Height(7);
                column.Item().Element(e => e.Height(20));
                column.Item().Element(ComposeTable);
                column.Item().AlignRight().Text(text =>
                {
                    decimal totalPrice = 0;
                    foreach (Product product in products)
                    {
                        if (invoice != null)
                        {
                            totalPrice += product.Price * invoiceProducts.FirstOrDefault(ip => ip.ProductId == product.Id).Amount;
                        }
                        else
                        {
                            totalPrice += product.Price;
                        }
                    }
                    text.Span("Grand Total: €").FontSize(20);
                    text.Span($"{totalPrice}").FontSize(20);
                });
                column.Item().Element(e => e.Height(20));
                column.Item().Text("To pay within 14 days after day of signing").FontSize(12).Italic();
            });
        }
        void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                // step 1
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                // step 2
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("#");
                    header.Cell().Element(CellStyle).Text("Product");
                    header.Cell().Element(CellStyle).AlignRight().Text("Unit price");
                    header.Cell().Element(CellStyle).AlignRight().Text("Quantity");
                    header.Cell().Element(CellStyle).AlignRight().Text("Subtotal");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                foreach (Product product in products)
                {
                    table.Cell().Element(CellStyle).Text($"{product.Id}");
                    table.Cell().Element(CellStyle).Text($"{product.Name}");
                    if (checkProducts.Count <= 0)
                    {
                        table.Cell().Element(CellStyle).AlignRight().Text($"€{product.Price}");
                        table.Cell().Element(CellStyle).AlignRight().Text($"{invoiceProducts.FirstOrDefault(ip => ip.ProductId == product.Id).Amount}");
                        table.Cell().Element(CellStyle).AlignRight().Text($"{product.Price * invoiceProducts.FirstOrDefault(ip => ip.ProductId == product.Id).Amount}");
                    }
                    else
                    {
                        table.Cell().Element(CellStyle).AlignRight().Text($"€{checkProducts.FirstOrDefault(p => p.Id == product.Id).Price}");
                        table.Cell().Element(CellStyle).AlignRight().Text($"{product.Price / checkProducts.FirstOrDefault(p => p.Id == product.Id).Price}");
                        table.Cell().Element(CellStyle).AlignRight().Text($"€{product.Price}");
                    }


                    static IContainer CellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }
    }
}
