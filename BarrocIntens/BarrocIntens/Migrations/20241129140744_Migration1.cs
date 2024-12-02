using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarrocIntens.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEmployeeOnly = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HouseNumber = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryCode = table.Column<string>(type: "varchar(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BkrCheckedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Type = table.Column<string>(type: "enum('Monthly','Perodic')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomInvoices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaintenaceAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenaceAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenaceAppointments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Notes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: true),
                    QuoteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomInvoiceProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomInvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PricePerProduct = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomInvoiceProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomInvoiceProducts_CustomInvoices_CustomInvoiceId",
                        column: x => x.CustomInvoiceId,
                        principalTable: "CustomInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomInvoiceProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExpenseProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseProducts_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuoteProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuoteProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteProducts_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "IsEmployeeOnly", "Name" },
                values: new object[,]
                {
                    { 1, (sbyte)0, "CoffeeBeans" },
                    { 2, (sbyte)1, "Machine" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Finance" },
                    { 2, "Sales" },
                    { 3, "Inkoop" },
                    { 4, "Maintenance" },
                    { 5, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ExpenseId", "ImagePath", "Name", "Price", "ProductCategoryId", "QuoteId" },
                values: new object[,]
                {
                    { 1, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Hoed", 976.479943074312454768m, 1, null },
                    { 2, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Zeep", 4163.99162918489682931m, 1, null },
                    { 3, "The Football Is Good For Training And Recreational Purposes", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Bijzettafeltje", 4222.04016454866341695m, 2, null },
                    { 4, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Tonijn", 3092.03419877854919416m, 1, null },
                    { 5, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Hoed", 8754.9428005573445011m, 2, null },
                    { 6, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Handdoeken", 9414.88078102926409054m, 2, null },
                    { 7, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Tafel", 3970.59464580064361074m, 1, null },
                    { 8, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Zeep", 138.487382818316704162m, 1, null },
                    { 9, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Toetsenbord", 835.142987155888710289m, 2, null },
                    { 10, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Hangmat", 1.28742624862656394591m, 1, null },
                    { 11, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Computer", 8918.56221842275301611m, 1, null },
                    { 12, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Hoed", 7446.13971044988341296m, 2, null },
                    { 13, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Chips", 3583.21055994998684587m, 2, null },
                    { 14, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Auto", 5266.36078351112013283m, 1, null },
                    { 15, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Boekenkast", 2970.76029862580062093m, 1, null },
                    { 16, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Toetsenbord", 6835.95750079432325134m, 1, null },
                    { 17, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Hangmat", 3351.64127014758821779m, 1, null },
                    { 18, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Pizza", 6630.53152793010154174m, 1, null },
                    { 19, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Tonijn", 8666.11478983786404868m, 2, null },
                    { 20, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Leunstoel", 8888.59777431011709322m, 2, null },
                    { 21, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Salade", 2337.92789826643381333m, 2, null },
                    { 22, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Toetsenbord", 1617.21756731696547385m, 2, null },
                    { 23, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Muis", 7865.09397530457960358m, 2, null },
                    { 24, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Muis", 5859.64466703828332119m, 1, null },
                    { 25, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Hoed", 1490.73294459423468133m, 2, null },
                    { 26, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Kip", 3423.9709165261595095m, 1, null },
                    { 27, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Broek", 7021.20458355295524544m, 2, null },
                    { 28, "The Football Is Good For Training And Recreational Purposes", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Spek", 9235.58405571662870008m, 1, null },
                    { 29, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Tafel", 2687.69720438592792418m, 2, null },
                    { 30, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Muis", 1319.21372889443190052m, 1, null },
                    { 31, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Auto", 8275.5676787689456651m, 2, null },
                    { 32, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Kaas", 6244.81630888118630626m, 1, null },
                    { 33, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Vis", 2924.51019395654154034m, 1, null },
                    { 34, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Kaasschaaf", 2155.79060596331825392m, 2, null },
                    { 35, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Poef", 2820.83869606883309965m, 1, null },
                    { 36, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Kip", 1229.28289667716404871m, 2, null },
                    { 37, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Trui", 618.413084594133002164m, 1, null },
                    { 38, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Fiets", 9809.53883189222856913m, 2, null },
                    { 39, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Fiets", 5877.70212536245693954m, 1, null },
                    { 40, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Shirt", 1475.62427183228255197m, 2, null },
                    { 41, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Poef", 221.998095015574996108m, 1, null },
                    { 42, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Chips", 1590.67037378107555696m, 1, null },
                    { 43, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Hoed", 3226.12735367003020939m, 2, null },
                    { 44, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Bal", 6566.96873427723875746m, 1, null },
                    { 45, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Worstjes", 8582.05247496643298251m, 1, null },
                    { 46, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Toetsenbord", 8375.53481418434028247m, 1, null },
                    { 47, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Poef", 8302.03112002132794925m, 1, null },
                    { 48, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Boekenkast", 2684.69286277966253479m, 2, null },
                    { 49, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Stoel", 5842.73341161259565815m, 1, null },
                    { 50, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, "https://via.placeholder.com/50x50/cccccc/9c9c9c.png", "Auto", 8908.87573095987016549m, 2, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Password", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, "Tim", "$2a$11$4V9UsaDYFqrWig9MF9Tp2eCPxFXc2EOfWRao2Rxne3JkYE6d7eRdy", 4, "Roos51" },
                    { 2, "Stijn", "$2a$11$RRT.IsRxKUwHxKTiNSiuiew.NugMD726WqhbkEhXpWFYTiph4ObbC", 5, "Emma5" },
                    { 3, "Britt", "$2a$11$sibKfnvccAO8uqttLw/NNuylwV18HZlhZfU1gP7dpQuT1lJPAU/RK", 1, "Jasper_Bosch" },
                    { 4, "Thijs", "$2a$11$WpsVRzRg4af3VeI52IjlLeYh8Q5L5a4jblt7sT9zqvdbgJeA9Dy7K", 1, "Kevin_Willems83" },
                    { 5, "Max", "$2a$11$o4d.RQ/AmRvoNkIreTe1c./AFNUjih60SYIPxLhzvKTjoLfrPVGiC", 4, "Thomas.Brink" },
                    { 6, "Anouk", "$2a$11$hgFO2jcb4EqvsjBQe.22r.3die2O7WgpkbR5f3JKIhEJghkd8zGn6", 5, "Mike76" },
                    { 7, "Bas", "$2a$11$ySHU5/SlQsdivAkIiOi2J.818TUk2hQEJBaTd.whUBObsLQ9wNXmq", 5, "Anne_Smits99" },
                    { 8, "Nick", "$2a$11$wuEAJ98XOOL22o3Kfe.i0ObX2GglY8Bnv6uRQHYpYCt3SjTitvBRC", 3, "Nick.Ruiter92" },
                    { 9, "Max", "$2a$11$4w3cGsCgw77MO8pKWGVG8.F7hIIPgcaHLze5z6PgnvqgKrCPXbwzS", 4, "Julia.Vermeulen44" },
                    { 10, "Anna", "$2a$11$7JlwoVC4UYeAWkDq31b6fOxTVbwRk1wjTRPXNyZSlcCPU5DY8Ddbq", 2, "Jesse_Dijk" },
                    { 11, "Jasper", "$2a$11$uRpMbrWo52Nv5Gbee6vb8OqYFJFhv3Bg66RbmkYNw4ctDSX/4FuIS", 5, "Eva16" },
                    { 12, "Sanne", "$2a$11$SqOIkRuPq/U/IAeJA.fQCeA9pNQP6LGxIZ8k4UWSRK9URjm22vIEC", 4, "Emma43" },
                    { 13, "Isa", "$2a$11$G/n/blgPCj4NIlfsrzDI0u0cgJ/05iB46FoXtWpeiuZPU8UYPJ3CS", 3, "Eva27" },
                    { 14, "Anne", "$2a$11$XXwpnDxjzW6zJAFc8zieDOnoV3mNd/Fxx43DUq.YGWhZGlXfJwpee", 2, "Anouk18" },
                    { 15, "Jesse", "$2a$11$OdYFal.kpXtzpqjX2zVyWO4btNdqItK2eKQxS8DmFDFup1qFiifpa", 4, "Emma_Brouwer" },
                    { 16, "Lotte", "$2a$11$6OZb3JlnbvhZKfScRH5eOuxpho1JhmAKsA1iRpOGeI.O441JhMBo6", 2, "Stijn.Smits22" },
                    { 17, "Luuk", "$2a$11$VtXOeNmAhahLA6H8sLt8z.evuD4hoFZfRuUuSpyC4amqru6BchO5.", 1, "Niels.Jansen" },
                    { 18, "Eva", "$2a$11$E9DorGJWtURvdZ5c1x6IROuz67fwgeP8tdJTQgbe0FvRi0dm1.hhe", 5, "Anna.Jansen" },
                    { 19, "Lars", "$2a$11$WyUzH6zOa7e.HDnlKWVwmu25aNQIQfPWygTqeXA2MzdhMg6ZXbKWW", 1, "Thijs65" },
                    { 20, "Lucas", "$2a$11$WfmmAudM24ZNCPdSVWNhVuqa5P.Q9.eiCzNShfpjRUDIS9ZZFKEeS", 1, "Jan.Visser" },
                    { 21, "Jasper", "$2a$11$C24tGifi2jHvNvClAJtTR.NEAZQGNrSq9Ts4WAkItzcR2TzYs9/Py", 3, "Thomas_Beek18" },
                    { 22, "Maud", "$2a$11$flrfPL47VZ1vmtQe73x0CuGVaq6OPAW/RU7PXT2CBtIErX3Qi2TT2", 4, "Noa31" },
                    { 23, "Sophie", "$2a$11$mbG0/cBUTcoaB9fa0.91ieAEwS02LvrPkSMji7aBHBCAAD9y6pLi6", 5, "Stijn.Vliet40" },
                    { 24, "Bram", "$2a$11$re.q7EXy4NbH41lvx7ozdeJGEId6OiGB1KLzlr7422sGx9jxmKI9W", 4, "Fleur61" },
                    { 25, "Julian", "$2a$11$l4XeTQ.IspVXz0TcyNX7Aubl.goKnIfp338Yzx5h9b/YbUYCaUazm", 4, "Mike41" },
                    { 26, "Jesse", "$2a$11$6K.Eehtf/1t6N0BD63cqAeYcyw9caNpqrNKtkY9GAhhKDhqm.gc4C", 3, "Sven_Linden69" },
                    { 27, "Johannes", "$2a$11$m0N2R50AV/qnNRjS/nnkr.cdfhNgv7rCl3Xv1sb5a4Q4cvRrcuhBW", 4, "Max48" },
                    { 28, "Stijn", "$2a$11$1CdKC852ZhCYzxMspnI4ieDtioxzUP/KYsm.vbinfB3bp3aPFkzvC", 4, "Bram75" },
                    { 29, "Jasper", "$2a$11$GL20lMyzbgvxsLfhcjm9B.d1n6fjhA9qsgQkBzw2i//3.jRJYhD1a", 3, "Stijn40" },
                    { 30, "Lucas", "$2a$11$bug9zh3uJ8A5eHJW7uS6tuWoIp.a4TF2r8UVKLjRes6ZHmkGtlxXa", 3, "Lisa_Meijer" },
                    { 31, "Fleur", "$2a$11$TuXSQs5kb1RXEgvqNYQs1.OT7UxLtn0bAEw1ZF6RvBZprRpfSoFFG", 1, "Isa92" },
                    { 32, "Jasper", "$2a$11$t732Gt2BZsBbiiKrn7a8PeL7GpHaQQJ3qk26F2PvPXz9r6xPUr272", 2, "Anne13" },
                    { 33, "Jesse", "$2a$11$s8m/y/zfHw1k6tvJ1OY30uagfjscCmymWxZMQ9qtnmFMdqoCHBbZa", 1, "Jayden.Vries54" },
                    { 34, "Bram", "$2a$11$wudzEeKEswx1cdLbOYgXa.s6YEvGOG9cwJt4hDpbtLmitg2HZZsCa", 3, "Tom65" },
                    { 35, "Kevin", "$2a$11$FDLVkQi10uR.zpnyEcGrOeTxuQN1cZjxt6nu6izvtH1gJz9FqKseq", 2, "Kevin.Bosch97" },
                    { 36, "Nick", "$2a$11$YXMdkgFitWprx3nWXYpRpOek6LLSN8bjsgLgCok3MXQ1CGD489q2W", 3, "Lucas.Smit" },
                    { 37, "Niels", "$2a$11$AhR8Eq6SZu7NGDJP14LdHO9y8vCsDFaehjpg/00Stq6.Y4fR7OgY.", 1, "Anne_Stichting" },
                    { 38, "Anouk", "$2a$11$ZmVkJ1qRPgbesJtbHKkgS.Epp6iYHmIabcZ0PfwqHpNSemzCpd8MK", 5, "Rick_Leeuwen" },
                    { 39, "Julia", "$2a$11$MZIQIZu.21hwhXZDieJKjuOViyoDx9PYw/yZrU4uunQ7cB434Zq72", 4, "Fleur40" },
                    { 40, "Ruben", "$2a$11$6w5k5aeGSTk8kf2LT4W2YexHNY7iyrHAKPQP2wWrEU/qoXj4/BzA2", 3, "Sophie_Jong" },
                    { 41, "Lieke", "$2a$11$.bHTVQB9HE/sB/cy1qDQFe6hPNfVhuG3fY14rkihdvYa7PX4pqHq6", 4, "Daan4" },
                    { 42, "Sander", "$2a$11$y/5IoDUTMZdVrVpvZulbdeO2cf8zb.4RwvCIdXgDRTNwa7hgK0Bjq", 5, "Bram47" },
                    { 43, "Anne", "$2a$11$NPZBzUsjonGgwoMAlj7AXODv.mWJQ.BYJrS4hrt5IpkbGgC39sOE.", 4, "Milan_Mulder" },
                    { 44, "Femke", "$2a$11$nx1MPSFEg4qcODg9MHUjbOV7HqZN8xC4GAR3rIpPzsEvgwQIEntk2", 4, "Amber_Leeuwen" },
                    { 45, "Lars", "$2a$11$y/4Mb71PfUdnKf5rJpntoulDGzpOzt4GRUo5KFBkBq1ZvUm7e0E1G", 1, "Amber.Kok" },
                    { 46, "Bas", "$2a$11$gRPWkXVFLDsdPyjK2vgA2eeyvvDHg0s520ly4YlJims/G1t4syZjO", 4, "Jesse_Mulder61" },
                    { 47, "Rick", "$2a$11$gT4dgCEsKDaC7B.Qxca7XOTJTS1C32niRyfUejIkD/1B9BI2zoAgW", 2, "Stijn.Mulder" },
                    { 48, "Lotte", "$2a$11$xZtFAmzZCUoDo7somp0Qe..PIphDgxjXDNpiDyV/W/F0XBqVfzxpm", 4, "Maud.Leeuwen" },
                    { 49, "Lars", "$2a$11$5udOTeQHTq/KZRb2EiS1Mu/8GBMpk2b9Haomf/9cKAgj5jIunV1d2", 2, "Lieke.Veen49" },
                    { 50, "Lotte", "$2a$11$V5yOyoNZVeYAiWSB7b0fselE74LOyG9T2wnWCciUi4OztWRaAF6UK", 2, "Roos_Dam" },
                    { 51, "Luuk", "$2a$11$niywVs0VcDOnhaG/wme8keDXzf8tFuA6w.h1YXoUUMOwBqHcHfbo.", 3, "Emma_Hoek6" },
                    { 52, "Ruben", "$2a$11$iW25UOwj7Ueb9TNZm77jDe9nnLTyLhF5Y5mTfMpDakNoB4LcP5N1.", 1, "Kevin75" },
                    { 53, "Jayden", "$2a$11$8O4t5ZTUqS7xCWkug1kJ2un227zCUdS6OL8WbMu9idzwqZVQtw9jC", 1, "Femke71" },
                    { 54, "Isa", "$2a$11$pw4NGO7H7xamLKqMEAemvu7KeWK5Y/TwVFi9ZIujpm.7dWISBFv8a", 5, "Anouk.Haan59" },
                    { 55, "Finn", "$2a$11$SMptTZ29JtDxgcK4BMmPju.qn1WcKn.Upd0HdOI0hSlMAEjIL6eDu", 1, "Anne.Dijk" },
                    { 56, "Kevin", "$2a$11$uaN4/DKp6xx4oKFTSFtpjOXoDvuKWPpKbEMSIuefnJm2Mt3IPaVdq", 1, "Eva.Brink81" },
                    { 57, "Sanne", "$2a$11$QHGJMTuyqisUYkl0rfUTruKuxJ2q0tPPGT8UbSUzwhp/zNFeSjBGK", 5, "Thijs20" },
                    { 58, "Julia", "$2a$11$6jjNKyScsTUnesqjcLPnReJCWgUsm0jB6wSeBWgpoVlYiKHcl8nvi", 1, "Roos.Willems" },
                    { 59, "Femke", "$2a$11$chWZFguIgY/rPFt6uXPrAujHq4yPf/Qr9kx3M7RS1NuweTv.PfOSS", 1, "Thomas.Maas" },
                    { 60, "Finn", "$2a$11$StpYTDNspSY78/d711ULsei4k4LYzmPcbivMN21jldu9U22Rtc7A6", 5, "Thijs_Mulder" },
                    { 61, "Stijn", "$2a$11$waXYZCnAwGLK7mTJCBeGnOufmfA1JJVDYDj05aTtxSO5vvUIJJfL2", 3, "Isa17" },
                    { 62, "Bram", "$2a$11$3X48LUw0Uzz6r4/qOOd1/uwyjrL2RVDi6Mm.o5bm2sWIfChYodOEO", 2, "Britt54" },
                    { 63, "Jayden", "$2a$11$DBda7R3a1djXNcWsoFmU7uC4xUvtqued.aAGxqKDUe6FgGoTUaaD2", 3, "Maud.Ruiter15" },
                    { 64, "Finn", "$2a$11$GquS4CWilcaK63TjwIH0eeGaWzH9FWR9b8y8iGQXGhFVD9Zb/N4D.", 5, "Stijn_Leeuwen" },
                    { 65, "Luuk", "$2a$11$15EjM5cYGTH9Q6aALb0yhuU0gtkCmMzxO3OiVWoQW9mXTttGgxdne", 5, "Julia.Janssen47" },
                    { 66, "Iris", "$2a$11$y2X7WIs6hLjulPazvahmG.fkgDypWerdvjLHqIh7mHAMHrwp3CPY2", 4, "Sander.Jacobs" },
                    { 67, "Kevin", "$2a$11$fCcqSoY7fvFcJmshJWT9HeYTrjMm1/bucdxLBEkp/wf1C75uUjGoi", 2, "Sven_Ven79" },
                    { 68, "Isa", "$2a$11$Kj8lvG5gmVmPJe3R5u6gzujU0Rxa47ryYgkMX7a4Wms.1EmnU0N7.", 4, "Roos71" },
                    { 69, "Britt", "$2a$11$I96hXKwEeWqrMLxVzl6n1erfPSu93yFNzkPkLy7l2QRhkWvU/d5xS", 3, "Tom.Ven48" },
                    { 70, "Anne", "$2a$11$DahMsycJp9XpWXatW9jeAOLFPU0YTuC8VMae8LyT4LKsleDDw04/m", 2, "Lucas_Dam99" },
                    { 71, "Lucas", "$2a$11$hE.fooHm6WL09shecvr6QuzCmWcTrJwDYshsjxYTEsTuZBKXIwo4O", 5, "Stijn2" },
                    { 72, "Sven", "$2a$11$1u2FFthKq8Hy8VK.4Ivmf.whDOCpVQ6JePOonqT.tlURxI5FzzL9u", 5, "Sophie.Vermeulen" },
                    { 73, "Anne", "$2a$11$NmTish3Vwab/M02DqaU2t.OBiDVFosj6gaq/UFI2oGsi011sMG7Pm", 4, "Luuk_Willems16" },
                    { 74, "Bas", "$2a$11$k3UZOSooJW46.oSIvTqcAeV8z/uGGlDAog5EieCARo4iJBNJGS80O", 5, "Daan.Hoek97" },
                    { 75, "Milan", "$2a$11$FcnPcA3aBY3PxbEg6pHRT.OIQGUGvXAZlpLPIVz4ld/u..VGAYGSi", 1, "Mike1" },
                    { 76, "Iris", "$2a$11$S6x9JiO3iG7IJZ5qQfdR9.BLypAAN3ZSJWczCDVh9wcmJjSZbyD.K", 3, "Ruben.Vliet50" },
                    { 77, "Finn", "$2a$11$0aVmtGjadC/aM6rKtp4D8uRz8p2AkCWhg4eQlaSIhRMrMoefokO.6", 1, "Thijs.Willems12" },
                    { 78, "Stijn", "$2a$11$xy7xDkLa5mBBlF4caQUiKOM8V3EKP32ckD./H.UtmHjO5qmSmQM7O", 4, "Niels_Janssen62" },
                    { 79, "Iris", "$2a$11$/NyR/Y2.OlqZmbi5qLOV/.EhPKhkM4/MGtYPRi2RGUIJihxF0eMMy", 1, "Jan36" },
                    { 80, "Jayden", "$2a$11$h0IMfwhwb5LZJ9w1Hb/3Pu0I5oCd6uWQKiK8WRIAGJUDFVRYqRnRS", 5, "Jayden50" },
                    { 81, "Isa", "$2a$11$2IN1ul5jGimPs0Dg4XGqNuPXi0R7fN1TZ0rTbv1qA8F2dXLYsqLR.", 2, "Jasper.Kok92" },
                    { 82, "Julian", "$2a$11$kyYu.0vvRQFwEtL6y8pJc.iS4mqGPKcU0O5sR2E6xQVMYY.zSKNqi", 5, "Milan_Wal" },
                    { 83, "Kevin", "$2a$11$5pk6B5EQcKtItsUhlhNJmOPWUnaEp.6weT3RrxMsZhe4Z.Nl9cfBa", 2, "Lisa_Vos72" },
                    { 84, "Bas", "$2a$11$R9rlbnFIRq0xu0t6pPihte7rsu6/XNIngtWU5Tq4Mrz67xCQAXZYq", 1, "Thomas94" },
                    { 85, "Julia", "$2a$11$EInrgzYCIGqmw0QCFiCLZeGHtAILnuNWWPbPGUTeW2Rt4bZwQVQuG", 5, "Lars_Dam60" },
                    { 86, "Sanne", "$2a$11$GM6hVe8NEgCuUNl4hS8vc.YWOolk0CBewoRryDq2.1JwjF0e7O34C", 1, "Lars.Hoek" },
                    { 87, "Anne", "$2a$11$VOeYIYBgy.mOxcVzyOQ7qubuZFQ9IwoCEkyQoWgi2gy2X9og3t7eO", 4, "Roos.Smit91" },
                    { 88, "Iris", "$2a$11$aHO1ykSocG/yV8bBYuLyZO8WhCpi1tAd9TMhKudyZ8AS/a7tTfxJu", 2, "Anna.Mulder" },
                    { 89, "Roos", "$2a$11$5wJk1SPxEyTe1fQnISp0pO98qWMPujd3uOCj/VxHDOrPzjgvYTtz6", 2, "Sem_Haan43" },
                    { 90, "Anouk", "$2a$11$YQgF0MnTum3rkt6/lZchqu8Gi8sCkX3dzG4kQeUD2YS/kYwJqPmVq", 1, "Anouk.Wit" },
                    { 91, "Lisa", "$2a$11$ypTKsexHrQFp8bqoVDc7M.Jixy.gCFB380.HfhObkLwcqf/pziDSi", 3, "Lieke46" },
                    { 92, "Sven", "$2a$11$HU/nZUPWlDCcvvoXT0XIoutHy7EpMD7JYXkxEMR3HiNfRMZPXpL6.", 1, "Nick27" },
                    { 93, "Amber", "$2a$11$p9lTMVq/I4UlHeWJBDshpeVXNgyCmRAeX0fNfZsTrCZfV4Ymv/qEm", 4, "Jan66" },
                    { 94, "Sanne", "$2a$11$qsB47iONunDijpx477x9JeYaj3CLObEi0T0pFyxug.Yj9dzsDsrLq", 5, "Britt.Brouwer51" },
                    { 95, "Bram", "$2a$11$EYivFKLxL5rXrCHGF2TD3OjPu0MxLqUhrtZJU.q7beyl1Kz/lymMu", 3, "Iris33" },
                    { 96, "Bas", "$2a$11$mEkZVCMibyfOqsDyY718a.kL.nYx3GxcHV1zHE8p3/lm7mc/9rv9u", 5, "Sophie3" },
                    { 97, "Kevin", "$2a$11$Jcvbz6k7oI6wnMFSnJr6luAxdn/POngjdLjci9gojXcEGUsGIWqBm", 1, "Roos_Veen74" },
                    { 98, "Isa", "$2a$11$ZNAI1bpBGoQLum9TZ5fVNOdZqzILmrr0dzmr8pWdyuD994134/DT6", 2, "Thijs_Veen" },
                    { 99, "Femke", "$2a$11$Sv0QfShLqXqJGva8yKtrOuuYIWkNl/Rnkt03WsOzq9Ut4HdnY6Q2K", 3, "Sander90" },
                    { 100, "Stijn", "$2a$11$IK7fax1aH8StVtE1z12p2eil5x98LzUI/vrtteYoo3pOsYFvqAsoW", 1, "Tim47" },
                    { 101, "Niels", "$2a$11$Z.e/XdV4JhgdDbPJ9NsVk.6Spt2pAx9/dkHRh1Ct3mcQiaU7lC/Oe", 4, "Finn_Broek30" },
                    { 102, "Mike", "$2a$11$E8SjsjXfYLUl9Jnl.yEp4OkAfLzkmytc7/ymwy5AK/FkSC7d09cTq", 4, "Julia_Jansen72" },
                    { 103, "Bram", "$2a$11$gri/c7hPkMYWDr6dwTmezeEv5iQrCde/UoAIVMmz4QpNNwiW7BSY.", 4, "Sophie.Ven61" },
                    { 104, "Thomas", "$2a$11$D0tRI9doPj1H7iNlW8q/4uyGrgEacDs5rPsIs7XT03tZbvtE5cqpS", 3, "Sem_Maas57" },
                    { 105, "Stijn", "$2a$11$wrGflpmxqBxeH8J7XEIyN.MAt3mY166q9NyGvHjce6U4zNkREuLUq", 4, "Lucas93" },
                    { 106, "Stijn", "$2a$11$FGsjZtz.uI2lJbbJDtNEzewCSIidgtANknYaQwIDsVBj/NsZRrnWC", 3, "Kevin.Boer" },
                    { 107, "Britt", "$2a$11$ycyntZhQQg.St06ksHyyOugaVONQPB0VI1QZwXIp6HZGELP8kCeg.", 3, "Daan90" },
                    { 108, "Stijn", "$2a$11$LhnjrQ0VVqklhAGfH5sjFegMSf6R4w7iETbZ7sHUTXKAIhsEuGpE2", 3, "Britt.Klein54" },
                    { 109, "Lieke", "$2a$11$TXH70Jh4IUmMQnjfLqf5Suh0cTZZxy/wty7fcORWLYsCZVOtfp2BK", 5, "Fleur_Jansen" },
                    { 110, "Thijs", "$2a$11$zqvJT.gkUNOJWbBmq/Ow2up01hK/7D/pf7jZjc5ggCionhNovn..6", 3, "Jan91" },
                    { 111, "Thijs", "$2a$11$JtzzzszHzgdwnESTNgAWy.WXaiWEsWgf06Diw2veegw2kXGfu/zOK", 4, "Fleur.Smit89" },
                    { 112, "Niels", "$2a$11$DJ271.MY6AJEudlV0m4zBe.90fq8Xn4623tZHXU8IFn708Pyi0on.", 5, "Thomas.Leeuwen" },
                    { 113, "Jan", "$2a$11$Q8L4p9sI71q3.IdfPlybQ.Rs0TqMQUKHA4O44qeFCwx1paLB5R7hG", 1, "Tim86" },
                    { 114, "Ruben", "$2a$11$d6JgdjnRnis8DVwBCmjhm.YQVuG8P0huLd8VvxUxp8PDphRLqMpWm", 4, "Nick93" },
                    { 115, "Lars", "$2a$11$oPzYFZwHs2nw/Z4BIj6yIeNIwnCc0w3GH95QGwLdlo4vt5IvDYsby", 5, "Jesse.Peters43" },
                    { 116, "Bas", "$2a$11$DPmxxL6Ns7nOVhB7CLCwyeT/.Gr4735I4rM8HgX7cJXHkj3R99IE6", 3, "Sander.Jacobs" },
                    { 117, "Bas", "$2a$11$msUR01bGhLMpzOxZ6vKQauisFL6GPcjvSbmCd.g/PjfI7kFCjzjWK", 4, "Lucas17" },
                    { 118, "Stijn", "$2a$11$UszJnKtRhg7rJSPfYT2lGebKlrf5u7pPGTQd6WnXFrxtnOcrBH7im", 5, "Bram.Koning30" },
                    { 119, "Thomas", "$2a$11$/JGaF4Jviuj7M5bLdOtP9OQJqe.GUIzVQLTgCRkVvXlOTVe6EPG5S", 4, "Sven.Vliet" },
                    { 120, "Isa", "$2a$11$KiA4TiBZLVGvgN1qopkz8OVxlSZxLLRtm2sCEoYTC7o0OCN0MbOoa", 4, "Jasper8" },
                    { 121, "Daan", "$2a$11$sRWEDWseA5XvygMNHhnKHeYk/ovohxyFMT3Ha7Ny1.XKJrx7r5S5C", 5, "Sanne94" },
                    { 122, "Lieke", "$2a$11$5sAlhd1XivaiDXetm05TnujWVl0f2RlcMv24cF4aiu.Pm9VQ7bAE2", 2, "Thijs_Hendriks" },
                    { 123, "Lisa", "$2a$11$TkQ16mihAhKfSMdQ1CGsiemiLnAi1bonTCEkDaHiezwp6.ZcHOnBq", 1, "Stijn.Dijk" },
                    { 124, "Luuk", "$2a$11$t6P91jBfdR16bvJV8B28vOoY2PnmcKoa9RjeVhWF38nRvNNELQFjm", 4, "Stijn.Smit" },
                    { 125, "Femke", "$2a$11$tW3.7O7eqSAIMe6kKM7bFe.PuAWGTJ6VkBn59HNMXnoXIZ/WXLAWW", 2, "Mike.Ven" },
                    { 126, "Maud", "$2a$11$xkR0ZIKYYGddCFHXkjTmHO1L/S6OzhoDLT00OWN87hTfcqq97IdGC", 2, "Jasper_Peters" },
                    { 127, "Britt", "$2a$11$CcHvWtkxPinGzcAT53/lh.Cp/fwIpE/fIyWWu2xCiHcSsuk5cG22y", 2, "Bas6" },
                    { 128, "Bas", "$2a$11$1iVkQCYu1u5h.6NGIFoL8ODuLxaEaD9ZXNTblvkgDacfGunIfZ66G", 5, "Thomas_Brouwer78" },
                    { 129, "Johannes", "$2a$11$Z/dHi3L9vj7WGhWYOM7yIerRPgbxEdquRFY48HRWsIflIGjtmSScq", 1, "Emma_Vos53" },
                    { 130, "Finn", "$2a$11$xK3Hq0NyY./5/TLkN6FM3OjeHIXpoN3ASaWyARlQgkHAIeX9QYVye", 2, "Emma_Berg48" },
                    { 131, "Milan", "$2a$11$AC.30A3LBCLL659JX1XlG.4HFxNq0Pvz7Cj1hwZZDQiXKEgZv4GCm", 5, "Mike.Smits80" },
                    { 132, "Milan", "$2a$11$Eoy.bpp8bpKVFBB6Pe6gJua3WxNuo1YtQ4AhwibHy6ugRouqs5B8.", 5, "Thijs43" },
                    { 133, "Ruben", "$2a$11$qEuug0fVKzGoseCZJ2DQZu4D.glqwXnfEcAKxXVshFR5Rn4Z2f13e", 3, "Sander_Visser" },
                    { 134, "Bram", "$2a$11$/UFjMz6fPJibPWPavveBcOUDjTYH4iwTT3i9fxfWpeSVl95JY03n2", 4, "Sander.Maas" },
                    { 135, "Max", "$2a$11$1quL6QLwiyLzb5VY7dG.f.cvaiP8fxlpXWQrsuknTI0JN/sD3aRku", 2, "Stijn.Koster" },
                    { 136, "Emma", "$2a$11$6w6L0iDqU1n1jA7Jj28/Sur4JxNXtU6uhhKAhgzj5yl7UfhJ3nR9.", 5, "Tom_Vermeulen78" },
                    { 137, "Femke", "$2a$11$H65vFwo0Zw4i8at/iUJd4OCrW9NA26NdKso7zCdTTD9Fg9lBrWVkO", 3, "Nick_Brink" },
                    { 138, "Johannes", "$2a$11$Ghf7H/vHY/4zxNaLKkark.7mietDYdMxanPts/8yrIweqCZ7RUjFm", 1, "Femke51" },
                    { 139, "Anna", "$2a$11$9G9Aeofm5DX6LYuvLRIsZe0nYz9VP8SLF.qbLP10IJkBxsQAt3aMa", 4, "Stijn_Willems93" },
                    { 140, "Finn", "$2a$11$K6K3yPEtvO78xnKMiIMTL.DtRp1u.D3njWd/6n2CPbSyK4dU28JT6", 1, "Fleur6" },
                    { 141, "Thijs", "$2a$11$Jd1ZS2TNFOBcb4lQf8MOpO.86mRjf29MODH3Ter9OvLDvmwFyBadq", 5, "Fleur.Ven70" },
                    { 142, "Femke", "$2a$11$2xZKKjZDe5KPsbdWHLliU.TnZUOPF192u0.ZigGu4FfOXOmMxQP9a", 3, "Jan_Willems" },
                    { 143, "Femke", "$2a$11$lyO/In0mbnREOvLoYA.1pO54cAX22cGiWAAPlDJdgvt4W294LSfjK", 2, "Sem.Vermeulen27" },
                    { 144, "Jesse", "$2a$11$N1Y9WSN050TH7ranHoEbqODT8H3Gspxbk0YT/mYRETX9lcc/LtwfS", 2, "Daan95" },
                    { 145, "Lotte", "$2a$11$bdwQThBGSvSDMU1ItylW4e.xN96BxCTpwRhQRyNQsOneEvYmRfIzG", 1, "Emma54" },
                    { 146, "Julian", "$2a$11$keE3M75Oj1wg7tl.n1lik.o.604DI5yCvkPnliIat29SqqtxjVG8C", 3, "Daan_Heuvel" },
                    { 147, "Max", "$2a$11$UpT2lNbIrVcrOSsHMB0EKOhhwJpJZKkWMsBegoMsY2ozzBzWdG2Oa", 2, "Tim.Visser22" },
                    { 148, "Thijs", "$2a$11$ExIoo/b66TFROEi5WS1sfOT8SSeO9jMOxTUqOu2Tpy9PsIkvwDt2e", 3, "Lisa.Janssen" },
                    { 149, "Sophie", "$2a$11$6r8InkJz0aaFqMQPAKL1ou1GZLJysiSPRR4lDyHWaoD9xwMJvJAP.", 2, "Isa_Broek79" },
                    { 150, "Eva", "$2a$11$R984uJu49RZF/RjbU6aZP.wuL2pSZIQrNFIcYaf3PqYJfAxrXOpIS", 2, "Sander.Dekker50" },
                    { 151, "Maud", "$2a$11$svkyi5fzm6hIjC7YYcMJlO/5R6u4REJaOI4OMxoeiUYmeY3mDox56", 2, "Iris14" },
                    { 152, "Roos", "$2a$11$ReRFAnUB0FYxmxCUXmw19.Xl0xhYSnSWwYzrQUr04bas9HFbR4jMm", 3, "Eva.Haan5" },
                    { 153, "Anne", "$2a$11$aqQJZhGgbZRSsm7/KRW.tuREUAgZ6F70Z.VsqapBhGfriezHVK58e", 5, "Anouk76" },
                    { 154, "Mike", "$2a$11$EyWwZAkj/D5x97hsmpiiTu3cch9sztdggu7OBSS.WQUYRiJg1sfFW", 3, "Lars85" },
                    { 155, "Nick", "$2a$11$y7XafnaOKyKIGfkw/BwrlOu9tL187Aa/Msh0jY3f1cirvLSJHJUb6", 1, "Sanne.Jacobs60" },
                    { 156, "Julia", "$2a$11$mdOsgfAxVUWnnrJQBth9GOdmwJ4Hk8MJM07K3/CiQiAS7OgE0uS12", 1, "Rick.Koning26" },
                    { 157, "Tom", "$2a$11$uRu4EAfssCODe3zNKtX3xuQMozgVPXeB3XSYSM2VykWP5v/3RSYPy", 4, "Roos.Linden" },
                    { 158, "Amber", "$2a$11$75nx3UQZ0g6aZCaW0PgUQerp52U6iUE00mtCMD2DVE3Ju.V0uA6iO", 5, "Nick.Vries36" },
                    { 159, "Jesse", "$2a$11$h4MoHFXqXJ2HeoErzXZV/eLsMtaNHfBHrsMHz/XvHCp6ZUSc3STv2", 3, "Thomas.Graaf43" },
                    { 160, "Jasper", "$2a$11$tQILGUQU0ndXlJM7FO2l8OkK9Ar/jFAVU13rfO3bIvnRtCKAeULtS", 3, "Mike_Vermeulen23" },
                    { 161, "Bas", "$2a$11$0QGSKzMraiDxRn/SJp6UE.4uFLikJmmLsA/2ujXqNxuCSB1XLJHua", 4, "Mike84" },
                    { 162, "Anna", "$2a$11$nDX6cMY3tupsmLl7UO7B8uNsRUs8ZdlNcJDUnaqVkUNGXVaPEtZpa", 1, "Sanne_Boer" },
                    { 163, "Amber", "$2a$11$WrPLOWs4CbknKRTs5iGX5uoIZUufp9q7rekt1lm2sYZ53UiaMQI5O", 5, "Mike76" },
                    { 164, "Tim", "$2a$11$8p9ZFHM/Sy/rlJDcuRBCJOTy6zwWXWH9vy9wpgR1v5Y4jIfnk6ZXO", 5, "Emma.Bakker" },
                    { 165, "Niels", "$2a$11$xE1ZEsHbfRX130ku/Txxs.NyQ.JGashRilDKRit3ZaAl42l9iXDIW", 4, "Sophie88" },
                    { 166, "Sander", "$2a$11$WN4Y5kNPAT3393q87c8aNOU3I1t5fRtD2CuosfoShsk5YPOtifBXe", 5, "Luuk_Heuvel52" },
                    { 167, "Anne", "$2a$11$K4cP44jPa1go7u9yT8olT.EGp0ZqmU8ZskDFBJP8pYQElj3.nFsd.", 5, "Lisa58" },
                    { 168, "Johannes", "$2a$11$t58rSjN1lpMVHSNF./hxMu/kmr.YFUfYSNO0PQnUtwb19kvp/u53y", 3, "Thijs0" },
                    { 169, "Finn", "$2a$11$Wvs9LWZSd5RZkM/xPVDb.eg53cwd6MiHPuHBsOJjFHvZx/KU4.q/S", 4, "Britt.Vliet" },
                    { 170, "Niels", "$2a$11$QXNnBUtGE8bWddROg33U6uixG4aEySUQK8h0v/g5yBhwxmaXVqp86", 3, "Bas9" },
                    { 171, "Kevin", "$2a$11$Nx/l9gnLoucvbZvJD76Urex8.cdKvLUZwwobgzcwu3p1cW9OsbaCu", 2, "Kevin60" },
                    { 172, "Finn", "$2a$11$utHWkP3nrlWPpETmcmazYuCOZAXiYXOW7fdnNuktBYi/RHNUcQIpm", 2, "Johannes_Bruin" },
                    { 173, "Isa", "$2a$11$kHn1.CtQaxDZbsnA0sfs/eWiGoHKEMGXCR3FcOZ7EuF/4L9R/Lp4K", 3, "Sophie3" },
                    { 174, "Fleur", "$2a$11$.rKj8o5asEyGGXH/nU.BwueDDAavbnOS0o/AsG8jykcvpZz99HPBK", 2, "Mike85" },
                    { 175, "Stijn", "$2a$11$VkAGcFWKJCNTMilQjPC.aex2yv2komvqypBQHbezCbFhIhKiK/ubC", 3, "Nick_Dijkstra18" },
                    { 176, "Lisa", "$2a$11$2eH0BcPHKa2jVTnns6WC8edVd7ygfNoBcZvZboJsnpni4Y5ZotWM.", 2, "Bas16" },
                    { 177, "Sophie", "$2a$11$gzyWUx1o0MHZKdN2xgsCuOzdByDQAGBpkbedw/TW9ikRoBMpVv1c2", 1, "Jasper.Hendriks55" },
                    { 178, "Anne", "$2a$11$aIcXfKFzoX5hTERzVCG/OeelHPfcYG4asS9DzXkOmIY6JuNV.DI6e", 1, "Julia_Smit61" },
                    { 179, "Johannes", "$2a$11$Dp1mNwkEfmKD7T8K.14GJup5eu3HdZlshN41oEWu0l02vj34QX1iW", 5, "Iris.Schouten28" },
                    { 180, "Emma", "$2a$11$3zINjd.KVexGb3ejAV/YneLtU/qOChqO6zi1Nqtc52.38ugHLS7vK", 3, "Lotte22" },
                    { 181, "Sanne", "$2a$11$MGViKybgpTu4qfbLYf3zpu5xFNMM6eYjAmDMH3aTbumiTeTTy1BaK", 3, "Fleur16" },
                    { 182, "Bas", "$2a$11$pCBb3jp7/taXU9iQU/Dg6uR7gcPEv8wirBPCX4sjtPNzRkygCwZwq", 3, "Julia.Jacobs38" },
                    { 183, "Britt", "$2a$11$smLDY1gkXon0a5m5v62YU.iFTy5Ow6hTbyuIVSkd0ha.BA9KOBPQK", 5, "Maud_Vries" },
                    { 184, "Sem", "$2a$11$4Q0vjJ2iTl.Hov.ncljrqeI3zZe5hx9ZSzLx8/2Zsz4QTds8Uuclu", 1, "Sem.Vermeulen" },
                    { 185, "Amber", "$2a$11$n9kpIjPnsYXZz9snUv84P.KR6FOefYA2wI3TRzW.80IOOVGuyRf0G", 1, "Lars.Mulder23" },
                    { 186, "Thijs", "$2a$11$0PdQSzC6Sb4GV2Ac.Y6XIeQgHt2oLDHtpsWeja/Fm9/L33Hp/A3FC", 5, "Finn_Bos66" },
                    { 187, "Niels", "$2a$11$airrBDGdGGw2jEYb6TGbCuHf7lACeSmuZJGPDlJQgE6iILQzK8OYi", 5, "Milan_Willems44" },
                    { 188, "Amber", "$2a$11$DaEqGN3bjZVSeK9gG10M7eNR9XAEhZ6YaRVPWFCI9hgCaSAb.zGl.", 4, "Rick.Groot" },
                    { 189, "Bas", "$2a$11$9Np8W30PMqgCJETK/v1qe.i1tAFWJ/3NrDcDKP42mx80WiS5LF2Gq", 5, "Lotte_Meer45" },
                    { 190, "Lisa", "$2a$11$SxNBKA3H2oU45BZC6wFTRel91MJXiWu27...rRTWDIwJ6TSHNcqQW", 3, "Jasper_Linden" },
                    { 191, "Anna", "$2a$11$fswuTD.uw4rX9oKrrRXTleRx5wRURaac603IkPtDQLf6Y0QLW3Kou", 1, "Lieke_Stichting43" },
                    { 192, "Lars", "$2a$11$/6zsvu6OSqdn5y6E/2izI.LoumqYkoOhNTJxy4gR11vCjx98ALf3.", 5, "Julia.Bos14" },
                    { 193, "Daan", "$2a$11$39XWzRGNvi3TWBJ51LtWSuPWbIGjuY70P6wFsUaQbK4s94jmC.t7W", 3, "Bram40" },
                    { 194, "Sophie", "$2a$11$QhQdeQc5qCPp1Pq1lCONFOklucbYZGwwZagHjZtu9kK53FM7/XFyu", 5, "Anouk.Smits" },
                    { 195, "Amber", "$2a$11$QhDLL0UxvDjXYOy.E9qkS.fJXHG8vlht0vx6YxXw2bl2PSlpZ3yNK", 1, "Niels30" },
                    { 196, "Amber", "$2a$11$r.gURRiZRlk.hsve0BiL5O/GTwwtvgUr96OQmJNJJ4Q9bO8yn1AIW", 4, "Bas.Vos36" },
                    { 197, "Roos", "$2a$11$rjvZS0PmBd3VpXI9rJjoEudIcrxEiZ.eUQYQt1j0pVGgsWh1CC/36", 2, "Rick_Mulder" },
                    { 198, "Fleur", "$2a$11$FbeEw2t.TlVSWzUy9J1RveAZ2CwHfzm4vI4x8cvHbBBB37Dmpd9aO", 1, "Milan_Hoek96" },
                    { 199, "Roos", "$2a$11$Sc9Gpc/KRh72K9OjDV1WjOCPs3Wu0ZecYWAYBhF9DiXFAwqCocVKm", 4, "Tim_Jacobs22" },
                    { 200, "Johannes", "$2a$11$Yzy4X3Obwrk34uDpIsAfku1Ja1vNfbr6F0e5zr43SX2qX9qix4eA6", 2, "Roos.Wit64" },
                    { 201, "Johannes", "$2a$11$1KCXkH4i2C6h1phaURXTWusrGKksTGJTJpEDOOZt/iySvVgpvohUC", 1, "Eva_Wit" },
                    { 202, "Thijs", "$2a$11$tyA0abPnxBDbF4d3ZYJY9uWm6NJjwvKwA8uhlt5OFsog7R/gMOUPW", 4, "Bas13" },
                    { 203, "Tim", "$2a$11$PGDvv4dtjcRgLLoYUj7NEe0wv7YraP4lvCE84bHlL/UidmD0lqYgy", 3, "Sven.Dijkstra27" },
                    { 204, "Iris", "$2a$11$1dDKwFlMPPwaKB5gq2meWerXwTiaUOGeo9c1LxEw6zEFHNr2iQvDa", 2, "Thomas_Klein68" },
                    { 205, "Roos", "$2a$11$WZP9xYdtgViR3.7YfQ98s.LMqELA0jRMiR4xpkNVGUgz7zERE4ZHm", 3, "Lars67" },
                    { 206, "Noa", "$2a$11$zuoM9jH5rJm5ntDa3FM.Fu9jNz850ocVEScysdLOByuKCnQW1gWRW", 1, "Daan_Bakker76" },
                    { 207, "Lars", "$2a$11$58ErXFcm8lqyRh//D72CceFPfhN0JRRqU.eeXLfLMk85pslHv6YUi", 1, "Femke_Kok67" },
                    { 208, "Stijn", "$2a$11$vP2mXxocHPQ47TMtAMy0A.H.pgBZDVh9pOfNl.tvgo3ltYWfHFzi6", 5, "Emma_Bosch2" },
                    { 209, "Anna", "$2a$11$Fo.Y4oHpM1Szc.6c5HZbcuGJrJ4jTfKPB.fl0RAv2AJJidaro2Fqa", 2, "Anne84" },
                    { 210, "Sanne", "$2a$11$U3OOzjmPYSS9IsR2.fZZOO5ycHThESuKS5YIu3w8f3Peu9Kf84EIq", 3, "Emma_Jacobs78" },
                    { 211, "Sem", "$2a$11$4Q87DTMCRzeCT4cDw.csEOT1jd71YRRQyPSW.HqDnW755a/s2fsVG", 3, "Amber61" },
                    { 212, "Lisa", "$2a$11$KrG7yhHNqHp32lYuSnwNE.rjaTjVZg8LBwqTLAF.p52WSyjpu8MfO", 5, "Anne_Bruin90" },
                    { 213, "Lucas", "$2a$11$ARdqrpbUd1BGHTXniDBQgusOHvNj5VHd8A1KFQvHjf3nIG0HZUl.W", 3, "Jasper.Jacobs" },
                    { 214, "Sven", "$2a$11$jQjngRIHGkiTwQSj5rms3uYbbpU5K8cq/mkC1ZHbvHSW06WyfsBW.", 1, "Lisa_Ruiter" },
                    { 215, "Ruben", "$2a$11$YgzzMxXOz/P47tk5/4Fl0OdpH9p1vjm.rmVbYPRrNhugkx/0jqwdW", 1, "Ruben_Meijer20" },
                    { 216, "Nick", "$2a$11$Jk0Hlm2AT/ChVzTK/pCvW.F97yQLtmjamiDAmOnGW3/xeIT98hxPW", 5, "Sven.Veen49" },
                    { 217, "Lieke", "$2a$11$Y2YNYNLP6soQtoGZPIaU7OVZUZn3NQt4HukPY1UTnL7R1xBX/txK6", 5, "Anne68" },
                    { 218, "Lieke", "$2a$11$ozQ5QvdCaBXxj/xKPWrSkuW7wJ92pM/.T8rHLdafEnrH2j75Dnir2", 2, "Tom.Bos59" },
                    { 219, "Milan", "$2a$11$XCqTbPrLW8HADDBBdMLIh.VguQslBT.p5eCqSaTfy08YBQaVR11y2", 1, "Julia49" },
                    { 220, "Anne", "$2a$11$Sy2nFcJXC6HvPOlMMiKGxudJ7rXpfOAKysgkHkxX1C121.rG0C.tO", 3, "Sophie.Linden7" },
                    { 221, "Anouk", "$2a$11$LhKP2gRx09LouRBZIFVvcu68qbBKOg8jBEJDHamGNjPbj4L48ttHW", 2, "Amber_Broek72" },
                    { 222, "Niels", "$2a$11$nEbGmeaeDJmta.Gm.plaY.EIISFQzqJbKJlvko01sJLClBuKv3jXe", 3, "Luuk.Meijer57" },
                    { 223, "Julia", "$2a$11$/yLVIgtk/Oo.9KZBOTyKf.cq7gaxTZhoD75fNmFW4Ryja/RFo53u2", 4, "Lisa_Koning" },
                    { 224, "Finn", "$2a$11$pXA8ByXPQD31gJrIWXvGROG0qqd3TRcW24dAQ2w/55UkrucsmFEY.", 4, "Emma.Broek3" },
                    { 225, "Johannes", "$2a$11$C9BBwIVQFOc4nUKw0UX.8ep4I3hUGGsqO91QRG3bDCHRBDTMwJAHG", 5, "Luuk.Meer" },
                    { 226, "Anne", "$2a$11$lvFV7P00pw.gOZaPCRm9sOw2heE.Uej0uOdfxt6HZj6.NwGjtNGMm", 2, "Thomas_Vries50" },
                    { 227, "Jan", "$2a$11$FU20ciBExI5p5EpxKO8OxuGn47epR21sHpFvO7hGzQgti81Gsz3oe", 5, "Lotte_Hoek99" },
                    { 228, "Kevin", "$2a$11$ZY1.pVvCLCxOdOn7dRJe8OMmqxf6o.Uismxez2YuAPTsPyFiUvFQG", 1, "Jasper_Ruiter29" },
                    { 229, "Jasper", "$2a$11$ka4Fv0mAGBpTFX7bly1fduMv1WDt0xLbBUofwld7JteVXbLHl4Hxi", 2, "Sanne_Linden" },
                    { 230, "Julia", "$2a$11$ihBaFw0IKsayVVbWxvjq5OY9SZJ2ZMQOFgKZ8EJgND3EzGx9Y8ahq", 5, "Stijn_Smit" },
                    { 231, "Isa", "$2a$11$3sYWrzd10JLgbQBE90GY6uoo66vTBtmYbZ1yPhDguoZiA2m6odw9m", 3, "Thomas35" },
                    { 232, "Milan", "$2a$11$bsXiKq/M0p0imOTgsTRIEOvnoKgPCKAUireVuc2t9D.LbifytLF9O", 4, "Sem.Heuvel" },
                    { 233, "Emma", "$2a$11$QvMmQ4lFtBiSG236S9CRPOq3pzZq47XhvoDOu2YqnIdv8zR1BnG3m", 3, "Luuk.Dijkstra" },
                    { 234, "Tim", "$2a$11$klWOmmYD7a0EKFZ4mviUVuuqbsWQWnQJQSa1vtjnAsfDo8DZN9X52", 3, "Tim_Stichting" },
                    { 235, "Kevin", "$2a$11$pHllh3x70OlfZB4LlCVx8Oc7Uib7G3YJmO/0yUsq3D0GX.ZCV.8RK", 4, "Kevin_Vliet61" },
                    { 236, "Kevin", "$2a$11$8XQIY70.vVgoGc2IJcM4jO3j5clGdmTTy/nnVoBUTAz40NMrzqET.", 5, "Anna11" },
                    { 237, "Jayden", "$2a$11$DCdME5.yEB8N0OhJ6dFh.egrJpFHS.PISMumb2tgevR5ou2Z9DpHu", 1, "Anna25" },
                    { 238, "Tom", "$2a$11$x/DN3UgdJMFXP/Yh1ounTe.Gc6LhtPB7CA1LHhyqNOZg5CNlK3ICC", 5, "Britt15" },
                    { 239, "Jesse", "$2a$11$3GFDYuXI.VRilBCLS23G6.gdcnkMVuZjegbpRcx.cSVJ4hZSVxMaG", 4, "Isa36" },
                    { 240, "Britt", "$2a$11$tK8u5CUkbFuEJACZsukEMenWdBJaSBqbePaZpnyMfimLJLa4Gr2zO", 2, "Niels_Ven" },
                    { 241, "Thijs", "$2a$11$OFD4OPsbV7c84NBJmikHyuqmbYoambZ0UCXharJNDrHVXcJwYYc4i", 2, "Lucas.Jong24" },
                    { 242, "Sander", "$2a$11$GV61lM1XIMUFFEarbEXTSOY9gFMh9UmMfVp46ox61/MzoBGIwnfvm", 1, "Ruben_Wal35" },
                    { 243, "Stijn", "$2a$11$.R1ALMqZbDpTfiIeovy6nui6IFgl6FEc8bY8tURiJB3mPQmu1WvtC", 4, "Lucas_Leeuwen8" },
                    { 244, "Anna", "$2a$11$TQYN.A4Yr4iXZ4lNuuOkIuOnziGhwoFguZ0J4.wWIapYI.b3sg2yK", 4, "Bas85" },
                    { 245, "Britt", "$2a$11$XdRrzK7gEyMIkWV6THZmf.hNXGnkYTnaWTIOxhd3ZquPQfjP3XfZm", 4, "Nick_Vliet" },
                    { 246, "Fleur", "$2a$11$qYeFCkHjvYngDBZkQwdjkeEqvueYUSlkS/La3DpTwi9ZR0JZHzhg6", 3, "Julia_Wit23" },
                    { 247, "Bas", "$2a$11$HElRTnXYmiTBD6G1Juk/5uzB/g.dOlgiAJxgFX7K0yyLN8dVPigua", 5, "Maud_Groot" },
                    { 248, "Jan", "$2a$11$lbbJh1dWZXxOd5DSrHpnSeHCo4WQKuBiZLfynvmqEYuDyM16J.pHq", 1, "Anna.Brouwer38" },
                    { 249, "Thijs", "$2a$11$XL9n1iqYoWh3sbI6xF0cOO3B3WOdVIw.a0zMh0hOCaVWt5rQL/j8S", 3, "Lieke_Haan37" },
                    { 250, "Thomas", "$2a$11$8htr7KgJLwQbVfa.CH8V0e5Igg2NxSmLUXVq4BQ8mOJ6rOpkVWlzK", 1, "Max_Peters26" },
                    { 251, "adminf", "$2a$11$xxhKxz8aasXE89porExopeQfh86I2DzAVUki6NaJ.z0MQp6vbBbiK", 1, "adminf" },
                    { 252, "admins", "$2a$11$GVxK0z.HSjyfCyjueaYz.uW85srgIKfaqurbTiJ3GIRYUStaLGwaW", 2, "admins" },
                    { 253, "admini", "$2a$11$BZ02HR8eMOOZTxB6v85GGu5uU6bZmlsSN8ZLcToiIDBhY9zb7ZaIG", 3, "admini" },
                    { 254, "adminm", "$2a$11$oTAciLtAHPcA.nHjF48K3eNd7aocg1eMM6nKqIQ7N6/lpsZdaswn6", 4, "adminm" },
                    { 255, "adminc", "$2a$11$Kb0ypdUyJlYbB4HsBlc.4eF49Yj7L/aQnX6ZDnnGoKMXjHsK/u2wi", 5, "adminc" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BkrCheckedAt", "City", "CountryCode", "HouseNumber", "Name", "Phone", "Street", "UserId" },
                values: new object[,]
                {
                    { 1, null, "Gijsselte", "PCN", "465 I", "Hoek International", "(3384) 380879", "Kevinplein", 230 },
                    { 2, null, "Bethlehemkerk", "MTQ", "334a", "Janssen - Vries", "(7647) 017242", "Hendriksgracht", 255 },
                    { 3, null, "IJzen", "VIR", "022", "Maas, Vermeulen and Peters", "(7494) 887018", "Tomplein", 121 },
                    { 4, new DateTime(2024, 1, 19, 15, 49, 16, 432, DateTimeKind.Local).AddTicks(9664), "Eenrumweer", "LIE", "1", "Dijk ICT", "(5139) 880197", "Jaydenrijk", 2 },
                    { 5, null, "Oudleusen aan de Rijn", "BVT", "026 III", "Bruin, Dijkstra and Willems", "(3378) 459985", "Boschlaan", 136 },
                    { 6, new DateTime(2024, 4, 23, 0, 3, 44, 809, DateTimeKind.Local).AddTicks(1368), "Warffum aan de Rijn", "SWZ", "158 II", "Ven - Meer", "(5960) 553624", "Kosterstraat", 42 },
                    { 7, new DateTime(2024, 2, 15, 18, 29, 0, 702, DateTimeKind.Local).AddTicks(48), "Leimuiden", "GNB", "47", "Hendriks, Dam and Peters", "(7351) 182055", "Basplein", 216 },
                    { 8, null, "Theetuin", "SSD", "865 I", "Peters B.V.", "(8819) 992624", "Evasloot", 187 },
                    { 9, null, "Knegsel", "BRN", "1", "Bosch - Heuvel", "(1668) 731327", "Rickplein", 132 },
                    { 10, new DateTime(2024, 5, 14, 7, 7, 2, 346, DateTimeKind.Local).AddTicks(1815), "Crau", "BGD", "024b", "Janssen Bank", "(5646) 648145", "Bosmarkt", 236 },
                    { 11, new DateTime(2023, 12, 5, 4, 14, 32, 784, DateTimeKind.Local).AddTicks(6696), "Biessum", "DNK", "656 III", "Mulder IT", "(4653) 290725", "Daanpark", 80 },
                    { 12, null, "Haller", "MLI", "858 I", "Graaf, Klein and Jacobs", "(4205) 962256", "Dijksloot", 136 },
                    { 13, new DateTime(2024, 3, 15, 16, 14, 43, 295, DateTimeKind.Local).AddTicks(1486), "Dedgum", "QAT", "2", "Bruin - Haan", "(2094) 716146", "Semsteeg", 187 },
                    { 14, new DateTime(2024, 8, 26, 3, 15, 16, 228, DateTimeKind.Local).AddTicks(5821), "Sytdorp", "CMR", "736 II", "Peters - Broek", "(5496) 561283", "Brinkplein", 132 },
                    { 15, new DateTime(2023, 12, 7, 9, 2, 28, 677, DateTimeKind.Local).AddTicks(926), "Galder", "SEN", "509 I", "Vermeulen ICT", "(7562) 976634", "Vlietplein", 192 },
                    { 16, new DateTime(2024, 6, 10, 3, 52, 20, 12, DateTimeKind.Local).AddTicks(1278), "Wissenveen", "FSM", "390 III", "Boer BV", "(3709) 360741", "Beeklaan", 38 },
                    { 17, null, "Engelbert", "ISR", "743b", "Maas, Meijer and Boer", "(6116) 624847", "Daanvelt", 54 },
                    { 18, null, "Offinga", "BIH", "378 III", "Bos, Schouten and Vermeulen", "(7073) 766110", "Haanweg", 65 },
                    { 19, new DateTime(2024, 3, 19, 6, 31, 58, 613, DateTimeKind.Local).AddTicks(2259), "Anjumberg", "ISL", "949 II", "Koster IT", "(1413) 588843", "Broekdijk", 163 },
                    { 20, new DateTime(2024, 9, 14, 2, 9, 7, 989, DateTimeKind.Local).AddTicks(3822), "Follega", "ETH", "1", "Smits - Kok", "(0545) 087347", "Lisapark", 212 },
                    { 21, null, "Rottumenmaes", "TON", "5", "Meijer, Meijer and Brouwer", "(2320) 547581", "Ruitervelt", 121 },
                    { 22, null, "Sellambacht", "ROU", "250 I", "Brink N.V.", "(0653) 620500", "Veenweg", 6 },
                    { 23, new DateTime(2024, 5, 14, 4, 4, 17, 573, DateTimeKind.Local).AddTicks(5863), "Knolbeek", "KAZ", "260c", "Koning, Peters and Visser", "(4434) 198491", "Bruinpark", 217 },
                    { 24, new DateTime(2023, 12, 4, 10, 12, 1, 481, DateTimeKind.Local).AddTicks(7155), "Vaesradeland", "FRA", "559 III", "Smits - Veen", "(8658) 855901", "Mulderplantsoen", 186 },
                    { 25, new DateTime(2024, 3, 11, 17, 52, 35, 432, DateTimeKind.Local).AddTicks(3626), "Magelevliet", "ETH", "722c", "Broek IT", "(1438) 115807", "Basgracht", 128 },
                    { 26, null, "Grathemdijk", "SVK", "631 I", "Hoek - Bakker", "(6993) 089332", "Broekplein", 255 },
                    { 27, null, "Kaumes", "BDI", "932a", "Veen, Vos and Dijkstra", "(6857) 006689", "Nickpassage", 227 },
                    { 28, null, "Haneschoten", "ISL", "128a", "Visser NV", "(8714) 838553", "Lindenvelt", 167 },
                    { 29, new DateTime(2024, 11, 14, 22, 29, 22, 142, DateTimeKind.Local).AddTicks(8435), "Reethvliet", "FRO", "6", "Meer - Smits", "(6221) 995376", "Lucaslaan", 6 },
                    { 30, new DateTime(2024, 9, 19, 6, 23, 12, 719, DateTimeKind.Local).AddTicks(4133), "Baan", "KWT", "915 I", "Meer - Stichting", "(3628) 815688", "Meijersteeg", 187 },
                    { 31, null, "Heinebuurt", "SJM", "183c", "Ruiter - Leeuwen", "(3103) 705606", "Svensteeg", 71 },
                    { 32, new DateTime(2024, 8, 24, 10, 26, 2, 767, DateTimeKind.Local).AddTicks(723), "Lithhorst", "NRU", "936 II", "Dijkstra, Jong and Peters", "(0306) 249076", "Irisstraat", 247 },
                    { 33, new DateTime(2024, 5, 8, 16, 15, 15, 424, DateTimeKind.Local).AddTicks(1277), "Easterein", "ESP", "520a", "Bruin Bank", "(3546) 474678", "Basrijk", 60 },
                    { 34, new DateTime(2024, 7, 12, 2, 47, 30, 448, DateTimeKind.Local).AddTicks(7672), "Punt", "BLM", "257 II", "Dekker Groep", "(7369) 723630", "Jacobspassage", 112 },
                    { 35, null, "Molenbaan", "ARG", "385c", "Veen - Smits", "(1017) 758838", "Jaydenkade", 208 },
                    { 36, new DateTime(2024, 9, 29, 0, 52, 31, 426, DateTimeKind.Local).AddTicks(5629), "Wolfhaag", "NCL", "881 I", "Bruin NV", "(3629) 091846", "Stichtingsteeg", 164 },
                    { 37, null, "Kipper", "TKM", "551", "Wal, Hoek and Haan", "(4771) 857971", "Damstraat", 208 },
                    { 38, new DateTime(2024, 5, 31, 5, 38, 38, 626, DateTimeKind.Local).AddTicks(9277), "Hodenpijl", "SEN", "63", "Groot, Peters and Groot", "(6093) 270036", "Grootdijk", 128 },
                    { 39, null, "Meeneberg", "ABW", "218 I", "Willems Bank", "(5729) 466269", "Finnplein", 216 },
                    { 40, new DateTime(2024, 5, 10, 11, 12, 33, 316, DateTimeKind.Local).AddTicks(5480), "Kibbel", "COG", "58", "Linden - Visser", "(0571) 585805", "Brinksteeg", 166 },
                    { 41, null, "Rhenoy", "ARM", "512 II", "Peters - Linden", "(9438) 879645", "Kevinpark", 18 },
                    { 42, null, "Katlijk", "CAF", "2", "Meijer ICT", "(5948) 650718", "Sandermarkt", 238 },
                    { 43, new DateTime(2024, 6, 30, 8, 11, 25, 882, DateTimeKind.Local).AddTicks(5472), "Verloren", "DZA", "374", "Dijkstra - Schouten", "(6472) 732290", "Lisapassage", 247 },
                    { 44, null, "Bergakkerwoud", "JOR", "785 II", "Willems, Smits and Heuvel", "(0981) 107979", "Bosweg", 18 },
                    { 45, new DateTime(2024, 5, 5, 17, 54, 58, 962, DateTimeKind.Local).AddTicks(1690), "Valk", "CHE", "150", "Visser HRM", "(7672) 899744", "Lucasmarkt", 11 },
                    { 46, null, "Vleetbrug", "LSO", "480 III", "Jacobs, Bakker and Groot", "(9703) 347167", "Maudplein", 230 },
                    { 47, null, "Bern", "GNB", "643b", "Vliet, Bruin and Bos", "(9108) 367672", "Bashof", 230 },
                    { 48, new DateTime(2024, 1, 8, 21, 50, 55, 547, DateTimeKind.Local).AddTicks(5316), "Rott", "COK", "538", "Linden, Linden and Kok", "(7796) 743100", "Maxlaan", 42 },
                    { 49, new DateTime(2024, 3, 10, 4, 51, 17, 922, DateTimeKind.Local).AddTicks(3254), "Zieuwent", "MYS", "841", "Veen, Meer and Dijk", "(9067) 337294", "Dijkstraweg", 6 },
                    { 50, new DateTime(2024, 2, 16, 7, 38, 57, 516, DateTimeKind.Local).AddTicks(403), "Olterterp", "DEU", "787 I", "Maas, Kok and Meijer", "(0726) 474197", "Liekeplantsoen", 7 },
                    { 51, null, "Beusichemhorst", "TCD", "930 III", "Bos - Peters", "(3565) 116265", "Fleurlaan", 227 },
                    { 52, null, "Oosterse", "EST", "010a", "Ven ICT", "(9140) 583767", "Sannepark", 128 },
                    { 53, new DateTime(2024, 11, 10, 7, 25, 44, 100, DateTimeKind.Local).AddTicks(4524), "Strepengat", "NCL", "160a", "Heuvel - Meer", "(6690) 971433", "Lottesloot", 112 },
                    { 54, null, "Startenbeek", "DEU", "958 III", "Ven NV", "(3728) 573047", "Walpassage", 60 },
                    { 55, null, "Welyeind", "BEL", "419c", "Beek - Dijk", "(3866) 387177", "Maxpark", 60 },
                    { 56, new DateTime(2024, 5, 25, 5, 33, 25, 573, DateTimeKind.Local).AddTicks(5371), "Schrap", "BOL", "656", "Linden - Heuvel", "(5176) 496344", "Boschgracht", 167 },
                    { 57, null, "Nieuwaal", "MAC", "6", "Koster, Meer and Bosch", "(3192) 521731", "Kostergracht", 42 },
                    { 58, new DateTime(2024, 11, 2, 23, 31, 17, 122, DateTimeKind.Local).AddTicks(1992), "Loete", "MAR", "208a", "Maas HRM", "(7604) 488663", "Janssensloot", 7 },
                    { 59, new DateTime(2024, 7, 29, 2, 4, 20, 244, DateTimeKind.Local).AddTicks(2644), "Hilte", "PNG", "237c", "Brink BV", "(8126) 114136", "Beekkade", 225 },
                    { 60, null, "Kamperzee", "LBY", "094 II", "Willems, Linden and Brink", "(6883) 976889", "Kokrijk", 186 },
                    { 61, null, "Hultje", "SOM", "809 II", "Vermeulen, Jong and Heuvel", "(2247) 427142", "Kevinsloot", 65 },
                    { 62, new DateTime(2024, 11, 22, 11, 24, 0, 963, DateTimeKind.Local).AddTicks(6939), "Tragelhout", "DZA", "706 III", "Ven - Smit", "(4174) 665487", "Johanneskade", 2 },
                    { 63, new DateTime(2024, 9, 22, 4, 3, 16, 933, DateTimeKind.Local).AddTicks(7842), "Leuvenumambacht", "CUB", "448b", "Veen, Meer and Bruin", "(4338) 534746", "Kevinweg", 38 },
                    { 64, new DateTime(2024, 11, 29, 11, 41, 26, 884, DateTimeKind.Local).AddTicks(5774), "Luisselburen", "VNM", "952 II", "Meijer - Vries", "(7353) 649376", "Meijerstraat", 136 },
                    { 65, new DateTime(2024, 10, 6, 10, 4, 16, 199, DateTimeKind.Local).AddTicks(9161), "Schijf", "CIV", "304", "Wit HRM", "(1785) 636060", "Nickgracht", 85 },
                    { 66, null, "Jammer", "SYR", "997c", "Bakker, Dijk and Heuvel", "(7365) 663455", "Brammarkt", 167 },
                    { 67, null, "Höchtevliet", "ESP", "8", "Ruiter NV", "(1903) 557793", "Meijerlaan", 80 },
                    { 68, new DateTime(2024, 7, 8, 12, 1, 6, 681, DateTimeKind.Local).AddTicks(2940), "Aarlesluis", "SDN", "859b", "Meer, Veen and Beek", "(7274) 077124", "Lucaslaan", 54 },
                    { 69, null, "Rood", "LBN", "663a", "Vermeulen - Vliet", "(8240) 652991", "Brinkmarkt", 216 },
                    { 70, new DateTime(2024, 11, 19, 4, 12, 53, 154, DateTimeKind.Local).AddTicks(4474), "Voske", "BIH", "431 II", "Bakker, Meijer and Broek", "(8267) 906045", "Kostersteeg", 136 },
                    { 71, null, "Stokskesluis", "ISR", "833 II", "Jacobs, Koning and Heuvel", "(5999) 919374", "Kokplantsoen", 54 },
                    { 72, new DateTime(2024, 10, 13, 12, 44, 18, 503, DateTimeKind.Local).AddTicks(7121), "Bakke", "MAF", "137a", "Vos - Koster", "(6842) 290713", "Mulderweg", 115 },
                    { 73, new DateTime(2024, 8, 15, 18, 36, 58, 936, DateTimeKind.Local).AddTicks(9372), "Lutke", "PSE", "857c", "Wal, Linden and Klein", "(7221) 390088", "Willemsmarkt", 80 },
                    { 74, new DateTime(2024, 8, 15, 21, 9, 57, 811, DateTimeKind.Local).AddTicks(5470), "Dulder aan de IJssel", "CUW", "457b", "Heuvel - Graaf", "(6769) 505603", "Beekgracht", 212 },
                    { 75, null, "Patrijzenbosch", "AUT", "62", "Dam, Veen and Bakker", "(0069) 639178", "Bruindijk", 80 },
                    { 76, null, "Wytgaard", "ESP", "8", "Smit Group", "(2924) 908899", "Koningmarkt", 153 },
                    { 77, null, "Heesseltdam", "BRA", "474 III", "Smit, Meer and Dekker", "(1381) 271717", "Isakade", 164 },
                    { 78, null, "Prickartwier", "BLR", "502", "Meer - Klein", "(4833) 008726", "Tomstraat", 6 },
                    { 79, null, "Katerveer", "SHN", "420c", "Linden, Koning and Jacobs", "(6263) 704287", "Smitsteeg", 255 },
                    { 80, null, "Kuiks", "FLK", "510a", "Ruiter, Ruiter and Schouten", "(1826) 826065", "Maudpark", 187 },
                    { 81, new DateTime(2024, 2, 14, 20, 44, 36, 879, DateTimeKind.Local).AddTicks(577), "Uitwierdevliet", "BEL", "6", "Kok, Stichting and Dekker", "(2609) 029997", "Finnsloot", 179 },
                    { 82, null, "Engelen", "CMR", "335", "Broek Maatschappij", "(1783) 582591", "Timweg", 80 },
                    { 83, null, "Plaats", "HTI", "51", "Dijkstra - Linden", "(7434) 555833", "Grootsloot", 54 },
                    { 84, null, "Loons", "BLR", "517c", "Smits - Smit", "(2175) 312365", "Thomasdijk", 96 },
                    { 85, new DateTime(2024, 5, 14, 14, 11, 24, 144, DateTimeKind.Local).AddTicks(786), "Bultingevliet", "FRO", "225b", "Berg N.V.", "(3819) 499487", "Jansenlaan", 167 },
                    { 86, null, "Duizend", "SYR", "224a", "Dijk V.O.F.", "(8468) 052631", "Rubenplein", 208 },
                    { 87, null, "Witten", "FRA", "0", "Vermeulen Groep", "(2418) 479845", "Meersloot", 255 },
                    { 88, null, "Rullen", "MNP", "450", "Graaf B.V.", "(4716) 873204", "Dijksloot", 60 },
                    { 89, null, "Logt", "NZL", "565 II", "Janssen, Graaf and Dam", "(0678) 825889", "Basplein", 187 },
                    { 90, null, "Stein", "BIH", "089 II", "Haan - Brouwer", "(8019) 290451", "Peterspassage", 6 },
                    { 91, new DateTime(2024, 3, 19, 8, 40, 11, 760, DateTimeKind.Local).AddTicks(6678), "Zwaag", "BLZ", "6", "Vermeulen en Zonen", "(9757) 057707", "Janssenplantsoen", 192 },
                    { 92, new DateTime(2024, 5, 1, 0, 43, 50, 204, DateTimeKind.Local).AddTicks(5820), "Berghemhoek", "ESH", "03", "Mulder, Veen and Smit", "(4480) 413771", "Lindenlaan", 164 },
                    { 93, new DateTime(2024, 1, 15, 12, 50, 5, 274, DateTimeKind.Local).AddTicks(499), "Barlagezijl", "GIB", "2", "Dekker B.V.", "(8683) 116385", "Thijsplein", 167 },
                    { 94, new DateTime(2024, 11, 25, 5, 16, 53, 228, DateTimeKind.Local).AddTicks(1329), "Mispelvliet", "LBR", "752", "Dijk - Willems", "(7532) 990022", "Leeuwenlaan", 80 },
                    { 95, null, "Orvelte", "PER", "0", "Broek N.V.", "(8097) 149346", "Liekestraat", 94 },
                    { 96, new DateTime(2024, 5, 21, 4, 15, 43, 608, DateTimeKind.Local).AddTicks(9578), "Gaar", "UKR", "136b", "Koster Group", "(4550) 544580", "Jaydenweg", 189 },
                    { 97, null, "Lintvelde", "USA", "40", "Wit - Ruiter", "(5058) 872154", "Maxpassage", 115 },
                    { 98, null, "Rietveen", "MAR", "742", "Jacobs, Bos and Berg", "(5439) 718064", "Milanmarkt", 225 },
                    { 99, null, "Ruimel", "MAR", "2", "Stichting Group", "(7060) 587356", "Nickpassage", 179 },
                    { 100, new DateTime(2024, 9, 3, 16, 54, 44, 924, DateTimeKind.Local).AddTicks(6160), "Elft", "BIH", "986b", "Mulder - Bos", "(3765) 316101", "Witgracht", 167 }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Date", "IsApproved", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 15, 5, 2, 22, 102, DateTimeKind.Local).AddTicks(4890), (sbyte)0, 67 },
                    { 2, new DateTime(2024, 7, 13, 17, 16, 29, 47, DateTimeKind.Local).AddTicks(8034), (sbyte)1, 197 },
                    { 3, new DateTime(2024, 9, 12, 23, 43, 50, 377, DateTimeKind.Local).AddTicks(9388), (sbyte)1, 226 },
                    { 4, new DateTime(2024, 5, 10, 7, 16, 38, 320, DateTimeKind.Local).AddTicks(585), (sbyte)0, 172 },
                    { 5, new DateTime(2024, 1, 10, 21, 15, 19, 409, DateTimeKind.Local).AddTicks(5422), (sbyte)0, 221 },
                    { 6, new DateTime(2024, 3, 2, 7, 43, 17, 945, DateTimeKind.Local).AddTicks(780), (sbyte)0, 88 },
                    { 7, new DateTime(2024, 9, 16, 22, 23, 5, 115, DateTimeKind.Local).AddTicks(3370), (sbyte)1, 67 },
                    { 8, new DateTime(2024, 8, 22, 12, 12, 33, 803, DateTimeKind.Local).AddTicks(950), (sbyte)0, 16 },
                    { 9, new DateTime(2024, 3, 30, 5, 53, 34, 103, DateTimeKind.Local).AddTicks(1620), (sbyte)1, 47 },
                    { 10, new DateTime(2024, 8, 11, 10, 30, 48, 597, DateTimeKind.Local).AddTicks(9615), (sbyte)1, 241 },
                    { 11, new DateTime(2023, 12, 12, 12, 22, 22, 642, DateTimeKind.Local).AddTicks(5811), (sbyte)1, 70 },
                    { 12, new DateTime(2024, 2, 15, 14, 31, 52, 713, DateTimeKind.Local).AddTicks(9344), (sbyte)1, 171 },
                    { 13, new DateTime(2024, 3, 17, 5, 43, 31, 103, DateTimeKind.Local).AddTicks(4485), (sbyte)0, 32 },
                    { 14, new DateTime(2024, 8, 13, 16, 59, 58, 564, DateTimeKind.Local).AddTicks(2867), (sbyte)1, 197 },
                    { 15, new DateTime(2024, 2, 24, 20, 43, 22, 387, DateTimeKind.Local).AddTicks(9774), (sbyte)0, 241 },
                    { 16, new DateTime(2024, 4, 2, 8, 18, 36, 794, DateTimeKind.Local).AddTicks(7726), (sbyte)1, 16 },
                    { 17, new DateTime(2023, 12, 21, 15, 13, 28, 443, DateTimeKind.Local).AddTicks(2321), (sbyte)0, 218 },
                    { 18, new DateTime(2024, 7, 15, 5, 59, 55, 18, DateTimeKind.Local).AddTicks(5155), (sbyte)1, 143 },
                    { 19, new DateTime(2024, 9, 5, 23, 16, 12, 414, DateTimeKind.Local).AddTicks(3865), (sbyte)1, 125 },
                    { 20, new DateTime(2024, 5, 25, 12, 53, 30, 475, DateTimeKind.Local).AddTicks(5455), (sbyte)1, 241 },
                    { 21, new DateTime(2024, 10, 1, 8, 46, 32, 207, DateTimeKind.Local).AddTicks(5638), (sbyte)1, 16 },
                    { 22, new DateTime(2024, 5, 20, 18, 2, 43, 828, DateTimeKind.Local).AddTicks(9800), (sbyte)0, 197 },
                    { 23, new DateTime(2024, 7, 15, 19, 54, 1, 850, DateTimeKind.Local).AddTicks(9001), (sbyte)1, 221 },
                    { 24, new DateTime(2024, 6, 7, 17, 4, 19, 705, DateTimeKind.Local).AddTicks(2053), (sbyte)0, 89 },
                    { 25, new DateTime(2024, 5, 2, 9, 51, 40, 819, DateTimeKind.Local).AddTicks(3599), (sbyte)1, 240 },
                    { 26, new DateTime(2024, 7, 8, 2, 45, 55, 577, DateTimeKind.Local).AddTicks(2480), (sbyte)0, 135 },
                    { 27, new DateTime(2024, 7, 21, 0, 0, 27, 278, DateTimeKind.Local).AddTicks(4530), (sbyte)0, 49 },
                    { 28, new DateTime(2024, 7, 28, 13, 45, 2, 79, DateTimeKind.Local).AddTicks(229), (sbyte)1, 83 },
                    { 29, new DateTime(2024, 7, 7, 1, 5, 4, 570, DateTimeKind.Local).AddTicks(3731), (sbyte)1, 14 },
                    { 30, new DateTime(2024, 3, 16, 23, 21, 4, 795, DateTimeKind.Local).AddTicks(1356), (sbyte)0, 125 },
                    { 31, new DateTime(2024, 2, 26, 14, 49, 24, 497, DateTimeKind.Local).AddTicks(9146), (sbyte)0, 171 },
                    { 32, new DateTime(2024, 5, 21, 10, 28, 0, 811, DateTimeKind.Local).AddTicks(843), (sbyte)0, 229 },
                    { 33, new DateTime(2024, 6, 18, 20, 45, 37, 448, DateTimeKind.Local).AddTicks(7262), (sbyte)1, 226 },
                    { 34, new DateTime(2024, 2, 4, 21, 18, 48, 358, DateTimeKind.Local).AddTicks(9815), (sbyte)0, 50 },
                    { 35, new DateTime(2024, 3, 8, 12, 55, 44, 731, DateTimeKind.Local).AddTicks(6103), (sbyte)0, 122 },
                    { 36, new DateTime(2024, 10, 26, 22, 42, 47, 921, DateTimeKind.Local).AddTicks(689), (sbyte)0, 122 },
                    { 37, new DateTime(2024, 8, 14, 8, 43, 19, 366, DateTimeKind.Local).AddTicks(2927), (sbyte)0, 47 },
                    { 38, new DateTime(2024, 7, 21, 23, 47, 29, 34, DateTimeKind.Local).AddTicks(4674), (sbyte)1, 218 },
                    { 39, new DateTime(2024, 6, 3, 1, 38, 0, 329, DateTimeKind.Local).AddTicks(8737), (sbyte)1, 49 },
                    { 40, new DateTime(2024, 1, 5, 4, 51, 23, 395, DateTimeKind.Local).AddTicks(2995), (sbyte)0, 89 },
                    { 41, new DateTime(2024, 2, 20, 14, 6, 32, 895, DateTimeKind.Local).AddTicks(2468), (sbyte)1, 98 },
                    { 42, new DateTime(2023, 12, 20, 4, 6, 39, 88, DateTimeKind.Local).AddTicks(7579), (sbyte)0, 67 },
                    { 43, new DateTime(2024, 9, 4, 18, 50, 15, 861, DateTimeKind.Local).AddTicks(1006), (sbyte)1, 143 },
                    { 44, new DateTime(2023, 12, 17, 6, 52, 27, 229, DateTimeKind.Local).AddTicks(184), (sbyte)0, 149 },
                    { 45, new DateTime(2023, 12, 13, 14, 52, 43, 877, DateTimeKind.Local).AddTicks(1911), (sbyte)0, 130 },
                    { 46, new DateTime(2024, 1, 29, 22, 48, 36, 181, DateTimeKind.Local).AddTicks(7588), (sbyte)0, 221 },
                    { 47, new DateTime(2024, 4, 29, 10, 5, 37, 76, DateTimeKind.Local).AddTicks(1449), (sbyte)0, 229 },
                    { 48, new DateTime(2024, 7, 28, 9, 14, 37, 883, DateTimeKind.Local).AddTicks(6371), (sbyte)1, 126 },
                    { 49, new DateTime(2024, 7, 26, 21, 43, 43, 140, DateTimeKind.Local).AddTicks(1237), (sbyte)0, 229 },
                    { 50, new DateTime(2024, 3, 21, 8, 18, 35, 493, DateTimeKind.Local).AddTicks(4961), (sbyte)1, 16 }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Date", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 24, 20, 11, 37, 8, DateTimeKind.Local).AddTicks(8231), 2 },
                    { 2, new DateTime(2024, 4, 30, 13, 44, 3, 586, DateTimeKind.Local).AddTicks(9531), 18 },
                    { 3, new DateTime(2024, 9, 27, 12, 7, 57, 784, DateTimeKind.Local).AddTicks(7575), 11 },
                    { 4, new DateTime(2023, 12, 10, 22, 4, 52, 23, DateTimeKind.Local).AddTicks(5684), 225 },
                    { 5, new DateTime(2024, 5, 27, 8, 39, 50, 994, DateTimeKind.Local).AddTicks(2524), 255 },
                    { 6, new DateTime(2024, 3, 21, 14, 26, 41, 441, DateTimeKind.Local).AddTicks(3514), 131 },
                    { 7, new DateTime(2024, 10, 24, 3, 15, 4, 91, DateTimeKind.Local).AddTicks(76), 38 },
                    { 8, new DateTime(2024, 3, 11, 9, 45, 50, 995, DateTimeKind.Local).AddTicks(731), 164 },
                    { 9, new DateTime(2024, 3, 1, 16, 13, 8, 83, DateTimeKind.Local).AddTicks(8924), 6 },
                    { 10, new DateTime(2024, 11, 23, 16, 52, 46, 116, DateTimeKind.Local).AddTicks(8655), 189 },
                    { 11, new DateTime(2024, 3, 10, 19, 30, 12, 997, DateTimeKind.Local).AddTicks(3707), 212 },
                    { 12, new DateTime(2023, 12, 2, 18, 55, 14, 509, DateTimeKind.Local).AddTicks(9170), 212 },
                    { 13, new DateTime(2024, 9, 5, 3, 37, 35, 510, DateTimeKind.Local).AddTicks(7250), 216 },
                    { 14, new DateTime(2024, 9, 16, 9, 5, 29, 197, DateTimeKind.Local).AddTicks(6412), 2 },
                    { 15, new DateTime(2024, 7, 17, 3, 45, 11, 360, DateTimeKind.Local).AddTicks(5247), 94 },
                    { 16, new DateTime(2024, 1, 7, 22, 52, 52, 763, DateTimeKind.Local).AddTicks(5716), 217 },
                    { 17, new DateTime(2024, 9, 8, 22, 44, 39, 515, DateTimeKind.Local).AddTicks(4799), 164 },
                    { 18, new DateTime(2024, 3, 28, 20, 38, 8, 703, DateTimeKind.Local).AddTicks(3574), 38 },
                    { 19, new DateTime(2024, 3, 6, 3, 2, 54, 282, DateTimeKind.Local).AddTicks(5165), 217 },
                    { 20, new DateTime(2024, 3, 12, 19, 54, 41, 483, DateTimeKind.Local).AddTicks(8111), 189 },
                    { 21, new DateTime(2024, 8, 17, 14, 4, 57, 289, DateTimeKind.Local).AddTicks(2131), 112 },
                    { 22, new DateTime(2024, 9, 17, 23, 56, 7, 986, DateTimeKind.Local).AddTicks(3369), 230 },
                    { 23, new DateTime(2024, 7, 26, 10, 9, 19, 842, DateTimeKind.Local).AddTicks(3596), 82 },
                    { 24, new DateTime(2024, 1, 26, 23, 33, 11, 996, DateTimeKind.Local).AddTicks(6693), 255 },
                    { 25, new DateTime(2024, 9, 22, 13, 56, 11, 773, DateTimeKind.Local).AddTicks(2730), 208 },
                    { 26, new DateTime(2024, 3, 2, 9, 54, 17, 540, DateTimeKind.Local).AddTicks(502), 187 },
                    { 27, new DateTime(2024, 2, 14, 0, 37, 54, 460, DateTimeKind.Local).AddTicks(1014), 128 },
                    { 28, new DateTime(2023, 12, 23, 5, 33, 9, 976, DateTimeKind.Local).AddTicks(2935), 115 },
                    { 29, new DateTime(2024, 11, 26, 15, 34, 41, 275, DateTimeKind.Local).AddTicks(4229), 64 },
                    { 30, new DateTime(2024, 6, 2, 17, 28, 26, 812, DateTimeKind.Local).AddTicks(6830), 183 },
                    { 31, new DateTime(2024, 11, 29, 9, 17, 48, 702, DateTimeKind.Local).AddTicks(1586), 118 },
                    { 32, new DateTime(2024, 6, 15, 12, 14, 38, 989, DateTimeKind.Local).AddTicks(7307), 230 },
                    { 33, new DateTime(2024, 9, 15, 10, 56, 24, 689, DateTimeKind.Local).AddTicks(7827), 136 },
                    { 34, new DateTime(2024, 1, 25, 5, 52, 47, 818, DateTimeKind.Local).AddTicks(3823), 141 },
                    { 35, new DateTime(2024, 3, 3, 22, 26, 48, 153, DateTimeKind.Local).AddTicks(6020), 121 },
                    { 36, new DateTime(2024, 5, 10, 18, 56, 42, 279, DateTimeKind.Local).AddTicks(8873), 255 },
                    { 37, new DateTime(2024, 5, 21, 9, 5, 25, 814, DateTimeKind.Local).AddTicks(1246), 74 },
                    { 38, new DateTime(2023, 12, 30, 11, 27, 6, 502, DateTimeKind.Local).AddTicks(6168), 18 },
                    { 39, new DateTime(2023, 12, 16, 23, 58, 32, 933, DateTimeKind.Local).AddTicks(9753), 194 },
                    { 40, new DateTime(2024, 10, 6, 19, 6, 56, 353, DateTimeKind.Local).AddTicks(4253), 158 },
                    { 41, new DateTime(2024, 8, 10, 3, 2, 29, 549, DateTimeKind.Local).AddTicks(5018), 179 },
                    { 42, new DateTime(2023, 11, 29, 15, 50, 45, 755, DateTimeKind.Local).AddTicks(4303), 236 },
                    { 43, new DateTime(2024, 7, 30, 15, 14, 23, 793, DateTimeKind.Local).AddTicks(9932), 71 },
                    { 44, new DateTime(2024, 1, 24, 23, 43, 5, 547, DateTimeKind.Local).AddTicks(6963), 71 },
                    { 45, new DateTime(2024, 6, 16, 21, 8, 42, 472, DateTimeKind.Local).AddTicks(9060), 18 },
                    { 46, new DateTime(2024, 3, 24, 19, 14, 30, 625, DateTimeKind.Local).AddTicks(6429), 230 },
                    { 47, new DateTime(2024, 7, 27, 17, 50, 4, 70, DateTimeKind.Local).AddTicks(7708), 131 },
                    { 48, new DateTime(2023, 12, 25, 6, 20, 23, 365, DateTimeKind.Local).AddTicks(6168), 54 },
                    { 49, new DateTime(2024, 9, 27, 19, 55, 25, 145, DateTimeKind.Local).AddTicks(287), 2 },
                    { 50, new DateTime(2024, 7, 30, 14, 16, 29, 560, DateTimeKind.Local).AddTicks(1153), 38 }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "CompanyId", "EndDate", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2026, 11, 30, 10, 34, 26, 351, DateTimeKind.Unspecified).AddTicks(6796), new DateTime(2017, 5, 12, 17, 13, 55, 71, DateTimeKind.Unspecified).AddTicks(86), "Perodic" },
                    { 2, 59, new DateTime(2027, 7, 1, 13, 36, 28, 317, DateTimeKind.Unspecified).AddTicks(3288), new DateTime(2017, 2, 14, 10, 36, 18, 123, DateTimeKind.Unspecified).AddTicks(6776), "Monthly" },
                    { 3, 71, new DateTime(2020, 11, 24, 12, 32, 28, 612, DateTimeKind.Unspecified).AddTicks(412), new DateTime(2017, 10, 22, 19, 12, 5, 30, DateTimeKind.Unspecified).AddTicks(8133), "Perodic" },
                    { 4, 39, new DateTime(2028, 2, 2, 14, 52, 41, 910, DateTimeKind.Unspecified).AddTicks(9542), new DateTime(2017, 10, 11, 5, 59, 11, 667, DateTimeKind.Unspecified).AddTicks(670), "Perodic" },
                    { 5, 57, new DateTime(2024, 6, 30, 18, 11, 25, 478, DateTimeKind.Unspecified).AddTicks(6930), new DateTime(2019, 6, 18, 5, 46, 25, 457, DateTimeKind.Unspecified).AddTicks(9248), "Perodic" },
                    { 6, 62, new DateTime(2027, 3, 13, 4, 48, 10, 865, DateTimeKind.Unspecified).AddTicks(8480), new DateTime(2018, 9, 1, 7, 36, 56, 871, DateTimeKind.Unspecified).AddTicks(7500), "Perodic" },
                    { 7, 83, new DateTime(2027, 11, 26, 21, 15, 48, 306, DateTimeKind.Unspecified).AddTicks(2201), new DateTime(2023, 7, 29, 10, 52, 38, 168, DateTimeKind.Unspecified).AddTicks(2718), "Perodic" },
                    { 8, 80, new DateTime(2022, 4, 11, 3, 34, 34, 97, DateTimeKind.Unspecified).AddTicks(4703), new DateTime(2017, 11, 15, 15, 0, 27, 93, DateTimeKind.Unspecified).AddTicks(3037), "Perodic" },
                    { 9, 84, new DateTime(2022, 3, 5, 1, 58, 56, 509, DateTimeKind.Unspecified).AddTicks(1355), new DateTime(2022, 4, 23, 16, 24, 17, 698, DateTimeKind.Unspecified).AddTicks(4058), "Monthly" },
                    { 10, 15, new DateTime(2021, 1, 25, 0, 54, 42, 922, DateTimeKind.Unspecified).AddTicks(8314), new DateTime(2023, 12, 10, 13, 7, 7, 903, DateTimeKind.Unspecified).AddTicks(1931), "Monthly" },
                    { 11, 32, new DateTime(2021, 6, 17, 9, 44, 50, 257, DateTimeKind.Unspecified).AddTicks(2985), new DateTime(2015, 7, 22, 16, 13, 53, 472, DateTimeKind.Unspecified).AddTicks(982), "Monthly" },
                    { 12, 44, new DateTime(2026, 9, 11, 3, 4, 14, 200, DateTimeKind.Unspecified).AddTicks(8336), new DateTime(2016, 5, 1, 8, 41, 33, 360, DateTimeKind.Unspecified).AddTicks(2692), "Monthly" },
                    { 13, 80, new DateTime(2028, 3, 15, 20, 14, 1, 490, DateTimeKind.Unspecified).AddTicks(9388), new DateTime(2020, 4, 27, 17, 26, 1, 421, DateTimeKind.Unspecified).AddTicks(1848), "Monthly" },
                    { 14, 72, new DateTime(2029, 12, 20, 7, 5, 22, 654, DateTimeKind.Unspecified).AddTicks(8252), new DateTime(2020, 11, 22, 4, 48, 54, 597, DateTimeKind.Unspecified).AddTicks(5558), "Monthly" },
                    { 15, 40, new DateTime(2030, 12, 15, 8, 22, 54, 935, DateTimeKind.Unspecified).AddTicks(110), new DateTime(2021, 4, 11, 13, 7, 18, 284, DateTimeKind.Unspecified).AddTicks(4516), "Perodic" },
                    { 16, 90, new DateTime(2024, 12, 27, 6, 42, 21, 130, DateTimeKind.Unspecified).AddTicks(6479), new DateTime(2016, 3, 22, 1, 15, 36, 242, DateTimeKind.Unspecified).AddTicks(2811), "Monthly" },
                    { 17, 93, new DateTime(2023, 3, 23, 18, 45, 23, 186, DateTimeKind.Unspecified).AddTicks(3879), new DateTime(2017, 8, 15, 21, 20, 42, 100, DateTimeKind.Unspecified).AddTicks(1019), "Monthly" },
                    { 18, 15, new DateTime(2023, 1, 3, 23, 38, 15, 177, DateTimeKind.Unspecified).AddTicks(4848), new DateTime(2020, 3, 28, 14, 20, 19, 486, DateTimeKind.Unspecified).AddTicks(6729), "Perodic" },
                    { 19, 50, new DateTime(2026, 3, 6, 21, 11, 54, 653, DateTimeKind.Unspecified).AddTicks(5329), new DateTime(2022, 11, 8, 5, 14, 48, 106, DateTimeKind.Unspecified).AddTicks(5900), "Monthly" },
                    { 20, 80, new DateTime(2021, 2, 28, 22, 5, 23, 219, DateTimeKind.Unspecified).AddTicks(5981), new DateTime(2020, 12, 15, 20, 35, 47, 107, DateTimeKind.Unspecified).AddTicks(1693), "Perodic" },
                    { 21, 25, new DateTime(2026, 10, 5, 14, 32, 38, 846, DateTimeKind.Unspecified).AddTicks(6224), new DateTime(2016, 4, 14, 3, 29, 28, 991, DateTimeKind.Unspecified).AddTicks(195), "Monthly" },
                    { 22, 11, new DateTime(2021, 5, 5, 21, 51, 0, 265, DateTimeKind.Unspecified).AddTicks(8604), new DateTime(2019, 6, 23, 23, 54, 22, 966, DateTimeKind.Unspecified).AddTicks(744), "Monthly" },
                    { 23, 16, new DateTime(2028, 9, 25, 9, 21, 42, 888, DateTimeKind.Unspecified).AddTicks(5580), new DateTime(2016, 9, 23, 5, 57, 1, 380, DateTimeKind.Unspecified).AddTicks(7829), "Perodic" },
                    { 24, 76, new DateTime(2030, 4, 1, 23, 8, 26, 3, DateTimeKind.Unspecified).AddTicks(9114), new DateTime(2015, 4, 16, 13, 10, 44, 959, DateTimeKind.Unspecified).AddTicks(7538), "Monthly" },
                    { 25, 36, new DateTime(2026, 6, 19, 17, 22, 16, 647, DateTimeKind.Unspecified).AddTicks(5224), new DateTime(2021, 5, 31, 9, 43, 49, 783, DateTimeKind.Unspecified).AddTicks(6982), "Monthly" },
                    { 26, 31, new DateTime(2020, 12, 19, 5, 51, 7, 957, DateTimeKind.Unspecified).AddTicks(532), new DateTime(2022, 4, 20, 4, 29, 40, 917, DateTimeKind.Unspecified).AddTicks(1240), "Monthly" },
                    { 27, 27, new DateTime(2028, 1, 25, 4, 20, 28, 246, DateTimeKind.Unspecified).AddTicks(3814), new DateTime(2022, 12, 7, 3, 55, 42, 282, DateTimeKind.Unspecified).AddTicks(8669), "Perodic" },
                    { 28, 81, new DateTime(2026, 10, 13, 3, 31, 6, 860, DateTimeKind.Unspecified).AddTicks(3496), new DateTime(2018, 9, 12, 7, 57, 16, 516, DateTimeKind.Unspecified).AddTicks(1435), "Monthly" },
                    { 29, 92, new DateTime(2025, 8, 15, 0, 55, 21, 269, DateTimeKind.Unspecified).AddTicks(1628), new DateTime(2018, 2, 20, 19, 31, 52, 726, DateTimeKind.Unspecified).AddTicks(6493), "Monthly" },
                    { 30, 25, new DateTime(2026, 9, 2, 12, 1, 51, 610, DateTimeKind.Unspecified).AddTicks(7708), new DateTime(2021, 9, 27, 13, 36, 5, 215, DateTimeKind.Unspecified).AddTicks(7511), "Perodic" },
                    { 31, 77, new DateTime(2024, 8, 14, 3, 33, 25, 702, DateTimeKind.Unspecified).AddTicks(3652), new DateTime(2016, 7, 11, 16, 39, 39, 941, DateTimeKind.Unspecified).AddTicks(6214), "Perodic" },
                    { 32, 20, new DateTime(2022, 2, 13, 12, 33, 38, 462, DateTimeKind.Unspecified).AddTicks(7757), new DateTime(2021, 3, 29, 19, 55, 30, 604, DateTimeKind.Unspecified).AddTicks(5295), "Perodic" },
                    { 33, 92, new DateTime(2029, 2, 4, 15, 16, 47, 800, DateTimeKind.Unspecified).AddTicks(7559), new DateTime(2019, 8, 29, 23, 6, 5, 904, DateTimeKind.Unspecified).AddTicks(9014), "Perodic" },
                    { 34, 81, new DateTime(2029, 3, 4, 2, 19, 32, 821, DateTimeKind.Unspecified).AddTicks(9694), new DateTime(2021, 6, 16, 14, 33, 57, 674, DateTimeKind.Unspecified).AddTicks(2008), "Monthly" },
                    { 35, 16, new DateTime(2028, 4, 30, 14, 3, 58, 564, DateTimeKind.Unspecified).AddTicks(964), new DateTime(2017, 7, 31, 14, 31, 26, 676, DateTimeKind.Unspecified).AddTicks(9953), "Monthly" },
                    { 36, 85, new DateTime(2030, 4, 22, 3, 0, 7, 963, DateTimeKind.Unspecified).AddTicks(2674), new DateTime(2015, 12, 31, 19, 22, 34, 829, DateTimeKind.Unspecified).AddTicks(5713), "Perodic" },
                    { 37, 78, new DateTime(2028, 10, 14, 17, 23, 43, 866, DateTimeKind.Unspecified).AddTicks(8264), new DateTime(2021, 3, 12, 1, 52, 33, 596, DateTimeKind.Unspecified).AddTicks(5390), "Monthly" },
                    { 38, 76, new DateTime(2024, 6, 27, 9, 3, 14, 817, DateTimeKind.Unspecified).AddTicks(2198), new DateTime(2020, 12, 23, 22, 4, 14, 199, DateTimeKind.Unspecified).AddTicks(1831), "Perodic" },
                    { 39, 15, new DateTime(2023, 11, 5, 9, 39, 2, 63, DateTimeKind.Unspecified).AddTicks(657), new DateTime(2017, 5, 14, 20, 29, 28, 779, DateTimeKind.Unspecified).AddTicks(868), "Perodic" },
                    { 40, 8, new DateTime(2020, 5, 26, 14, 1, 6, 226, DateTimeKind.Unspecified).AddTicks(6022), new DateTime(2021, 2, 14, 18, 44, 43, 480, DateTimeKind.Unspecified).AddTicks(3418), "Perodic" },
                    { 41, 44, new DateTime(2024, 1, 28, 17, 28, 9, 444, DateTimeKind.Unspecified).AddTicks(7242), new DateTime(2019, 1, 27, 11, 55, 43, 473, DateTimeKind.Unspecified).AddTicks(494), "Monthly" },
                    { 42, 3, new DateTime(2028, 1, 5, 20, 41, 23, 904, DateTimeKind.Unspecified).AddTicks(5134), new DateTime(2018, 9, 17, 15, 21, 19, 122, DateTimeKind.Unspecified).AddTicks(2839), "Monthly" },
                    { 43, 57, new DateTime(2022, 8, 4, 15, 18, 31, 159, DateTimeKind.Unspecified).AddTicks(8538), new DateTime(2015, 12, 18, 3, 48, 41, 198, DateTimeKind.Unspecified).AddTicks(2644), "Perodic" },
                    { 44, 19, new DateTime(2021, 7, 19, 12, 25, 3, 542, DateTimeKind.Unspecified).AddTicks(4401), new DateTime(2022, 10, 27, 6, 49, 24, 53, DateTimeKind.Unspecified).AddTicks(5084), "Monthly" },
                    { 45, 21, new DateTime(2024, 9, 26, 14, 25, 18, 331, DateTimeKind.Unspecified).AddTicks(6239), new DateTime(2018, 3, 9, 22, 4, 37, 625, DateTimeKind.Unspecified).AddTicks(772), "Perodic" },
                    { 46, 95, new DateTime(2020, 6, 30, 6, 58, 9, 130, DateTimeKind.Unspecified).AddTicks(712), new DateTime(2021, 1, 13, 7, 13, 17, 137, DateTimeKind.Unspecified).AddTicks(9759), "Perodic" },
                    { 47, 6, new DateTime(2025, 10, 12, 0, 13, 16, 598, DateTimeKind.Unspecified).AddTicks(1490), new DateTime(2018, 5, 15, 4, 49, 10, 332, DateTimeKind.Unspecified).AddTicks(8790), "Perodic" },
                    { 48, 31, new DateTime(2030, 10, 19, 21, 27, 51, 884, DateTimeKind.Unspecified).AddTicks(6929), new DateTime(2017, 4, 10, 16, 1, 5, 549, DateTimeKind.Unspecified).AddTicks(6304), "Monthly" },
                    { 49, 53, new DateTime(2026, 9, 8, 19, 42, 54, 788, DateTimeKind.Unspecified).AddTicks(3480), new DateTime(2015, 3, 14, 4, 59, 46, 24, DateTimeKind.Unspecified).AddTicks(7557), "Monthly" },
                    { 50, 40, new DateTime(2029, 2, 15, 7, 1, 35, 268, DateTimeKind.Unspecified).AddTicks(3199), new DateTime(2016, 4, 8, 20, 5, 25, 772, DateTimeKind.Unspecified).AddTicks(3177), "Perodic" }
                });

            migrationBuilder.InsertData(
                table: "CustomInvoices",
                columns: new[] { "Id", "CompanyId", "Date", "PaidAt" },
                values: new object[,]
                {
                    { 1, 54, new DateTime(2024, 11, 29, 8, 37, 35, 71, DateTimeKind.Local).AddTicks(3290), null },
                    { 2, 24, new DateTime(2024, 11, 28, 23, 41, 20, 522, DateTimeKind.Local).AddTicks(3640), null },
                    { 3, 30, new DateTime(2024, 11, 29, 7, 10, 1, 818, DateTimeKind.Local).AddTicks(3830), new DateTime(2024, 11, 28, 17, 5, 51, 308, DateTimeKind.Local).AddTicks(5397) },
                    { 4, 35, new DateTime(2024, 11, 28, 15, 9, 37, 334, DateTimeKind.Local).AddTicks(2512), new DateTime(2024, 11, 28, 23, 56, 41, 917, DateTimeKind.Local).AddTicks(4704) },
                    { 5, 28, new DateTime(2024, 11, 29, 9, 39, 29, 330, DateTimeKind.Local).AddTicks(2068), null },
                    { 6, 77, new DateTime(2024, 11, 29, 7, 13, 9, 703, DateTimeKind.Local).AddTicks(7732), null },
                    { 7, 27, new DateTime(2024, 11, 29, 1, 54, 35, 618, DateTimeKind.Local).AddTicks(2041), null },
                    { 8, 94, new DateTime(2024, 11, 28, 19, 31, 19, 554, DateTimeKind.Local).AddTicks(3471), new DateTime(2024, 11, 29, 11, 17, 57, 546, DateTimeKind.Local).AddTicks(8717) },
                    { 9, 45, new DateTime(2024, 11, 28, 21, 46, 21, 734, DateTimeKind.Local).AddTicks(9468), new DateTime(2024, 11, 29, 12, 33, 50, 406, DateTimeKind.Local).AddTicks(7700) },
                    { 10, 17, new DateTime(2024, 11, 28, 22, 45, 49, 681, DateTimeKind.Local).AddTicks(7935), null },
                    { 11, 40, new DateTime(2024, 11, 29, 14, 53, 48, 160, DateTimeKind.Local).AddTicks(9464), null },
                    { 12, 69, new DateTime(2024, 11, 29, 8, 13, 14, 798, DateTimeKind.Local).AddTicks(7511), new DateTime(2024, 11, 28, 22, 56, 21, 831, DateTimeKind.Local).AddTicks(2146) },
                    { 13, 89, new DateTime(2024, 11, 28, 18, 17, 31, 728, DateTimeKind.Local).AddTicks(4686), null },
                    { 14, 82, new DateTime(2024, 11, 29, 14, 39, 38, 428, DateTimeKind.Local).AddTicks(6649), new DateTime(2024, 11, 28, 18, 57, 23, 325, DateTimeKind.Local).AddTicks(9950) },
                    { 15, 39, new DateTime(2024, 11, 29, 4, 54, 29, 309, DateTimeKind.Local).AddTicks(5223), new DateTime(2024, 11, 29, 4, 1, 3, 801, DateTimeKind.Local).AddTicks(467) },
                    { 16, 32, new DateTime(2024, 11, 28, 23, 9, 49, 168, DateTimeKind.Local).AddTicks(2020), new DateTime(2024, 11, 28, 19, 15, 12, 264, DateTimeKind.Local).AddTicks(125) },
                    { 17, 78, new DateTime(2024, 11, 29, 8, 46, 38, 856, DateTimeKind.Local).AddTicks(4546), null },
                    { 18, 33, new DateTime(2024, 11, 29, 5, 57, 44, 103, DateTimeKind.Local).AddTicks(4538), new DateTime(2024, 11, 29, 1, 33, 7, 257, DateTimeKind.Local).AddTicks(3496) },
                    { 19, 15, new DateTime(2024, 11, 28, 18, 32, 58, 682, DateTimeKind.Local).AddTicks(1921), new DateTime(2024, 11, 29, 4, 23, 34, 865, DateTimeKind.Local).AddTicks(7257) },
                    { 20, 96, new DateTime(2024, 11, 28, 20, 27, 38, 669, DateTimeKind.Local).AddTicks(9623), new DateTime(2024, 11, 28, 20, 51, 25, 205, DateTimeKind.Local).AddTicks(6156) },
                    { 21, 77, new DateTime(2024, 11, 29, 13, 47, 25, 573, DateTimeKind.Local).AddTicks(4123), new DateTime(2024, 11, 29, 11, 55, 8, 299, DateTimeKind.Local).AddTicks(5430) },
                    { 22, 85, new DateTime(2024, 11, 29, 5, 42, 35, 348, DateTimeKind.Local).AddTicks(9673), null },
                    { 23, 40, new DateTime(2024, 11, 28, 18, 39, 10, 471, DateTimeKind.Local).AddTicks(6774), new DateTime(2024, 11, 29, 2, 42, 2, 704, DateTimeKind.Local).AddTicks(5932) },
                    { 24, 21, new DateTime(2024, 11, 28, 18, 17, 30, 4, DateTimeKind.Local).AddTicks(4786), new DateTime(2024, 11, 29, 3, 57, 12, 770, DateTimeKind.Local).AddTicks(2818) },
                    { 25, 87, new DateTime(2024, 11, 29, 9, 15, 30, 542, DateTimeKind.Local).AddTicks(4472), new DateTime(2024, 11, 29, 11, 16, 59, 631, DateTimeKind.Local).AddTicks(7104) },
                    { 26, 4, new DateTime(2024, 11, 29, 11, 30, 41, 207, DateTimeKind.Local).AddTicks(2714), null },
                    { 27, 2, new DateTime(2024, 11, 29, 2, 29, 55, 559, DateTimeKind.Local).AddTicks(2083), new DateTime(2024, 11, 29, 1, 34, 6, 331, DateTimeKind.Local).AddTicks(3802) },
                    { 28, 78, new DateTime(2024, 11, 29, 11, 24, 28, 655, DateTimeKind.Local).AddTicks(9055), new DateTime(2024, 11, 28, 22, 16, 25, 414, DateTimeKind.Local).AddTicks(1001) },
                    { 29, 39, new DateTime(2024, 11, 28, 23, 42, 42, 405, DateTimeKind.Local).AddTicks(4388), null },
                    { 30, 90, new DateTime(2024, 11, 29, 4, 56, 15, 890, DateTimeKind.Local).AddTicks(3498), new DateTime(2024, 11, 29, 5, 22, 3, 180, DateTimeKind.Local).AddTicks(891) },
                    { 31, 62, new DateTime(2024, 11, 29, 3, 49, 59, 34, DateTimeKind.Local).AddTicks(3170), null },
                    { 32, 17, new DateTime(2024, 11, 29, 12, 49, 37, 801, DateTimeKind.Local).AddTicks(3203), null },
                    { 33, 4, new DateTime(2024, 11, 29, 14, 7, 3, 162, DateTimeKind.Local).AddTicks(5923), new DateTime(2024, 11, 29, 11, 42, 35, 701, DateTimeKind.Local).AddTicks(6752) },
                    { 34, 6, new DateTime(2024, 11, 29, 8, 38, 12, 146, DateTimeKind.Local).AddTicks(3232), new DateTime(2024, 11, 29, 8, 16, 15, 692, DateTimeKind.Local).AddTicks(7615) },
                    { 35, 12, new DateTime(2024, 11, 29, 8, 53, 12, 457, DateTimeKind.Local).AddTicks(2793), null },
                    { 36, 6, new DateTime(2024, 11, 29, 13, 32, 40, 234, DateTimeKind.Local).AddTicks(3426), new DateTime(2024, 11, 28, 15, 43, 58, 480, DateTimeKind.Local).AddTicks(932) },
                    { 37, 65, new DateTime(2024, 11, 29, 7, 53, 45, 1, DateTimeKind.Local).AddTicks(621), null },
                    { 38, 11, new DateTime(2024, 11, 29, 0, 11, 25, 198, DateTimeKind.Local).AddTicks(9158), null },
                    { 39, 17, new DateTime(2024, 11, 28, 23, 27, 0, 440, DateTimeKind.Local).AddTicks(8002), null },
                    { 40, 76, new DateTime(2024, 11, 29, 12, 26, 0, 863, DateTimeKind.Local).AddTicks(8875), null },
                    { 41, 54, new DateTime(2024, 11, 28, 20, 15, 56, 793, DateTimeKind.Local).AddTicks(7915), new DateTime(2024, 11, 29, 7, 1, 9, 493, DateTimeKind.Local).AddTicks(2584) },
                    { 42, 55, new DateTime(2024, 11, 28, 20, 53, 34, 558, DateTimeKind.Local).AddTicks(8148), new DateTime(2024, 11, 29, 13, 59, 16, 294, DateTimeKind.Local).AddTicks(9866) },
                    { 43, 79, new DateTime(2024, 11, 28, 19, 24, 42, 168, DateTimeKind.Local).AddTicks(5415), null },
                    { 44, 74, new DateTime(2024, 11, 29, 0, 45, 43, 133, DateTimeKind.Local).AddTicks(5180), new DateTime(2024, 11, 29, 3, 19, 53, 470, DateTimeKind.Local).AddTicks(9214) },
                    { 45, 48, new DateTime(2024, 11, 29, 12, 28, 55, 982, DateTimeKind.Local).AddTicks(3866), null },
                    { 46, 29, new DateTime(2024, 11, 28, 20, 26, 16, 268, DateTimeKind.Local).AddTicks(5999), null },
                    { 47, 21, new DateTime(2024, 11, 28, 18, 48, 32, 635, DateTimeKind.Local).AddTicks(6028), new DateTime(2024, 11, 28, 18, 57, 15, 601, DateTimeKind.Local).AddTicks(3954) },
                    { 48, 49, new DateTime(2024, 11, 29, 9, 9, 53, 454, DateTimeKind.Local).AddTicks(3000), null },
                    { 49, 59, new DateTime(2024, 11, 29, 10, 35, 6, 750, DateTimeKind.Local).AddTicks(9509), null },
                    { 50, 35, new DateTime(2024, 11, 29, 0, 24, 17, 137, DateTimeKind.Local).AddTicks(6298), null }
                });

            migrationBuilder.InsertData(
                table: "ExpenseProducts",
                columns: new[] { "Id", "ExpenseId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 4, 48, 309 },
                    { 2, 33, 7, 420 },
                    { 3, 29, 11, 305 },
                    { 4, 7, 32, 516 },
                    { 5, 20, 31, 253 },
                    { 6, 30, 38, 5 },
                    { 7, 43, 6, 220 },
                    { 8, 25, 39, 530 },
                    { 9, 10, 46, 852 },
                    { 10, 24, 7, 259 },
                    { 11, 9, 12, 488 },
                    { 12, 8, 20, 693 },
                    { 13, 20, 20, 295 },
                    { 14, 45, 12, 203 },
                    { 15, 33, 39, 50 },
                    { 16, 45, 31, 432 },
                    { 17, 47, 13, 424 },
                    { 18, 13, 16, 403 },
                    { 19, 16, 11, 900 },
                    { 20, 27, 34, 311 },
                    { 21, 42, 48, 312 },
                    { 22, 40, 50, 171 },
                    { 23, 38, 24, 821 },
                    { 24, 23, 4, 839 },
                    { 25, 12, 13, 55 },
                    { 26, 28, 43, 990 },
                    { 27, 5, 43, 537 },
                    { 28, 15, 5, 870 },
                    { 29, 30, 43, 368 },
                    { 30, 39, 9, 697 },
                    { 31, 37, 40, 645 },
                    { 32, 13, 39, 207 },
                    { 33, 21, 3, 216 },
                    { 34, 20, 47, 817 },
                    { 35, 39, 42, 303 },
                    { 36, 3, 39, 139 },
                    { 37, 48, 16, 875 },
                    { 38, 38, 38, 651 },
                    { 39, 47, 9, 972 },
                    { 40, 15, 5, 96 },
                    { 41, 6, 23, 358 },
                    { 42, 7, 37, 127 },
                    { 43, 15, 1, 107 },
                    { 44, 29, 38, 932 },
                    { 45, 11, 2, 257 },
                    { 46, 29, 42, 864 },
                    { 47, 30, 6, 417 },
                    { 48, 48, 23, 514 },
                    { 49, 33, 43, 897 },
                    { 50, 15, 32, 784 },
                    { 51, 22, 40, 142 },
                    { 52, 18, 46, 696 },
                    { 53, 36, 10, 802 },
                    { 54, 4, 1, 186 },
                    { 55, 19, 25, 767 },
                    { 56, 20, 48, 229 },
                    { 57, 45, 29, 748 },
                    { 58, 35, 44, 651 },
                    { 59, 26, 48, 651 },
                    { 60, 24, 27, 298 },
                    { 61, 43, 3, 881 },
                    { 62, 19, 33, 465 },
                    { 63, 47, 17, 419 },
                    { 64, 27, 35, 232 },
                    { 65, 50, 29, 658 },
                    { 66, 1, 4, 492 },
                    { 67, 50, 47, 726 },
                    { 68, 8, 37, 871 },
                    { 69, 44, 40, 244 },
                    { 70, 7, 40, 643 },
                    { 71, 9, 21, 161 },
                    { 72, 38, 16, 409 },
                    { 73, 17, 43, 321 },
                    { 74, 41, 7, 625 },
                    { 75, 50, 23, 796 },
                    { 76, 11, 37, 138 },
                    { 77, 30, 46, 798 },
                    { 78, 8, 9, 387 },
                    { 79, 2, 46, 287 },
                    { 80, 45, 39, 652 },
                    { 81, 5, 5, 581 },
                    { 82, 15, 24, 302 },
                    { 83, 38, 30, 377 },
                    { 84, 41, 46, 858 },
                    { 85, 15, 13, 844 },
                    { 86, 47, 4, 970 },
                    { 87, 10, 3, 441 },
                    { 88, 42, 6, 864 },
                    { 89, 37, 10, 267 },
                    { 90, 4, 33, 375 },
                    { 91, 34, 29, 16 },
                    { 92, 35, 49, 965 },
                    { 93, 35, 43, 261 },
                    { 94, 16, 48, 254 },
                    { 95, 37, 31, 245 },
                    { 96, 42, 13, 426 },
                    { 97, 47, 46, 972 },
                    { 98, 40, 36, 176 },
                    { 99, 27, 43, 164 },
                    { 100, 17, 45, 623 }
                });

            migrationBuilder.InsertData(
                table: "MaintenaceAppointments",
                columns: new[] { "Id", "CompanyId", "DateAdded", "Remark" },
                values: new object[,]
                {
                    { 1, 33, new DateTime(2024, 11, 29, 8, 23, 19, 504, DateTimeKind.Local).AddTicks(7118), "Id praesentium tenetur totam qui quisquam recusandae et nulla error." },
                    { 2, 82, new DateTime(2024, 11, 29, 9, 46, 41, 478, DateTimeKind.Local).AddTicks(4909), "molestiae" },
                    { 3, 94, new DateTime(2024, 11, 28, 21, 39, 20, 125, DateTimeKind.Local).AddTicks(4215), "Maxime harum sit asperiores et non enim sequi nihil. Et illo harum omnis laboriosam ut. Aperiam placeat animi sit asperiores laudantium molestiae. Et suscipit consectetur. Et cumque et quis." },
                    { 4, 100, new DateTime(2024, 11, 29, 1, 51, 53, 285, DateTimeKind.Local).AddTicks(3392), "Id aut non numquam.\nConsequatur minima voluptatem doloribus et ad fugiat exercitationem velit unde.\nAut dolore porro cumque perspiciatis et quam unde.\nEst pariatur ex totam." },
                    { 5, 75, new DateTime(2024, 11, 29, 10, 18, 50, 595, DateTimeKind.Local).AddTicks(8480), "Placeat fuga commodi quis dolor molestiae consequatur ducimus perspiciatis quasi." },
                    { 6, 39, new DateTime(2024, 11, 28, 16, 59, 25, 787, DateTimeKind.Local).AddTicks(2803), "Dolorum quas eius labore magnam." },
                    { 7, 15, new DateTime(2024, 11, 28, 19, 56, 30, 268, DateTimeKind.Local).AddTicks(6237), "Nemo numquam dolor quidem. Excepturi culpa fugit maiores ipsam culpa. Nulla accusantium aut. Voluptate est at eligendi voluptas et id et. Repellat consequatur tempora rerum accusamus consequuntur." },
                    { 8, 78, new DateTime(2024, 11, 29, 14, 12, 58, 253, DateTimeKind.Local).AddTicks(379), "enim" },
                    { 9, 1, new DateTime(2024, 11, 28, 20, 59, 56, 461, DateTimeKind.Local).AddTicks(5792), "Aut ex qui." },
                    { 10, 16, new DateTime(2024, 11, 29, 15, 5, 7, 481, DateTimeKind.Local).AddTicks(8461), "vel" },
                    { 11, 44, new DateTime(2024, 11, 28, 16, 0, 40, 416, DateTimeKind.Local).AddTicks(197), "Enim rem doloribus inventore voluptatem laboriosam exercitationem consequatur. Quis laboriosam fuga pariatur adipisci dolor ad culpa. Quis aut in laboriosam sapiente aperiam iste non aut. Officiis voluptas quibusdam est. Debitis iusto eaque aut rem natus." },
                    { 12, 10, new DateTime(2024, 11, 28, 22, 28, 20, 929, DateTimeKind.Local).AddTicks(1795), "Optio reiciendis eum facilis.\nEt tempora pariatur consectetur accusamus exercitationem harum eligendi id.\nMagnam eius molestiae doloremque ut fugiat.\nA temporibus vel eaque molestiae autem dolores." },
                    { 13, 61, new DateTime(2024, 11, 28, 20, 43, 40, 537, DateTimeKind.Local).AddTicks(4371), "Repellendus culpa cumque rem autem in dolores libero vel. Aut aspernatur nesciunt sit dicta consequuntur eos suscipit eius sint. Sed est deserunt dignissimos et. Autem vel quo qui explicabo. Harum numquam ut rerum et. Molestiae accusantium temporibus molestiae optio doloremque alias error omnis." },
                    { 14, 69, new DateTime(2024, 11, 28, 22, 36, 25, 515, DateTimeKind.Local).AddTicks(1783), "Eos ullam ratione numquam vero. Architecto et quia dolorem debitis. Perspiciatis est quas asperiores excepturi. Qui maxime facere quis nesciunt. Facilis at soluta nobis atque eos nulla ducimus tempora rem. Minus sequi praesentium quis itaque asperiores ut ex." },
                    { 15, 59, new DateTime(2024, 11, 28, 19, 14, 14, 688, DateTimeKind.Local).AddTicks(9013), "Non voluptas alias ut est voluptate vel sed.\nEst vitae atque voluptatibus.\nAut nihil ad consequatur natus dolore ex.\nNisi eos reprehenderit veritatis.\nQuo et praesentium aut ut qui enim nihil." },
                    { 16, 51, new DateTime(2024, 11, 28, 18, 11, 10, 71, DateTimeKind.Local).AddTicks(7608), "Maxime magnam rerum saepe." },
                    { 17, 45, new DateTime(2024, 11, 29, 13, 8, 43, 46, DateTimeKind.Local).AddTicks(835), "Quia in eos est et rem nulla.\nNihil nihil et quo voluptatum et sapiente et praesentium dolorem.\nVoluptatem et nihil et corrupti autem eveniet enim soluta.\nEt vitae exercitationem." },
                    { 18, 96, new DateTime(2024, 11, 29, 1, 14, 12, 380, DateTimeKind.Local).AddTicks(6262), "Est dolorem voluptates aut aspernatur et vel omnis.\nVoluptatem ex ipsam autem est." },
                    { 19, 30, new DateTime(2024, 11, 29, 6, 51, 32, 182, DateTimeKind.Local).AddTicks(1047), "Quia ea commodi et atque ex qui est voluptas quibusdam.\nTempora est nihil nesciunt sint quia quis quaerat occaecati excepturi.\nSit nam expedita adipisci et accusamus vero necessitatibus placeat enim.\nDolores numquam rerum consectetur quia veniam." },
                    { 20, 55, new DateTime(2024, 11, 29, 0, 24, 47, 934, DateTimeKind.Local).AddTicks(5658), "earum" },
                    { 21, 28, new DateTime(2024, 11, 28, 18, 35, 33, 438, DateTimeKind.Local).AddTicks(9954), "Dolores et fugit rem voluptas et sapiente laborum dolor." },
                    { 22, 33, new DateTime(2024, 11, 29, 0, 47, 28, 620, DateTimeKind.Local).AddTicks(5581), "Suscipit quis repudiandae vitae sed saepe accusamus reiciendis ut." },
                    { 23, 47, new DateTime(2024, 11, 29, 13, 27, 52, 649, DateTimeKind.Local).AddTicks(2398), "A quis architecto libero corporis reprehenderit et sint perferendis.\nEnim quo laudantium est voluptates dolorum." },
                    { 24, 30, new DateTime(2024, 11, 28, 21, 27, 26, 82, DateTimeKind.Local).AddTicks(7181), "corrupti" },
                    { 25, 55, new DateTime(2024, 11, 28, 23, 32, 16, 438, DateTimeKind.Local).AddTicks(36), "Enim animi fuga quos.\nEt harum hic minima.\nIllum dolore in placeat et enim corporis.\nRem fuga quae aut pariatur minima tenetur nostrum.\nLabore alias voluptas alias ipsum quaerat reprehenderit tenetur tenetur.\nNihil ut accusantium nostrum ex libero exercitationem id dolore sed." }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CompanyId", "Date", "Notes", "UserId" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2024, 11, 28, 23, 45, 20, 526, DateTimeKind.Local).AddTicks(62), "Asperiores aliquid eum ut consequuntur minima.", 122 },
                    { 2, 55, new DateTime(2024, 11, 29, 5, 59, 24, 746, DateTimeKind.Local).AddTicks(2755), "cupiditate", 16 },
                    { 3, 69, new DateTime(2024, 11, 29, 5, 25, 40, 986, DateTimeKind.Local).AddTicks(1253), "Quo sint qui laborum tenetur nam vero.\nSed praesentium dolor.\nNatus qui voluptate cupiditate sequi repellendus laboriosam eum.\nNesciunt fugiat officia libero sint.\nVoluptatum impedit quam voluptatum laborum.\nCupiditate aliquam repellat perspiciatis deleniti harum non.", 50 },
                    { 4, 55, new DateTime(2024, 11, 28, 22, 38, 58, 757, DateTimeKind.Local).AddTicks(8775), "Repellendus animi voluptatem quo aut error doloremque sunt reiciendis.\nInventore quo mollitia sed autem.\nCum et at provident consequatur sapiente.", 200 },
                    { 5, 71, new DateTime(2024, 11, 29, 9, 6, 44, 314, DateTimeKind.Local).AddTicks(7219), "Est quia ut consequatur id quo laboriosam esse laudantium.", 144 },
                    { 6, 66, new DateTime(2024, 11, 28, 15, 32, 45, 471, DateTimeKind.Local).AddTicks(1069), "iure", 130 },
                    { 7, 80, new DateTime(2024, 11, 29, 14, 24, 24, 1, DateTimeKind.Local).AddTicks(6957), "Voluptatem sint velit sequi deserunt accusantium.\nExpedita odio impedit ut et dolores et ex quasi consectetur.", 130 },
                    { 8, 66, new DateTime(2024, 11, 28, 15, 33, 41, 872, DateTimeKind.Local).AddTicks(3306), "Quia est corrupti quas. Soluta sit sed inventore. Voluptas est repudiandae aspernatur aut voluptatibus enim debitis sunt consequatur. Voluptatibus error possimus nihil consequuntur hic quia autem maxime ut.", 47 },
                    { 9, 93, new DateTime(2024, 11, 29, 0, 29, 50, 302, DateTimeKind.Local).AddTicks(501), "Aperiam atque officiis voluptas voluptas voluptatem similique quo illo veritatis.", 151 },
                    { 10, 4, new DateTime(2024, 11, 29, 13, 23, 2, 777, DateTimeKind.Local).AddTicks(6334), "Autem adipisci dolorem et aut quidem repellat et dicta quibusdam. Ut dolorem quia sit. Ea impedit ducimus dolore ea veritatis voluptatem et molestiae. Est esse adipisci exercitationem error quis nam dolor.", 149 },
                    { 11, 68, new DateTime(2024, 11, 28, 15, 33, 9, 539, DateTimeKind.Local).AddTicks(944), "eligendi", 143 },
                    { 12, 18, new DateTime(2024, 11, 29, 3, 58, 45, 722, DateTimeKind.Local).AddTicks(3957), "Soluta sit totam.", 172 },
                    { 13, 46, new DateTime(2024, 11, 29, 3, 17, 37, 314, DateTimeKind.Local).AddTicks(4310), "Quia minus quaerat aut.\nPlaceat itaque tenetur.\nRecusandae aut incidunt.\nAut aspernatur molestiae dicta.", 10 },
                    { 14, 26, new DateTime(2024, 11, 29, 10, 42, 16, 719, DateTimeKind.Local).AddTicks(1260), "Omnis id dolore ipsam commodi dignissimos libero et et ducimus. Neque ducimus debitis qui quasi qui aperiam quibusdam exercitationem. Temporibus sed sapiente earum quo tenetur a. Corporis mollitia exercitationem rerum omnis. Est consequatur temporibus dolor accusantium odit eos nam deleniti maxime. Nemo est maxime odit.", 151 },
                    { 15, 71, new DateTime(2024, 11, 29, 6, 26, 31, 339, DateTimeKind.Local).AddTicks(4913), "Similique voluptates placeat eveniet quos facere.", 35 },
                    { 16, 63, new DateTime(2024, 11, 28, 17, 51, 51, 959, DateTimeKind.Local).AddTicks(4892), "Ab mollitia eos reiciendis.\nConsequatur qui quo.\nQui consequuntur tenetur.\nSimilique consequatur quos eligendi praesentium odio corrupti aspernatur nostrum neque.\nNon molestiae similique rerum vel doloribus.", 49 },
                    { 17, 50, new DateTime(2024, 11, 28, 22, 29, 56, 305, DateTimeKind.Local).AddTicks(3536), "omnis", 35 },
                    { 18, 66, new DateTime(2024, 11, 29, 5, 19, 31, 675, DateTimeKind.Local).AddTicks(1721), "Et quia vero ipsa qui illum deleniti ut.", 229 },
                    { 19, 22, new DateTime(2024, 11, 29, 6, 32, 18, 985, DateTimeKind.Local).AddTicks(7204), "Voluptatem dolor error commodi eaque expedita.\nAssumenda qui consequuntur consequuntur necessitatibus rem velit blanditiis.\nBeatae necessitatibus est.\nQuae veritatis voluptate iste explicabo dolor.\nId tempore aut aut voluptate qui voluptatem quaerat minima.", 151 },
                    { 20, 60, new DateTime(2024, 11, 29, 5, 9, 48, 504, DateTimeKind.Local).AddTicks(8116), "dolorem", 174 },
                    { 21, 14, new DateTime(2024, 11, 28, 18, 34, 9, 772, DateTimeKind.Local).AddTicks(6393), "Sint temporibus et quod.", 229 },
                    { 22, 46, new DateTime(2024, 11, 29, 13, 19, 9, 221, DateTimeKind.Local).AddTicks(9157), "Aut quibusdam totam animi itaque nulla dolor eaque laborum nihil.\nNesciunt quaerat esse eos et amet quam et.\nIpsa cupiditate itaque rem libero est.\nNam impedit reprehenderit quo quasi.", 147 },
                    { 23, 40, new DateTime(2024, 11, 29, 10, 30, 31, 292, DateTimeKind.Local).AddTicks(9331), "Omnis quasi nostrum voluptate nemo et ad consequatur. Quam ut et deserunt debitis quia aut dignissimos libero blanditiis. Et voluptatem nobis incidunt sit velit enim deserunt. Voluptatem accusamus est autem rerum et rerum provident exercitationem. Quidem at tenetur suscipit provident. Ratione atque facilis sequi nihil sit.", 67 },
                    { 24, 71, new DateTime(2024, 11, 29, 4, 13, 14, 155, DateTimeKind.Local).AddTicks(5963), "Soluta et voluptas sed deserunt quo sed.", 67 },
                    { 25, 84, new DateTime(2024, 11, 28, 21, 22, 9, 254, DateTimeKind.Local).AddTicks(7638), "voluptatibus", 221 },
                    { 26, 92, new DateTime(2024, 11, 29, 8, 19, 4, 474, DateTimeKind.Local).AddTicks(8473), "iure", 47 },
                    { 27, 70, new DateTime(2024, 11, 29, 8, 51, 14, 189, DateTimeKind.Local).AddTicks(5587), "Unde molestiae voluptas.", 252 },
                    { 28, 49, new DateTime(2024, 11, 28, 22, 48, 24, 392, DateTimeKind.Local).AddTicks(3842), "Accusamus quasi suscipit similique vel illo iste fuga.\nDoloribus voluptas quidem aliquam et quia laboriosam quaerat unde.\nAsperiores a sed fuga ducimus natus.\nVel quod rerum.", 16 },
                    { 29, 79, new DateTime(2024, 11, 28, 17, 45, 48, 432, DateTimeKind.Local).AddTicks(7833), "dolor", 240 },
                    { 30, 33, new DateTime(2024, 11, 29, 8, 39, 39, 602, DateTimeKind.Local).AddTicks(3206), "Assumenda ut ad quia laborum rerum dolorum. Nihil quis quo corporis. Inventore consequatur incidunt pariatur neque. Rerum dolore ut quasi hic cum harum eius praesentium.", 81 },
                    { 31, 45, new DateTime(2024, 11, 29, 7, 54, 36, 716, DateTimeKind.Local).AddTicks(7090), "Rerum sit nulla sequi reprehenderit mollitia eligendi totam.\nEveniet numquam eos excepturi.\nEt voluptatem nam.", 67 },
                    { 32, 74, new DateTime(2024, 11, 29, 1, 25, 14, 161, DateTimeKind.Local).AddTicks(6561), "Magnam delectus modi consequatur sunt quo aut reprehenderit voluptates. Soluta molestiae voluptate porro exercitationem eligendi ea illo. Doloribus rerum nihil rerum est tempora quibusdam. Minima officia quidem necessitatibus neque minima sequi.", 144 },
                    { 33, 33, new DateTime(2024, 11, 28, 16, 15, 20, 345, DateTimeKind.Local).AddTicks(7216), "Esse perferendis soluta beatae sit.", 197 },
                    { 34, 53, new DateTime(2024, 11, 29, 12, 16, 30, 272, DateTimeKind.Local).AddTicks(6624), "sit", 241 },
                    { 35, 17, new DateTime(2024, 11, 29, 1, 3, 20, 272, DateTimeKind.Local).AddTicks(9704), "Magni quos eum hic facere voluptatum. Eveniet culpa sed. Esse earum fugiat et ullam porro molestiae tempora rerum sapiente.", 151 },
                    { 36, 82, new DateTime(2024, 11, 28, 17, 6, 29, 74, DateTimeKind.Local).AddTicks(131), "Iusto aut laboriosam eum quibusdam aut ratione nesciunt.\nCorporis doloribus iusto et distinctio nostrum.", 62 },
                    { 37, 15, new DateTime(2024, 11, 29, 12, 40, 0, 645, DateTimeKind.Local).AddTicks(7610), "ex", 89 },
                    { 38, 66, new DateTime(2024, 11, 29, 6, 46, 7, 336, DateTimeKind.Local).AddTicks(8326), "occaecati", 88 },
                    { 39, 3, new DateTime(2024, 11, 28, 22, 31, 47, 434, DateTimeKind.Local).AddTicks(7883), "quidem", 14 },
                    { 40, 16, new DateTime(2024, 11, 28, 15, 21, 47, 340, DateTimeKind.Local).AddTicks(9296), "Ut aut distinctio dolores voluptatem modi.\nTenetur debitis explicabo fugiat tenetur blanditiis.\nOccaecati eum ipsa.\nPerferendis neque nobis laborum nihil asperiores ut maxime voluptate debitis.", 197 },
                    { 41, 34, new DateTime(2024, 11, 29, 1, 25, 59, 203, DateTimeKind.Local).AddTicks(3771), "Velit et voluptatum placeat qui veniam vel fugiat enim modi. Impedit praesentium rem ad sed deleniti mollitia error. Excepturi assumenda vero est. Et incidunt quasi est quis enim nihil laboriosam asperiores sint. Qui blanditiis aperiam in voluptates impedit omnis soluta accusamus voluptatum. Molestiae consequatur ullam dolorum totam.", 130 },
                    { 42, 43, new DateTime(2024, 11, 29, 0, 27, 50, 170, DateTimeKind.Local).AddTicks(6428), "Quia odit fugiat et error enim rerum sunt dolor perferendis.\nIusto voluptatem qui qui.\nSaepe aliquid dolorem non occaecati unde quos voluptatum voluptatem sit.\nQuo et ut ut.\nEt dolore et amet id nulla.", 122 },
                    { 43, 6, new DateTime(2024, 11, 28, 19, 10, 14, 208, DateTimeKind.Local).AddTicks(9462), "Reprehenderit omnis nam qui harum in consequatur eaque.", 240 },
                    { 44, 70, new DateTime(2024, 11, 28, 15, 7, 46, 313, DateTimeKind.Local).AddTicks(6756), "Eum voluptates atque quis harum eos voluptatem esse. Molestiae velit nisi saepe ad ea est. Eius quas aut repellendus omnis. Sunt nulla animi nulla. Ut quidem voluptatem porro delectus voluptatem quasi.", 67 },
                    { 45, 68, new DateTime(2024, 11, 28, 19, 8, 15, 948, DateTimeKind.Local).AddTicks(1246), "In nam enim molestiae assumenda sit sit nemo molestias quas. Adipisci ipsa ratione dignissimos saepe et suscipit. Dolores velit ea dolore maiores et quis. Est quis modi architecto illum vel. Excepturi ipsam magnam ut.", 98 },
                    { 46, 80, new DateTime(2024, 11, 28, 22, 30, 38, 87, DateTimeKind.Local).AddTicks(8351), "Rem non qui.\nSunt similique repudiandae dolor sapiente corporis perferendis maxime enim.", 125 },
                    { 47, 27, new DateTime(2024, 11, 29, 8, 48, 48, 387, DateTimeKind.Local).AddTicks(9706), "Fuga nihil nemo et voluptas aut amet excepturi excepturi.", 218 },
                    { 48, 44, new DateTime(2024, 11, 28, 20, 18, 49, 176, DateTimeKind.Local).AddTicks(3165), "Sint minima iusto et quo odio placeat voluptates nostrum porro.\nNam quas facilis dolor pariatur aut.\nQuas et nesciunt nisi nobis non tempore delectus voluptatem.\nVelit cum aspernatur.", 197 },
                    { 49, 89, new DateTime(2024, 11, 29, 5, 36, 47, 635, DateTimeKind.Local).AddTicks(8910), "aspernatur", 127 },
                    { 50, 39, new DateTime(2024, 11, 29, 11, 5, 49, 622, DateTimeKind.Local).AddTicks(4763), "Debitis id eos numquam laboriosam vitae.", 150 },
                    { 51, 27, new DateTime(2024, 11, 28, 21, 25, 23, 346, DateTimeKind.Local).AddTicks(3484), "Quidem at perspiciatis libero quia eum.\nError voluptates qui recusandae ea sunt eos.", 127 },
                    { 52, 26, new DateTime(2024, 11, 28, 23, 54, 27, 129, DateTimeKind.Local).AddTicks(2277), "Rerum amet dolore voluptates voluptas molestiae magnam voluptas eum.\nMagni tenetur eaque sit aut autem et.\nQuisquam ea distinctio voluptatum.\nAtque iure et itaque cupiditate quo dolorum enim ut.\nId alias officiis quia deserunt.\nEos aut explicabo laborum dolores.", 150 },
                    { 53, 45, new DateTime(2024, 11, 28, 23, 25, 17, 726, DateTimeKind.Local).AddTicks(5926), "Magni cumque beatae reiciendis animi id.", 98 },
                    { 54, 63, new DateTime(2024, 11, 29, 7, 48, 45, 72, DateTimeKind.Local).AddTicks(9233), "in", 176 },
                    { 55, 52, new DateTime(2024, 11, 29, 10, 45, 0, 471, DateTimeKind.Local).AddTicks(5426), "voluptate", 47 },
                    { 56, 32, new DateTime(2024, 11, 28, 22, 52, 12, 749, DateTimeKind.Local).AddTicks(1802), "qui", 252 },
                    { 57, 45, new DateTime(2024, 11, 28, 21, 47, 51, 550, DateTimeKind.Local).AddTicks(7911), "Ut iste repudiandae qui quia perferendis rem quisquam fugiat reiciendis.\nLaudantium consequatur iure vero expedita ipsa voluptatem quo.", 149 },
                    { 58, 23, new DateTime(2024, 11, 28, 23, 54, 22, 224, DateTimeKind.Local).AddTicks(6582), "nulla", 127 },
                    { 59, 86, new DateTime(2024, 11, 28, 15, 11, 22, 777, DateTimeKind.Local).AddTicks(5639), "Quam omnis dolores consequuntur dolor repellat inventore doloribus asperiores qui. Doloribus tempore voluptas ullam est est impedit in. Qui consequatur nihil aspernatur ipsam qui doloribus officia animi. Velit est nostrum voluptas rerum nisi et voluptatem. Est tempora assumenda quaerat aut eligendi.", 143 },
                    { 60, 100, new DateTime(2024, 11, 28, 15, 8, 20, 811, DateTimeKind.Local).AddTicks(128), "et", 171 },
                    { 61, 37, new DateTime(2024, 11, 29, 11, 12, 5, 818, DateTimeKind.Local).AddTicks(6923), "Quidem facere quaerat dolor. Numquam cum rerum voluptas neque eos harum voluptas aut. Non praesentium labore est facilis ipsam alias quam. Eos dolore tempore. Sit quia corrupti ipsa aspernatur. Animi omnis quos odit ut laborum sequi dolor repudiandae fugit.", 50 },
                    { 62, 98, new DateTime(2024, 11, 29, 10, 49, 58, 817, DateTimeKind.Local).AddTicks(5112), "Non atque odit est doloremque animi.\nVoluptatem nisi repudiandae ipsam repellat vel ea provident adipisci saepe.\nExercitationem facilis libero dolorem asperiores.\nEos qui suscipit sit quidem mollitia.\nFugit saepe quas quos qui.", 50 },
                    { 63, 76, new DateTime(2024, 11, 29, 7, 26, 1, 104, DateTimeKind.Local).AddTicks(204), "Modi ipsum aut ex.\nReprehenderit asperiores recusandae.\nAut voluptas molestiae est accusamus nihil tempore ratione sit consequatur.\nNecessitatibus error eos quia perferendis.\nMinima sed est quisquam.", 81 },
                    { 64, 94, new DateTime(2024, 11, 29, 13, 41, 9, 957, DateTimeKind.Local).AddTicks(9656), "Et temporibus consequatur.\nQuia voluptatibus et ab consectetur ab assumenda molestias ex.\nEt illo fugit voluptas perspiciatis quod tempore non neque ut.\nUllam qui qui modi deserunt.\nExcepturi quidem voluptates ut vero explicabo in sit.", 221 },
                    { 65, 54, new DateTime(2024, 11, 29, 3, 16, 28, 673, DateTimeKind.Local).AddTicks(7141), "Nam dolores et quidem reiciendis est cum hic nihil reprehenderit. Harum asperiores impedit non quia dolorum qui. Est iste consequatur occaecati. Vero qui vero eum eligendi aut quas. Ut qui quae autem omnis. Tempora odit magni ab ipsa nobis.", 209 },
                    { 66, 3, new DateTime(2024, 11, 29, 3, 43, 28, 285, DateTimeKind.Local).AddTicks(7963), "Dolorem nesciunt voluptatem nisi nostrum qui quo aut blanditiis.", 50 },
                    { 67, 71, new DateTime(2024, 11, 29, 14, 21, 43, 856, DateTimeKind.Local).AddTicks(7451), "Accusantium veritatis dolores necessitatibus molestiae. Impedit laborum voluptatem et quis repudiandae. Explicabo fugiat et sint quod. Aspernatur dolor inventore sapiente qui tenetur.", 147 },
                    { 68, 98, new DateTime(2024, 11, 28, 16, 32, 21, 888, DateTimeKind.Local).AddTicks(2885), "Dignissimos neque et commodi.", 14 },
                    { 69, 20, new DateTime(2024, 11, 29, 3, 17, 31, 441, DateTimeKind.Local).AddTicks(6662), "Minus quaerat iure. Reprehenderit placeat quam ipsam. Temporibus eligendi necessitatibus quod temporibus excepturi. Dolorem rerum voluptatibus excepturi natus voluptatem voluptates quasi recusandae ipsum. Similique quam beatae qui doloribus voluptate culpa ratione velit. Adipisci voluptatum vero qui et aliquam ut ducimus nemo quia.", 70 },
                    { 70, 68, new DateTime(2024, 11, 29, 11, 53, 45, 736, DateTimeKind.Local).AddTicks(9887), "Quae et deleniti sit nam.\nFacere excepturi ea aut.\nTempora omnis ex sed sed tempore ut nobis beatae doloribus.\nVeniam praesentium ut laudantium voluptate omnis magnam.", 35 },
                    { 71, 38, new DateTime(2024, 11, 29, 11, 21, 25, 70, DateTimeKind.Local).AddTicks(951), "Velit voluptatibus ut eum debitis maxime repellendus voluptatem dolorum.\nEum magni explicabo.", 197 },
                    { 72, 2, new DateTime(2024, 11, 29, 4, 11, 28, 553, DateTimeKind.Local).AddTicks(3894), "A accusantium sed.", 70 },
                    { 73, 4, new DateTime(2024, 11, 29, 0, 16, 6, 467, DateTimeKind.Local).AddTicks(3915), "Illo distinctio quia itaque fugiat asperiores deserunt ducimus.", 125 },
                    { 74, 81, new DateTime(2024, 11, 29, 5, 11, 8, 164, DateTimeKind.Local).AddTicks(7066), "Molestiae quo similique eligendi. Et voluptatum animi iste rerum. Voluptatem a autem fugiat maxime corrupti et est nihil velit. Officia dolores illo impedit molestiae.", 32 },
                    { 75, 8, new DateTime(2024, 11, 29, 4, 56, 39, 92, DateTimeKind.Local).AddTicks(8955), "aut", 226 }
                });

            migrationBuilder.InsertData(
                table: "QuoteProducts",
                columns: new[] { "Id", "ProductId", "Quantity", "QuoteId" },
                values: new object[,]
                {
                    { 1, 9, 604, 8 },
                    { 2, 12, 481, 32 },
                    { 3, 44, 785, 15 },
                    { 4, 5, 568, 9 },
                    { 5, 18, 671, 35 },
                    { 6, 24, 543, 28 },
                    { 7, 5, 464, 25 },
                    { 8, 44, 358, 38 },
                    { 9, 38, 850, 50 },
                    { 10, 44, 893, 9 },
                    { 11, 10, 57, 37 },
                    { 12, 42, 464, 34 },
                    { 13, 28, 188, 32 },
                    { 14, 9, 756, 25 },
                    { 15, 1, 86, 2 },
                    { 16, 16, 661, 47 },
                    { 17, 45, 632, 47 },
                    { 18, 48, 608, 28 },
                    { 19, 36, 129, 44 },
                    { 20, 26, 938, 16 },
                    { 21, 2, 851, 25 },
                    { 22, 13, 115, 33 },
                    { 23, 32, 668, 29 },
                    { 24, 16, 486, 35 },
                    { 25, 11, 964, 47 },
                    { 26, 23, 843, 7 },
                    { 27, 24, 783, 12 },
                    { 28, 22, 513, 25 },
                    { 29, 6, 390, 40 },
                    { 30, 25, 908, 1 },
                    { 31, 50, 22, 39 },
                    { 32, 29, 812, 50 },
                    { 33, 31, 186, 48 },
                    { 34, 43, 576, 7 },
                    { 35, 36, 51, 4 },
                    { 36, 29, 524, 28 },
                    { 37, 13, 983, 48 },
                    { 38, 36, 66, 39 },
                    { 39, 48, 282, 4 },
                    { 40, 50, 591, 45 },
                    { 41, 47, 735, 25 },
                    { 42, 41, 643, 38 },
                    { 43, 7, 166, 8 },
                    { 44, 10, 620, 24 },
                    { 45, 24, 447, 21 },
                    { 46, 13, 740, 21 },
                    { 47, 18, 512, 40 },
                    { 48, 14, 137, 10 },
                    { 49, 17, 863, 32 },
                    { 50, 19, 205, 32 },
                    { 51, 34, 361, 13 },
                    { 52, 16, 196, 12 },
                    { 53, 34, 192, 18 },
                    { 54, 34, 800, 18 },
                    { 55, 44, 380, 37 },
                    { 56, 5, 964, 37 },
                    { 57, 27, 70, 35 },
                    { 58, 2, 79, 44 },
                    { 59, 14, 27, 36 },
                    { 60, 47, 774, 12 },
                    { 61, 37, 263, 4 },
                    { 62, 7, 541, 12 },
                    { 63, 39, 368, 20 },
                    { 64, 29, 187, 15 },
                    { 65, 7, 247, 13 },
                    { 66, 15, 122, 26 },
                    { 67, 45, 589, 44 },
                    { 68, 6, 140, 11 },
                    { 69, 24, 954, 13 },
                    { 70, 24, 791, 4 },
                    { 71, 38, 990, 23 },
                    { 72, 26, 626, 35 },
                    { 73, 13, 725, 50 },
                    { 74, 7, 244, 15 },
                    { 75, 6, 259, 22 },
                    { 76, 45, 787, 11 },
                    { 77, 13, 998, 33 },
                    { 78, 33, 876, 29 },
                    { 79, 15, 208, 2 },
                    { 80, 12, 2, 13 },
                    { 81, 38, 144, 19 },
                    { 82, 33, 642, 49 },
                    { 83, 50, 962, 1 },
                    { 84, 15, 604, 12 },
                    { 85, 14, 297, 36 },
                    { 86, 31, 652, 32 },
                    { 87, 17, 140, 11 },
                    { 88, 20, 735, 12 },
                    { 89, 44, 523, 10 },
                    { 90, 23, 596, 14 },
                    { 91, 30, 229, 49 },
                    { 92, 50, 106, 14 },
                    { 93, 10, 722, 27 },
                    { 94, 15, 815, 28 },
                    { 95, 40, 892, 29 },
                    { 96, 23, 223, 39 },
                    { 97, 41, 20, 25 },
                    { 98, 36, 105, 19 },
                    { 99, 41, 70, 33 },
                    { 100, 13, 199, 12 }
                });

            migrationBuilder.InsertData(
                table: "CustomInvoiceProducts",
                columns: new[] { "Id", "Amount", "CustomInvoiceId", "PricePerProduct", "ProductId" },
                values: new object[,]
                {
                    { 1, 302, 18, 8580.0292678822520899m, 49 },
                    { 2, 634, 44, 4119.45771757490297326m, 47 },
                    { 3, 709, 38, 1708.4728880396034958m, 43 },
                    { 4, 745, 20, 8779.24185512734563202m, 25 },
                    { 5, 770, 12, 3466.30488931741438423m, 2 },
                    { 6, 171, 16, 1691.96768059571744491m, 32 },
                    { 7, 717, 30, 4779.87944529665482912m, 12 },
                    { 8, 927, 27, 4549.80311466400553833m, 44 },
                    { 9, 145, 19, 77.2257268014170827789m, 17 },
                    { 10, 195, 11, 520.702358347882959238m, 3 },
                    { 11, 284, 33, 7104.56233452977091079m, 36 },
                    { 12, 335, 37, 531.847979366250795238m, 25 },
                    { 13, 533, 14, 5720.5042537036257964m, 37 },
                    { 14, 5, 40, 5493.84685586376029389m, 25 },
                    { 15, 455, 33, 9517.16617552383731047m, 46 },
                    { 16, 123, 38, 4234.42336833795724444m, 26 },
                    { 17, 786, 28, 3745.87257289280124088m, 26 },
                    { 18, 165, 43, 2781.27474981478891768m, 35 },
                    { 19, 465, 37, 2297.32639744235523895m, 30 },
                    { 20, 36, 50, 1319.29719335599735549m, 16 },
                    { 21, 536, 10, 4732.15098303500481928m, 36 },
                    { 22, 708, 14, 9475.4039054621191345m, 30 },
                    { 23, 203, 50, 295.856679704138448886m, 34 },
                    { 24, 310, 8, 2011.10437329257561104m, 6 },
                    { 25, 479, 38, 2323.92784421615186368m, 25 },
                    { 26, 929, 41, 7104.40224009791550274m, 17 },
                    { 27, 86, 13, 5894.1600067488990952m, 43 },
                    { 28, 591, 13, 5380.54764841894103803m, 2 },
                    { 29, 388, 23, 766.931649490352587231m, 39 },
                    { 30, 521, 25, 9876.51916821770526325m, 31 },
                    { 31, 517, 49, 4612.76934149902573702m, 11 },
                    { 32, 153, 33, 307.058787527187423718m, 49 },
                    { 33, 5, 20, 2170.5952686999607126m, 31 },
                    { 34, 586, 41, 8916.89275682594628238m, 16 },
                    { 35, 722, 41, 2742.79266435237286222m, 19 },
                    { 36, 625, 18, 1442.13287305531482037m, 17 },
                    { 37, 950, 43, 8857.86447190582023085m, 6 },
                    { 38, 184, 7, 8103.5678425963538377m, 25 },
                    { 39, 297, 12, 8521.28310985623886213m, 26 },
                    { 40, 141, 12, 6592.10414133097656829m, 15 },
                    { 41, 904, 45, 5803.7640473034489367m, 30 },
                    { 42, 285, 28, 2269.58268841701200803m, 28 },
                    { 43, 223, 12, 2560.98629158817743297m, 1 },
                    { 44, 954, 30, 6398.78178840434281747m, 21 },
                    { 45, 586, 19, 948.541601077262390188m, 26 },
                    { 46, 115, 25, 498.670036109521229944m, 23 },
                    { 47, 834, 14, 7197.99427189199011654m, 11 },
                    { 48, 470, 46, 1484.3017097691059377m, 20 },
                    { 49, 429, 37, 8405.58252548107893799m, 11 },
                    { 50, 142, 45, 8808.28468094819076832m, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                table: "Companies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CompanyId",
                table: "Contracts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomInvoiceProducts_CustomInvoiceId",
                table: "CustomInvoiceProducts",
                column: "CustomInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomInvoiceProducts_ProductId",
                table: "CustomInvoiceProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomInvoices_CompanyId",
                table: "CustomInvoices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseProducts_ExpenseId",
                table: "ExpenseProducts",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseProducts_ProductId",
                table: "ExpenseProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenaceAppointments_CompanyId",
                table: "MaintenaceAppointments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CompanyId",
                table: "Notes",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ExpenseId",
                table: "Products",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_QuoteId",
                table: "Products",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteProducts_ProductId",
                table: "QuoteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteProducts_QuoteId",
                table: "QuoteProducts",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_UserId",
                table: "Quotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "CustomInvoiceProducts");

            migrationBuilder.DropTable(
                name: "ExpenseProducts");

            migrationBuilder.DropTable(
                name: "MaintenaceAppointments");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "QuoteProducts");

            migrationBuilder.DropTable(
                name: "CustomInvoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
