using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Velar.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Realcat = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ParentId = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductsCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    MoneyAmount = table.Column<decimal>(type: "numeric(16,2)", nullable: false, defaultValue: 0m),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(16,2)", nullable: false),
                    MediumImage = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    VendorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    VendorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorCategories", x => new { x.CategoryId, x.VendorId });
                    table.ForeignKey(
                        name: "FK_VendorCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorCategories_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeliveryService = table.Column<int>(type: "integer", nullable: false),
                    DeliveryMethod = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Postal = table.Column<int>(type: "integer", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CartId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ItemPrice = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2c46ad5d-0dc2-4f46-9122-8e2e149b88b8", 0, "c32a5be4-1016-4742-a0fb-1c17e967dca4", "Adrien_Mante@gmail.com", false, "Libby", "Hauck", false, null, null, null, "_u6cto1BHX", "1-310-532-8555 x170", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "3672838f-e90f-4b73-a0b5-b4246e96850f", false, "Mustafa_Feest94" },
                    { "9331543c-c22b-4185-94c5-433f12e1633e", 0, "804142f3-3970-4650-9ee0-44015020a750", "Francisco_Mitchell@yahoo.com", false, "Shane", "Rodriguez", false, null, null, null, "1ESJKmDGQJ", "1-957-658-3177 x01336", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "3ece052f-2e52-4bdc-a0e4-00e4743d7f98", false, "Icie.Kunze8" },
                    { "7c681b33-6d16-41d0-aab8-1f824c5e29b5", 0, "e256147a-2319-4ebb-aa25-82dcf3eea236", "Lonzo_Bednar89@yahoo.com", false, "Theron", "O'Reilly", false, null, null, null, "qFagSitf3R", "1-883-985-5851", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "8a64e155-e12f-45f1-823e-510d0cd0a27e", false, "Theron76" },
                    { "681d07e1-3d85-47de-9a34-37db5d4f4bf6", 0, "a81d8d16-34ca-4dce-955e-78379965b81a", "Claude.Gislason24@yahoo.com", false, "Tanya", "Kilback", false, null, null, null, "G9XTFBAq9u", "517.974.4320", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "e31a4ea7-9ca4-4459-a8b9-5aabf5118331", false, "Randal.King94" },
                    { "315f0284-06bd-49fe-b92a-d7b56bfd30db", 0, "3f2f1813-6779-4098-94ad-adefbe539ff7", "Chelsey95@yahoo.com", false, "Annabelle", "Cummings", false, null, null, null, "qYkLwp5F8Z", "(929) 399-6717 x89231", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "7ae01cfa-c2b7-4ee2-9ca7-302ecd74679a", false, "Katherine_Pagac47" },
                    { "ce836d7f-1487-4927-910c-38c9846d39eb", 0, "9cbf802b-8904-4a47-a8c2-3a3fde74fb0a", "Alvina_Rowe@hotmail.com", false, "Myrtle", "Wolff", false, null, null, null, "4zoGDOp3nx", "865-878-1591", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "43836522-ce30-46be-a38d-406f83b7e719", false, "Matt80" },
                    { "e0f67c07-1ab9-4d3d-9b16-5d887e4598e2", 0, "67b2b679-5445-4a36-bde2-33616fedd547", "Micheal83@hotmail.com", false, "Kacey", "Wolf", false, null, null, null, "x2rVN_HIoF", "(604) 492-8328 x29367", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "e5b443e8-62ba-4507-9003-fdb93fdb66c3", false, "Pink65" },
                    { "c54e1825-075c-415e-8d58-b8bf9165dd1a", 0, "b4b66ec4-5931-4c51-b6b7-1aea78eb389c", "Stewart.Kautzer@yahoo.com", false, "Fanny", "Stehr", false, null, null, null, "_KCoxNbrHz", "568-995-4816", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "3e3c932b-36cc-45ed-adec-0cb4c78d49d4", false, "Philip10" },
                    { "30a0f8ea-964c-44ca-9691-2f73a28cadc6", 0, "efe66f06-9559-4d8a-9c49-83f827c7d119", "Abelardo27@yahoo.com", false, "Larissa", "Kris", false, null, null, null, "cwlZC_h0IR", "1-498-774-5511 x368", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "b9560830-ae9c-4e98-b8ec-a7a56a24c722", false, "Candido65" },
                    { "771759a5-0833-44e9-ae4d-c39039550797", 0, "7488001a-a727-420e-b069-0ef24cea0e05", "Elza60@yahoo.com", false, "Jana", "Boehm", false, null, null, null, "PoYHwkbUK4", "1-909-838-6369", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "954165bd-9a71-4a03-889c-2ac25e7490e5", false, "Iva42" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 21, "Health" },
                    { 22, "Clothing" },
                    { 1, "Industrial" },
                    { 25, "Music" },
                    { 20, "Grocery" },
                    { 24, "Tools" },
                    { 19, "Kids" },
                    { 23, "Beauty" },
                    { 17, "Grocery" },
                    { 2, "Automotive" },
                    { 3, "Health" },
                    { 4, "Music" },
                    { 18, "Baby" },
                    { 6, "Beauty" },
                    { 7, "Industrial" },
                    { 8, "Industrial" },
                    { 9, "Beauty" },
                    { 5, "Computers" },
                    { 11, "Health" },
                    { 12, "Shoes" },
                    { 13, "Grocery" },
                    { 14, "Garden" },
                    { 15, "Tools" },
                    { 16, "Jewelery" },
                    { 10, "Kids" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorId", "Name" },
                values: new object[,]
                {
                    { 8, "O'Conner - Medhurst" },
                    { 7, "Blanda, Price and Aufderhar" },
                    { 6, "Bednar and Sons" },
                    { 5, "Nicolas - Fadel" },
                    { 2, "Welch - Schneider" },
                    { 3, "Funk - Lueilwitz" },
                    { 1, "Wisozk LLC" },
                    { 9, "Osinski, Little and Bradtke" },
                    { 4, "Konopelski Group" },
                    { 10, "Funk, Hoeger and Botsford" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "MediumImage", "Name", "Price", "VendorId" },
                values: new object[,]
                {
                    { 17, 25, "https://localhost:5001/images/products/product-2.jpg", "Licensed Cotton Hat", 4014.86m, 1 },
                    { 82, 25, "https://localhost:5001/images/products/product-1.jpg", "Unbranded Frozen Sausages", 2599.98m, 8 },
                    { 75, 6, "https://localhost:5001/images/products/product-2.jpg", "Unbranded Rubber Bacon", 758.62m, 8 },
                    { 62, 17, "https://localhost:5001/images/products/product-4.jpg", "Awesome Steel Cheese", 2625.93m, 8 },
                    { 41, 20, "https://localhost:5001/images/products/product-5.jpg", "Licensed Wooden Gloves", 1800.74m, 8 },
                    { 36, 16, "https://localhost:5001/images/products/product-1.jpg", "Awesome Granite Computer", 406.27m, 8 },
                    { 96, 22, "https://localhost:5001/images/products/product-5.jpg", "Tasty Soft Shirt", 1416.34m, 7 },
                    { 83, 9, "https://localhost:5001/images/products/product-2.jpg", "Generic Fresh Table", 1473.34m, 7 },
                    { 63, 11, "https://localhost:5001/images/products/product-3.jpg", "Rustic Cotton Table", 1355.71m, 7 },
                    { 60, 3, "https://localhost:5001/images/products/product-3.jpg", "Practical Wooden Salad", 1348.26m, 7 },
                    { 57, 9, "https://localhost:5001/images/products/product-2.jpg", "Tasty Concrete Car", 2807.53m, 7 },
                    { 56, 14, "https://localhost:5001/images/products/product-4.jpg", "Ergonomic Frozen Salad", 2906.36m, 7 },
                    { 52, 14, "https://localhost:5001/images/products/product-3.jpg", "Incredible Concrete Tuna", 4277.74m, 7 },
                    { 42, 16, "https://localhost:5001/images/products/product-5.jpg", "Gorgeous Cotton Ball", 140.84m, 7 },
                    { 37, 3, "https://localhost:5001/images/products/product-1.jpg", "Awesome Steel Shirt", 1169.72m, 7 },
                    { 24, 5, "https://localhost:5001/images/products/product-5.jpg", "Handcrafted Rubber Ball", 4313.53m, 7 },
                    { 7, 4, "https://localhost:5001/images/products/product-4.jpg", "Intelligent Wooden Ball", 3667.62m, 7 },
                    { 90, 22, "https://localhost:5001/images/products/product-5.jpg", "Fantastic Frozen Ball", 2471.74m, 6 },
                    { 84, 25, "https://localhost:5001/images/products/product-2.jpg", "Sleek Metal Salad", 3077.88m, 6 },
                    { 64, 18, "https://localhost:5001/images/products/product-5.jpg", "Refined Soft Cheese", 3467.97m, 6 },
                    { 55, 1, "https://localhost:5001/images/products/product-1.jpg", "Fantastic Soft Shoes", 4850.22m, 6 },
                    { 45, 13, "https://localhost:5001/images/products/product-3.jpg", "Gorgeous Wooden Pizza", 4384.70m, 6 },
                    { 89, 12, "https://localhost:5001/images/products/product-4.jpg", "Rustic Concrete Ball", 2305.78m, 8 },
                    { 30, 11, "https://localhost:5001/images/products/product-3.jpg", "Fantastic Metal Bike", 4148.92m, 6 },
                    { 95, 19, "https://localhost:5001/images/products/product-5.jpg", "Gorgeous Metal Pizza", 65.37m, 8 },
                    { 2, 23, "https://localhost:5001/images/products/product-5.jpg", "Unbranded Granite Salad", 890.55m, 9 },
                    { 80, 13, "https://localhost:5001/images/products/product-5.jpg", "Unbranded Rubber Chips", 302.40m, 10 },
                    { 68, 25, "https://localhost:5001/images/products/product-4.jpg", "Licensed Cotton Chips", 79.69m, 10 },
                    { 61, 4, "https://localhost:5001/images/products/product-4.jpg", "Refined Rubber Chicken", 3984.23m, 10 },
                    { 59, 14, "https://localhost:5001/images/products/product-1.jpg", "Practical Steel Keyboard", 4133.31m, 10 },
                    { 49, 22, "https://localhost:5001/images/products/product-1.jpg", "Small Concrete Salad", 4654.24m, 10 },
                    { 44, 19, "https://localhost:5001/images/products/product-5.jpg", "Practical Wooden Keyboard", 2337.85m, 10 },
                    { 39, 18, "https://localhost:5001/images/products/product-4.jpg", "Incredible Steel Chair", 4742.57m, 10 },
                    { 31, 16, "https://localhost:5001/images/products/product-1.jpg", "Refined Rubber Sausages", 2461.01m, 10 },
                    { 88, 8, "https://localhost:5001/images/products/product-1.jpg", "Handmade Granite Cheese", 3080.94m, 9 },
                    { 85, 4, "https://localhost:5001/images/products/product-4.jpg", "Intelligent Rubber Sausages", 1186.91m, 9 },
                    { 71, 22, "https://localhost:5001/images/products/product-2.jpg", "Tasty Metal Chair", 620.92m, 9 },
                    { 66, 5, "https://localhost:5001/images/products/product-2.jpg", "Small Cotton Fish", 1186.98m, 9 },
                    { 65, 24, "https://localhost:5001/images/products/product-2.jpg", "Ergonomic Concrete Gloves", 3956.81m, 9 },
                    { 53, 6, "https://localhost:5001/images/products/product-3.jpg", "Handmade Soft Hat", 1260.62m, 9 },
                    { 51, 5, "https://localhost:5001/images/products/product-4.jpg", "Ergonomic Concrete Mouse", 2370.42m, 9 },
                    { 35, 24, "https://localhost:5001/images/products/product-2.jpg", "Tasty Concrete Soap", 192.93m, 9 },
                    { 21, 1, "https://localhost:5001/images/products/product-4.jpg", "Gorgeous Concrete Tuna", 1699.96m, 9 },
                    { 20, 12, "https://localhost:5001/images/products/product-2.jpg", "Intelligent Concrete Soap", 42.46m, 9 },
                    { 14, 9, "https://localhost:5001/images/products/product-2.jpg", "Generic Wooden Pizza", 1268.11m, 9 },
                    { 12, 12, "https://localhost:5001/images/products/product-5.jpg", "Unbranded Concrete Keyboard", 806.96m, 9 },
                    { 9, 18, "https://localhost:5001/images/products/product-4.jpg", "Rustic Steel Towels", 3423.06m, 9 },
                    { 1, 15, "https://localhost:5001/images/products/product-3.jpg", "Tasty Concrete Towels", 2254.79m, 9 },
                    { 29, 5, "https://localhost:5001/images/products/product-5.jpg", "Generic Cotton Shoes", 3726.31m, 6 },
                    { 28, 19, "https://localhost:5001/images/products/product-1.jpg", "Handcrafted Concrete Shoes", 2969.03m, 6 },
                    { 27, 16, "https://localhost:5001/images/products/product-4.jpg", "Handcrafted Metal Shoes", 2241.80m, 6 },
                    { 43, 10, "https://localhost:5001/images/products/product-5.jpg", "Intelligent Concrete Chips", 1345.63m, 3 },
                    { 34, 24, "https://localhost:5001/images/products/product-1.jpg", "Incredible Plastic Pizza", 2435.91m, 3 },
                    { 16, 9, "https://localhost:5001/images/products/product-4.jpg", "Practical Metal Chicken", 4069.54m, 3 },
                    { 13, 1, "https://localhost:5001/images/products/product-5.jpg", "Gorgeous Frozen Salad", 2350.03m, 3 },
                    { 11, 4, "https://localhost:5001/images/products/product-5.jpg", "Handmade Granite Pizza", 1729.91m, 3 },
                    { 100, 17, "https://localhost:5001/images/products/product-3.jpg", "Intelligent Cotton Table", 1250.43m, 2 },
                    { 94, 12, "https://localhost:5001/images/products/product-5.jpg", "Handcrafted Rubber Pizza", 1765.22m, 2 },
                    { 86, 11, "https://localhost:5001/images/products/product-1.jpg", "Ergonomic Fresh Pizza", 1614.14m, 2 },
                    { 77, 5, "https://localhost:5001/images/products/product-2.jpg", "Practical Soft Towels", 50.03m, 2 },
                    { 58, 14, "https://localhost:5001/images/products/product-5.jpg", "Generic Metal Computer", 2664.38m, 2 },
                    { 40, 16, "https://localhost:5001/images/products/product-1.jpg", "Generic Soft Gloves", 1877.30m, 2 },
                    { 23, 9, "https://localhost:5001/images/products/product-4.jpg", "Handcrafted Granite Table", 2680.90m, 2 },
                    { 6, 25, "https://localhost:5001/images/products/product-5.jpg", "Practical Metal Cheese", 2659.33m, 2 },
                    { 4, 24, "https://localhost:5001/images/products/product-5.jpg", "Practical Steel Hat", 4404.32m, 2 },
                    { 81, 19, "https://localhost:5001/images/products/product-4.jpg", "Incredible Fresh Computer", 4405.52m, 1 },
                    { 74, 9, "https://localhost:5001/images/products/product-4.jpg", "Sleek Rubber Towels", 4735.47m, 1 },
                    { 70, 23, "https://localhost:5001/images/products/product-4.jpg", "Refined Granite Fish", 2622.06m, 1 },
                    { 46, 18, "https://localhost:5001/images/products/product-2.jpg", "Refined Wooden Fish", 384.18m, 1 },
                    { 25, 6, "https://localhost:5001/images/products/product-3.jpg", "Intelligent Frozen Bacon", 4144.20m, 1 },
                    { 19, 10, "https://localhost:5001/images/products/product-4.jpg", "Gorgeous Steel Computer", 2629.75m, 1 },
                    { 18, 8, "https://localhost:5001/images/products/product-2.jpg", "Incredible Plastic Pants", 648.33m, 1 },
                    { 54, 3, "https://localhost:5001/images/products/product-5.jpg", "Unbranded Fresh Keyboard", 1660.50m, 3 },
                    { 73, 21, "https://localhost:5001/images/products/product-5.jpg", "Handmade Plastic Cheese", 2715.21m, 3 },
                    { 87, 20, "https://localhost:5001/images/products/product-5.jpg", "Sleek Concrete Chair", 1686.67m, 3 },
                    { 98, 16, "https://localhost:5001/images/products/product-5.jpg", "Licensed Metal Chair", 4986.54m, 3 },
                    { 26, 8, "https://localhost:5001/images/products/product-2.jpg", "Ergonomic Metal Cheese", 2991.53m, 6 },
                    { 10, 8, "https://localhost:5001/images/products/product-1.jpg", "Incredible Plastic Bike", 4152.15m, 6 },
                    { 8, 20, "https://localhost:5001/images/products/product-4.jpg", "Rustic Fresh Towels", 113.39m, 6 },
                    { 5, 20, "https://localhost:5001/images/products/product-1.jpg", "Small Wooden Towels", 4639.33m, 6 },
                    { 92, 8, "https://localhost:5001/images/products/product-1.jpg", "Sleek Fresh Ball", 2303.12m, 5 },
                    { 79, 20, "https://localhost:5001/images/products/product-3.jpg", "Ergonomic Granite Mouse", 2606.31m, 5 },
                    { 78, 22, "https://localhost:5001/images/products/product-1.jpg", "Intelligent Frozen Chips", 3590.17m, 5 },
                    { 76, 3, "https://localhost:5001/images/products/product-1.jpg", "Handmade Frozen Salad", 2154.83m, 5 },
                    { 69, 11, "https://localhost:5001/images/products/product-3.jpg", "Refined Frozen Computer", 3446.85m, 5 },
                    { 38, 3, "https://localhost:5001/images/products/product-5.jpg", "Incredible Steel Table", 391.01m, 5 },
                    { 91, 13, "https://localhost:5001/images/products/product-5.jpg", "Tasty Rubber Chips", 1152.49m, 10 },
                    { 33, 12, "https://localhost:5001/images/products/product-3.jpg", "Handmade Plastic Bike", 1979.67m, 5 },
                    { 22, 20, "https://localhost:5001/images/products/product-2.jpg", "Handmade Plastic Table", 331.91m, 5 },
                    { 15, 3, "https://localhost:5001/images/products/product-5.jpg", "Licensed Steel Salad", 2757.73m, 5 },
                    { 97, 7, "https://localhost:5001/images/products/product-1.jpg", "Incredible Frozen Chair", 3000.91m, 4 },
                    { 72, 6, "https://localhost:5001/images/products/product-3.jpg", "Fantastic Cotton Pants", 615.32m, 4 },
                    { 67, 7, "https://localhost:5001/images/products/product-5.jpg", "Tasty Cotton Gloves", 1647.86m, 4 },
                    { 50, 3, "https://localhost:5001/images/products/product-1.jpg", "Fantastic Cotton Keyboard", 1708.12m, 4 },
                    { 48, 24, "https://localhost:5001/images/products/product-2.jpg", "Generic Plastic Computer", 1873.40m, 4 },
                    { 47, 8, "https://localhost:5001/images/products/product-1.jpg", "Generic Soft Sausages", 4111.64m, 4 },
                    { 3, 20, "https://localhost:5001/images/products/product-2.jpg", "Small Cotton Bike", 2027.67m, 4 },
                    { 99, 22, "https://localhost:5001/images/products/product-1.jpg", "Small Wooden Salad", 4648.11m, 3 },
                    { 32, 3, "https://localhost:5001/images/products/product-3.jpg", "Tasty Fresh Shirt", 1720.61m, 5 },
                    { 93, 1, "https://localhost:5001/images/products/product-5.jpg", "Small Concrete Soap", 2440.59m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Body", "Email", "Name", "ProductId", "Stars", "Subject", "UserId" },
                values: new object[,]
                {
                    { 7, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Dock_Douglas@gmail.com", "Mozell Jaskolski", 17, 2, "Rustic Plastic Towels", null },
                    { 42, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Linnie_Moen49@gmail.com", "Theresia Herzog", 27, 2, "Small Wooden Chicken", null },
                    { 2, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Katelynn14@gmail.com", "Mylene Waelchi", 30, 5, "Handmade Concrete Pizza", null },
                    { 22, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Heaven_MacGyver@gmail.com", "Giovanny Spencer", 45, 3, "Tasty Rubber Sausages", null },
                    { 35, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Maximillian.Wisoky@yahoo.com", "Francisco Bayer", 64, 1, "Sleek Frozen Sausages", null },
                    { 46, "The Football Is Good For Training And Recreational Purposes", "Alverta10@hotmail.com", "Mossie Lesch", 64, 5, "Gorgeous Steel Cheese", null },
                    { 50, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Adelle58@hotmail.com", "Ezequiel Leannon", 24, 3, "Incredible Metal Sausages", null },
                    { 1, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Katlynn.Lind74@hotmail.com", "Itzel Sanford", 42, 4, "Gorgeous Frozen Cheese", null },
                    { 16, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Alvera.Christiansen86@yahoo.com", "Omer Frami", 60, 1, "Awesome Rubber Computer", null },
                    { 20, "The Football Is Good For Training And Recreational Purposes", "Newell26@yahoo.com", "Cristina Cassin", 96, 2, "Small Wooden Shoes", null },
                    { 27, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Sterling.Parisian@hotmail.com", "Dannie Turcotte", 41, 2, "Small Plastic Hat", null },
                    { 48, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Martine50@yahoo.com", "Bria Cummings", 62, 1, "Rustic Soft Shirt", null },
                    { 33, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Lowell.Jaskolski@gmail.com", "Terrell Ferry", 75, 3, "Refined Wooden Soap", null },
                    { 11, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Eddie30@hotmail.com", "Hilario Carter", 95, 5, "Sleek Plastic Sausages", null },
                    { 14, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Parker_Raynor60@gmail.com", "Tatyana McKenzie", 20, 4, "Incredible Concrete Pants", null },
                    { 10, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Cruz.Heathcote28@hotmail.com", "Louvenia Hills", 71, 1, "Practical Fresh Chicken", null },
                    { 37, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Seamus_Schmitt@yahoo.com", "Theodora Williamson", 85, 3, "Small Frozen Computer", null },
                    { 44, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Baron.Johns@yahoo.com", "Elian Reichert", 85, 3, "Generic Granite Mouse", null },
                    { 26, "The Football Is Good For Training And Recreational Purposes", "Alejandra_Koepp51@gmail.com", "Eric Schuppe", 39, 2, "Gorgeous Wooden Computer", null },
                    { 17, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Mayra_Weimann51@yahoo.com", "Manuela Ward", 44, 5, "Gorgeous Soft Gloves", null },
                    { 41, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Dillan_Quigley@yahoo.com", "Oral Collier", 44, 1, "Tasty Cotton Table", null },
                    { 9, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Gretchen_Bins51@hotmail.com", "Dedric Kunde", 61, 4, "Gorgeous Frozen Tuna", null },
                    { 40, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Claude.Lebsack@hotmail.com", "Fanny Boyle", 27, 5, "Generic Soft Pizza", null },
                    { 8, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Alice.Padberg@gmail.com", "Zachary Dietrich", 26, 2, "Sleek Rubber Computer", null },
                    { 13, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Anderson.Renner24@hotmail.com", "Shaun Feil", 10, 1, "Practical Rubber Mouse", null },
                    { 4, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Lloyd_Graham@yahoo.com", "Rod Schowalter", 10, 1, "Generic Metal Computer", null },
                    { 18, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Laverna_West@gmail.com", "Perry Raynor", 19, 4, "Rustic Frozen Keyboard", null },
                    { 25, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Misty12@gmail.com", "Dell Kutch", 6, 5, "Generic Metal Tuna", null },
                    { 19, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Maybell_Reinger20@yahoo.com", "Victor Powlowski", 23, 2, "Licensed Steel Hat", null },
                    { 24, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Alexandrea.Metz@hotmail.com", "Marvin Walter", 23, 1, "Practical Rubber Towels", null },
                    { 6, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Manuel_Turcotte@yahoo.com", "Libby McLaughlin", 86, 2, "Unbranded Metal Chair", null },
                    { 12, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Janiya.Thiel@gmail.com", "Marty Beer", 94, 4, "Generic Fresh Salad", null },
                    { 32, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Jayde_Dicki83@yahoo.com", "Bobby Fay", 11, 2, "Fantastic Granite Hat", null },
                    { 3, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Leilani_Wunsch@gmail.com", "Vivien Bauch", 13, 3, "Intelligent Frozen Hat", null },
                    { 31, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Reagan_Marks@gmail.com", "Juana Kovacek", 16, 3, "Ergonomic Wooden Table", null },
                    { 36, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Vickie68@gmail.com", "Cristobal Conn", 16, 4, "Gorgeous Wooden Fish", null },
                    { 39, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Cortney.Wolf@gmail.com", "Blanche Corwin", 80, 3, "Refined Fresh Bike", null },
                    { 47, "The Football Is Good For Training And Recreational Purposes", "Weston.Bergnaum@hotmail.com", "Jalen Rogahn", 16, 3, "Gorgeous Metal Computer", null },
                    { 23, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Arlene51@hotmail.com", "Jessyca Beahan", 87, 1, "Handcrafted Metal Ball", null },
                    { 43, "The Football Is Good For Training And Recreational Purposes", "Elliott_Von48@gmail.com", "Magdalena Leannon", 98, 2, "Intelligent Plastic Towels", null },
                    { 15, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Sheldon30@hotmail.com", "Olga Gleichner", 47, 5, "Fantastic Metal Bike", null },
                    { 21, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Jolie9@yahoo.com", "Kenya Walsh", 72, 4, "Refined Plastic Soap", null },
                    { 30, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Arne_Feest10@hotmail.com", "Danika Connelly", 15, 1, "Licensed Fresh Table", null },
                    { 38, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Nathen_OConner@gmail.com", "Dora Stiedemann", 15, 5, "Handcrafted Plastic Table", null },
                    { 45, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Quinten.Carroll36@gmail.com", "Tara Gerhold", 22, 4, "Handcrafted Plastic Computer", null },
                    { 29, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Anjali.Daniel91@gmail.com", "Ruthe Gutkowski", 78, 5, "Gorgeous Fresh Fish", null },
                    { 49, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Rahul38@gmail.com", "Else Bechtelar", 78, 2, "Gorgeous Wooden Fish", null },
                    { 5, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Darlene_Breitenberg@hotmail.com", "Gaylord Sauer", 79, 1, "Tasty Cotton Table", null },
                    { 34, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Delfina_Hahn7@yahoo.com", "Roger Keeling", 73, 2, "Tasty Concrete Shirt", null },
                    { 28, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Damian.Parisian67@yahoo.com", "Bernice Runte", 93, 3, "Rustic Concrete Soap", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductId",
                table: "CartProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorId",
                table: "Products",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorCategories_VendorId",
                table: "VendorCategories",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "VendorCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
