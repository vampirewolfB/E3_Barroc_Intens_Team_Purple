﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarrocIntens.Uttility;
using BarrocIntens.Models;
using BCrypt.Net;
using Bogus.DataSets;

namespace BarrocIntens.Uttility.Database
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Models.Company> Companies { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<MaintenaceAppointment> MaintenaceAppointments { get; set; }
        public DbSet<CustomInvoice> CustomInvoices { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomInvoiceProduct> CustomInvoiceProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                $"server={AppSettingLoader.Configuration["Database:Server"]};" +
                $"port={AppSettingLoader.Configuration["Database:Port"]};" +
                $"user={AppSettingLoader.Configuration["Database:User"]};" +
                $"password={AppSettingLoader.Configuration["Database:Password"]};" +
                $"database={AppSettingLoader.Configuration["Database:Name"]};",
                ServerVersion.Parse(AppSettingLoader.Configuration["Database:ServerVersion"])
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Random rnd = new Random();

            if (AppSettingLoader.Configuration["AppEnviorment"].ToLower() == "local")
            {
                // Seeders for local development all fake data here.

                //Seeder for roles
                List<Role> roles = SeedRoles();
                modelBuilder.Entity<Role>().HasData(roles);

                // User seeder
                int userId = 1;
                Faker<User> userFaker = new Faker<User>("nl")
                    .RuleFor(u => u.Id, f => userId++)
                    .RuleFor(u => u.Name, f => f.Name.FirstName())
                    .RuleFor(u => u.UserName, f => f.Internet.UserName())
                    .RuleFor(u => u.Password, f => BCrypt.Net.BCrypt.EnhancedHashPassword("password"))
                    .RuleFor(u => u.RoleId, f => f.Random.ListItem<Role>(roles).Id);

                List<User> users = userFaker.Generate(250);
                modelBuilder.Entity<User>().HasData(users);

                // Company Seeder
                int companyId = 1;
                List<User> customers = users.Where(u => u.RoleId == 5).ToList();
                Faker<Models.Company> companyFaker = new Faker<Models.Company>("nl")
                    .RuleFor(c => c.Id, f => companyId++)
                    .RuleFor(c => c.Name, f => f.Company.CompanyName())
                    .RuleFor(c => c.Phone, f => f.Phone.PhoneNumberFormat())
                    .RuleFor(c => c.Street, f => f.Address.StreetName())
                    .RuleFor(c => c.HouseNumber, f => f.Address.BuildingNumber())
                    .RuleFor(c => c.City, f => f.Address.City())
                    .RuleFor(c => c.CountryCode, f => f.Address.CountryCode(Iso3166Format.Alpha3))
                    .RuleFor(c => c.BkrCheckedAt, f => f.Date.Past().OrNull(f, .5f))
                    .RuleFor(c => c.UserId, f => f.Random.ListItem<User>(customers).Id);

                List<Models.Company> companies = companyFaker.Generate(100);
                modelBuilder.Entity<Models.Company>().HasData(companies);

                // Note seeder
                int noteId = 1;
                List<User> sales = users.Where(u => u.RoleId == 2).ToList();
                Faker<Note> noteFaker = new Faker<Note>("nl")
                    .RuleFor(n => n.Id, f => noteId++)
                    .RuleFor(n => n.Notes, f => f.Lorem.Text())
                    .RuleFor(n => n.Date, f => f.Date.Recent())
                    .RuleFor(n => n.UserId, f => f.Random.ListItem<User>(sales).Id)
                    .RuleFor(n => n.CompanyId, f => f.Random.ListItem<Models.Company>(companies).Id);

                List<Note> notes = noteFaker.Generate(75);
                modelBuilder.Entity<Note>().HasData(notes);

                // Maintenace Appointments seeder
                int maintenaceAppointmentId = 1;
                Faker<MaintenaceAppointment> maintenaceAppointmentFaker = new Faker<MaintenaceAppointment>("nl")
                    .RuleFor(m => m.Id, f => maintenaceAppointmentId++)
                    .RuleFor(m => m.CompanyId, f => f.Random.ListItem<Models.Company>(companies).Id)
                    .RuleFor(m => m.Remark, f => f.Lorem.Text())
                    .RuleFor(m => m.DateAdded, f => f.Date.Recent());

                List<MaintenaceAppointment> maintenaceAppointments = maintenaceAppointmentFaker.Generate(25);
                modelBuilder.Entity<MaintenaceAppointment>().HasData(maintenaceAppointments);

                // Custom invoice seeder
                int customInvoiceId = 1;
                Faker<CustomInvoice> customerInvoiceFaker = new Faker<CustomInvoice>("nl")
                    .RuleFor(c => c.Id, f => customInvoiceId++)
                    .RuleFor(c => c.Date, f => f.Date.Recent())
                    .RuleFor(c => c.PaidAt, f => f.Date.Recent().OrNull(f))
                    .RuleFor(c => c.CompanyId, f => f.Random.ListItem<Models.Company>(companies).Id);

                List<CustomInvoice> customInvoices = customerInvoiceFaker.Generate(50);
                modelBuilder.Entity<CustomInvoice>().HasData(customInvoices);

                // Product category seeder
                List<ProductCategory> productCategories = SeedProductCategoriesSeeder();
                modelBuilder.Entity<ProductCategory>().HasData(productCategories);

                // Product seeder
                int productId = 1;
                Faker<Product> productFaker = new Faker<Product>("nl")
                    .RuleFor(p => p.Id, f => productId++)
                    .RuleFor(p => p.Name, f => f.Commerce.Product())
                    .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                    .RuleFor(p => p.ImagePath, f => f.Image.PlaceholderUrl(50, 50))
                    .RuleFor(p => p.Price, f => f.Random.Decimal(0.01m, 10000.00m))
                    .RuleFor(p => p.ProductCategoryId, f => f.Random.ListItem<ProductCategory>(productCategories).Id);

                List<Product> products = productFaker.Generate(50);
                modelBuilder.Entity<Product>().HasData(products);

                // Custom Invoice Product Seeder
                int customInvoiceProductId = 1;
                Faker<CustomInvoiceProduct> customInvoiceProductFaker = new Faker<CustomInvoiceProduct>("nl")
                    .RuleFor(c => c.Id, f => customInvoiceProductId++)
                    .RuleFor(c => c.CustomInvoiceId, f => f.Random.ListItem<CustomInvoice>(customInvoices).Id)
                    .RuleFor(c => c.ProductId, f => f.Random.ListItem<Product>(products).Id)
                    .RuleFor(c => c.Amount, f => f.Random.Int(10, 1000))
                    .RuleFor(c => c.PricePerProduct, f => f.Random.Decimal(0.01m, 10000.00m));

                List<CustomInvoiceProduct> customInvoiceProducts = customInvoiceProductFaker.Generate(50);
                modelBuilder.Entity<CustomInvoiceProduct>().HasData(customInvoiceProducts);
            }
            else
            {
                // Seeders for production so only need nescary things here.
                List<Role> roles = SeedRoles();
                modelBuilder.Entity<Role>().HasData(roles);
                List<ProductCategory> productCategories = SeedProductCategoriesSeeder();
                modelBuilder.Entity<ProductCategory>().HasData(productCategories);
            }
        }

        private List<Role> SeedRoles()
        {
            return [
                new Role { Id = 1, Name = "Finance" },
                new Role { Id = 2, Name = "Sales" },
                new Role { Id = 3, Name = "Inkoop" },
                new Role { Id = 4, Name = "Maintenance" },
                new Role { Id = 5, Name = "Customer" },
            ];
        }

        private List<ProductCategory> SeedProductCategoriesSeeder()
        {
            return [
                new ProductCategory { Id = 1, Name = "Boonen", IsEmployeeOnly = false},
                new ProductCategory { Id = 2, Name = "Machine", IsEmployeeOnly = true}
                ];
        }
    }
}