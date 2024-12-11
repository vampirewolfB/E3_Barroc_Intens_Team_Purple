using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarrocIntens.Utility;
using BarrocIntens.Models;
using BCrypt.Net;
using Bogus.DataSets;
using static BarrocIntens.Models.Contract;
using System.Diagnostics;
using System.IO;
using static BarrocIntens.Models.MaintenanceRequest;

namespace BarrocIntens.Utility.Database
{
    internal class AppDbContext : DbContext
    {
        // Alle tabelen in de databse
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Models.Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<CustomInvoice> CustomInvoices { get; set; }
        public DbSet<CustomInvoiceProduct> CustomInvoiceProducts { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractProduct> ContractProducts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseProduct> ExpenseProducts { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteProduct> QuoteProducts { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<MaintenaceAppointment> MaintenaceAppointments { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderHours> WorkOrderHours { get; set; }
        public DbSet<WorkOrderMaterials> WorkOrderMaterials { get; set; }
        public DbSet<MaintenaceAppointmentWorkOrder> MaintenaceAppointmentWorkOrders { get; set; }

        // Aanmaken van een connectie met de database.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            new AppSettingLoader();
            switch (AppSettingLoader.Configuration["AppEnviorment"].ToLower())
            {
                case "local":
                    optionsBuilder.UseMySql(
                        AppSettingLoader.Configuration["Database:ConnectionString"],
                        ServerVersion.Parse(AppSettingLoader.Configuration["Database:ServerVersion"])
                        )
                        .UseModel(AppDbContextModel.Instance)
                        .UseLoggerFactory(Logger.ContextLoggerFactory)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();
                    break;
                default:
                    optionsBuilder.UseMySql(
                        AppSettingLoader.Configuration["Database:ConnectionString"],
                        ServerVersion.Parse(AppSettingLoader.Configuration["Database:ServerVersion"])
                        )
                        .UseModel(AppDbContextModel.Instance);
                    break;
            }
        }

        // Seeden van data in de database.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.Password, f => BCrypt.Net.BCrypt.EnhancedHashPassword("password"))
                    .RuleFor(u => u.RoleId, f => f.Random.ListItem<Role>(roles).Id);

                List<User> users = userFaker.Generate(250);
                users.Add(new User
                {
                    Id = userId++,
                    Name = "adminf",
                    Email = "adminf",
                    Password = BCrypt.Net.BCrypt.EnhancedHashPassword("admin"),
                    RoleId = 1,
                });
                users.Add(new User
                {
                    Id = userId++,
                    Name = "admins",
                    Email = "admins",
                    Password = BCrypt.Net.BCrypt.EnhancedHashPassword("admin"),
                    RoleId = 2,
                });
                users.Add(new User
                {
                    Id = userId++,
                    Name = "admini",
                    Email = "admini",
                    Password = BCrypt.Net.BCrypt.EnhancedHashPassword("admin"),
                    RoleId = 3,
                });
                users.Add(new User
                {
                    Id = userId++,
                    Name = "adminm",
                    Email = "adminm",
                    Password = BCrypt.Net.BCrypt.EnhancedHashPassword("admin"),
                    RoleId = 4,
                });
                users.Add(new User
                {
                    Id = userId++,
                    Name = "adminc",
                    Email = "adminc",
                    Password = BCrypt.Net.BCrypt.EnhancedHashPassword("admin"),
                    RoleId = 5,
                });
                modelBuilder.Entity<User>().HasData(users);

                // List for diffrent user groups
                List<User> sales = users.Where(u => u.RoleId == 2).ToList();
                List<User> customers = users.Where(u => u.RoleId == 5).ToList();

                // Company Seeder
                int companyId = 1;
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
                    .RuleFor(p => p.InStock, f => f.Random.Int(0, 100000))
                    .RuleFor(p => p.ProductCategoryId, f => f.Random.ListItem<ProductCategory>(productCategories).Id);

                List<Product> products = productFaker.Generate(50);
                modelBuilder.Entity<Product>().HasData(products);

                // Note seeder
                int noteId = 1;
                Faker<Note> noteFaker = new Faker<Note>("nl")
                    .RuleFor(n => n.Id, f => noteId++)
                    .RuleFor(n => n.Notes, f => f.Lorem.Text())
                    .RuleFor(n => n.Date, f => f.Date.Recent())
                    .RuleFor(n => n.CompanyId, f => f.Random.ListItem<Models.Company>(companies).Id)
                    .RuleFor(n => n.UserId, f => f.Random.ListItem<User>(sales).Id);

                List<Note> notes = noteFaker.Generate(75);
                modelBuilder.Entity<Note>().HasData(notes);

                // Custom invoice seeder
                int customInvoiceId = 1;
                Faker<CustomInvoice> customerInvoiceFaker = new Faker<CustomInvoice>("nl")
                    .RuleFor(c => c.Id, f => customInvoiceId++)
                    .RuleFor(c => c.Date, f => f.Date.Recent())
                    .RuleFor(c => c.PaidAt, f => f.Date.Recent().OrNull(f))
                    .RuleFor(c => c.CompanyId, f => f.Random.ListItem<Models.Company>(companies).Id);

                List<CustomInvoice> customInvoices = customerInvoiceFaker.Generate(50);
                modelBuilder.Entity<CustomInvoice>().HasData(customInvoices);

                // Custom Invoice Product Seeder
                int customInvoiceProductId = 1;
                Faker<CustomInvoiceProduct> customInvoiceProductFaker = new Faker<CustomInvoiceProduct>("nl")
                    .RuleFor(c => c.Id, f => customInvoiceProductId++)
                    .RuleFor(c => c.Amount, f => f.Random.Int(1, 1000))
                    .RuleFor(c => c.PricePerProduct, f => f.Random.Decimal(0.01m, 10000.00m))
                    .RuleFor(c => c.CustomInvoiceId, f => f.Random.ListItem<CustomInvoice>(customInvoices).Id)
                    .RuleFor(c => c.ProductId, f => f.Random.ListItem<Product>(products).Id);

                List<CustomInvoiceProduct> customInvoiceProducts = customInvoiceProductFaker.Generate(50);
                modelBuilder.Entity<CustomInvoiceProduct>().HasData(customInvoiceProducts);

                // Contracts Seeder
                int contractId = 1;
                Faker<Contract> contractFaker = new Faker<Contract>("nl")
                    .RuleFor(c => c.Id, f => contractId++)
                    .RuleFor(c => c.StartDate, f => f.Date.Between(
                            new DateTime(2015, 1, 1),
                            new DateTime(2023, 12, 31)
                        ))
                    .RuleFor(c => c.EndDate, f => f.Date.Between(
                            new DateTime(2020, 1, 1),
                            new DateTime(2030, 12, 31)
                        ))
                    .RuleFor(c => c.Type, f => f.PickRandom<PaymentTypes>())
                    .RuleFor(c => c.CompanyId, f => f.Random.ListItem<Models.Company>(companies).Id);

                List<Contract> contracts = contractFaker.Generate(50);
                modelBuilder.Entity<Contract>().HasData(contracts);

                // Contract product seeder
                int contractProductId = 1;
                Faker<ContractProduct> contractProductFaker = new Faker<ContractProduct>("nl")
                    .RuleFor(c => c.Id, f => contractProductId++)
                    .RuleFor(c => c.Amount, f => f.Random.Int(1))
                    .RuleFor(c => c.LeassedPrice, f => f.Random.Decimal(0.01m, 10000.00m))
                    .RuleFor(c => c.ContractId, f => f.Random.ListItem<Contract>(contracts).Id)
                    .RuleFor(c => c.ProductId, f => f.Random.ListItem<Product>(products).Id);

                List<ContractProduct> contractProducts = contractProductFaker.Generate(100);
                modelBuilder.Entity<ContractProduct>().HasData(contractProducts);

                // Expense seeder
                int exepenseId = 1;
                Faker<Expense> expenseFaker = new Faker<Expense>("nl")
                    .RuleFor(e => e.Id, f => exepenseId++)
                    .RuleFor(e => e.Date, f => f.Date.Past())
                    .RuleFor(e => e.IsApproved, f => f.Random.Bool())
                    .RuleFor(e => e.UserId, f => f.Random.ListItem<User>(sales).Id);

                List<Expense> expenses = expenseFaker.Generate(50);
                modelBuilder.Entity<Expense>().HasData(expenses);

                // Expense Product seeder
                int expenseProductId = 1;
                Faker<ExpenseProduct> expenseProductFaker = new Faker<ExpenseProduct>("nl")
                    .RuleFor(e => e.Id, f => expenseProductId++)
                    .RuleFor(e => e.Quantity, f => f.Random.Int(1, 1000))
                    .RuleFor(e => e.ProductId, f => f.Random.ListItem<Product>(products).Id)
                    .RuleFor(e => e.ExpenseId, f => f.Random.ListItem<Expense>(expenses).Id);

                List<ExpenseProduct> expenseProducts = expenseProductFaker.Generate(100);
                modelBuilder.Entity<ExpenseProduct>().HasData(expenseProducts);

                // Quote seeder
                int quoteId = 1;
                Faker<Quote> quoteFaker = new Faker<Quote>("nl")
                    .RuleFor(q => q.Id, f => quoteId++)
                    .RuleFor(q => q.Date, f => f.Date.Past())
                    .RuleFor(q => q.UserId, f => f.Random.ListItem<User>(customers).Id);

                List<Quote> quotes = quoteFaker.Generate(50);
                modelBuilder.Entity<Quote>().HasData(quotes);

                // Quote product seeder
                int quoteProductId = 1;
                Faker<QuoteProduct> quoteProductFaker = new Faker<QuoteProduct>("nl")
                    .RuleFor(q => q.Id, f => quoteProductId++)
                    .RuleFor(q => q.Quantity, f => f.Random.Int(1, 1000))
                    .RuleFor(q => q.ProductId, f => f.Random.ListItem<Product>(products).Id)
                    .RuleFor(q => q.QuoteId, f => f.Random.ListItem<Quote>(quotes).Id);

                List<QuoteProduct> quoteProducts = quoteProductFaker.Generate(100);
                modelBuilder.Entity<QuoteProduct>().HasData(quoteProducts);

                // Maintenance Requests seeder
                int maintenanceRequestId = 1;
                Faker<MaintenanceRequest> maintenanceRequestFaker = new Faker<MaintenanceRequest>("nl")
                    .RuleFor(m => m.Id, f => maintenanceRequestId++)
                    .RuleFor(m => m.Title, f => f.Lorem.Word())
                    .RuleFor(m => m.Description, f => f.Lorem.Text())
                    .RuleFor(m => m.Type, f => f.PickRandom<RequestType>())
                    .RuleFor(m => m.UserId, f => f.Random.ListItem<User>(customers).Id);

                List<MaintenanceRequest> maintenanceRequests = maintenanceRequestFaker.Generate(100);
                modelBuilder.Entity<MaintenanceRequest>().HasData(maintenanceRequests);

                // Maintenace Appointments seeder
                int maintenaceAppointmentId = 1;
                Faker<MaintenaceAppointment> maintenaceAppointmentFaker = new Faker<MaintenaceAppointment>("nl")
                    .RuleFor(m => m.Id, f => maintenaceAppointmentId++)
                    .RuleFor(m => m.Remark, f => f.Lorem.Text())
                    .RuleFor(m => m.PlannedDate, f => f.Date.Recent())
                    .RuleFor(m => m.FinishedDate, f => f.Date.Future().OrNull(f, 0.5f))
                    .RuleFor(m => m.UserId, f => f.Random.ListItem<User>(customers).Id);

                List<MaintenaceAppointment> maintenaceAppointments = maintenaceAppointmentFaker.Generate(25);
                modelBuilder.Entity<MaintenaceAppointment>().HasData(maintenaceAppointments);

                // WorkerOrder seeder
                int workOrderId = 1;
                Faker<WorkOrder> workOrderFaker = new Faker<WorkOrder>("nl")
                    .RuleFor(w => w.Id, f => workOrderId++)
                    .RuleFor(w => w.Title, f => f.Lorem.Word())
                    .RuleFor(w => w.Description, f => f.Lorem.Text())
                    .RuleFor(w => w.Date, f => f.Date.Recent());

                List<WorkOrder> workOrders = workOrderFaker.Generate(50);
                modelBuilder.Entity<WorkOrder>().HasData(workOrders);

                // WorkOrder Hour seeder
                int workOrderHourId = 1;
                Faker<WorkOrderHours> workOrderHour = new Faker<WorkOrderHours>("nl")
                    .RuleFor(w => w.Id, f => workOrderHourId++)
                    .RuleFor(w => w.StartTime, f => f.Date.Recent())
                    .RuleFor(w => w.EndTime, f => f.Date.Recent())
                    .RuleFor(w => w.WorkOrderId, f => f.Random.ListItem<WorkOrder>(workOrders).Id);

                List<WorkOrderHours> workOrderHours = workOrderHour.Generate(50);
                modelBuilder.Entity<WorkOrderHours>().HasData(workOrderHours);

                // Workorder Materials seeder
                int workOrderMaterialId = 1;
                Faker<WorkOrderMaterials> workOrderMaterialFaker = new Faker<WorkOrderMaterials>("nl")
                    .RuleFor(w => w.Id, f => workOrderMaterialId++)
                    .RuleFor(w => w.Amount, f => f.Random.Int(1))
                    .RuleFor(w => w.PricePerMaterial, f => f.Random.Decimal(0.01m, 10000.00m))
                    .RuleFor(w => w.ProductId, f => f.Random.ListItem<Product>(products.Where(p => p.Id == 3).ToList()).Id)
                    .RuleFor(w => w.WorkOrderId, f => f.Random.ListItem<WorkOrder>(workOrders).Id);

                List<WorkOrderMaterials> workOrderMaterials = workOrderMaterialFaker.Generate(100);
                modelBuilder.Entity<WorkOrderMaterials>().HasData(workOrderMaterials);

                // MaintenaceAppointment WorkOrder seeder
                int maintenaceAppointmentWorkOrderId = 1;
                Faker<MaintenaceAppointmentWorkOrder> maintenaceAppointmentWorkOrderFaker = new Faker<MaintenaceAppointmentWorkOrder>("nl")
                    .RuleFor(m => m.Id, f => maintenaceAppointmentWorkOrderId++)
                    .RuleFor(m => m.MaintenaceAppointmentId, f => f.Random.ListItem<MaintenaceAppointment>(maintenaceAppointments).Id)
                    .RuleFor(m => m.WorkOrderId, f => f.Random.ListItem<WorkOrder>(workOrders).Id);

                List<MaintenaceAppointmentWorkOrder> maintenaceAppointmentWorkOrders = maintenaceAppointmentWorkOrderFaker.Generate(100);
                modelBuilder.Entity<MaintenaceAppointmentWorkOrder>().HasData(maintenaceAppointmentWorkOrders);
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

        // Functie om een lijst met rollen aan te maken.
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
                new ProductCategory { Id = 1, Name = "CoffeeBeans", IsEmployeeOnly = false},
                new ProductCategory { Id = 2, Name = "Machine", IsEmployeeOnly = false},
                new ProductCategory { Id = 3, Name = "Material", IsEmployeeOnly = true}
                ];
        }
    }
}
