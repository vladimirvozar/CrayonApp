using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StreetAddressLine = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LicenseStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "License",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Price = table.Column<double>(type: "REAL", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSubscription = table.Column<bool>(type: "INTEGER", nullable: false),
                    SoftwareProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    RenewalPeriod = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.Id);
                    table.ForeignKey(
                        name: "FK_License_SoftwareProduct_SoftwareProductId",
                        column: x => x.SoftwareProductId,
                        principalTable: "SoftwareProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    AccountType = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SoftwareName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    SoftwareCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LicenseName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    LicenseCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", precision: 18, scale: 2, nullable: false),
                    Subtotal = table.Column<double>(type: "REAL", precision: 18, scale: 2, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareLicense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SoftwareName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    SoftwareCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LicenseName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    LicenseCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ValidFromDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ValidToDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsSubscription = table.Column<bool>(type: "INTEGER", nullable: false),
                    RenewalPeriod = table.Column<int>(type: "INTEGER", nullable: true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareLicense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareLicense_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareLicense_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareLicenseStatus",
                columns: table => new
                {
                    SoftwareLicenseId = table.Column<int>(type: "INTEGER", nullable: false),
                    LicenseStatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    SoftwareLicenseStatusDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareLicenseStatus", x => new { x.SoftwareLicenseId, x.LicenseStatusId });
                    table.ForeignKey(
                        name: "FK_SoftwareLicenseStatus_LicenseStatus_LicenseStatusId",
                        column: x => x.LicenseStatusId,
                        principalTable: "LicenseStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareLicenseStatus_SoftwareLicense_SoftwareLicenseId",
                        column: x => x.SoftwareLicenseId,
                        principalTable: "SoftwareLicense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "PostalCode", "State", "StreetAddressLine" },
                values: new object[] { 1, "New York", "21345", "New York", "Main Street 32" });

            migrationBuilder.InsertData(
                table: "LicenseStatus",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "NA", "Not Activated" },
                    { 2, "ACT", "Active" },
                    { 3, "EXP", "Expired" },
                    { 4, "CA", "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "MiddleName", "Phone" },
                values: new object[] { 1, 1, "john.smith@mailinator.com", "John", "Smith", null, "123-456" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountType", "CustomerId", "Name" },
                values: new object[,]
                {
                    { 1, 0, 1, "John's School account" },
                    { 2, 2, 1, "John's Business account" },
                    { 3, 3, 1, "John's Premium account" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_CustomerId",
                table: "Account",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AddressId",
                table: "Customer",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_License_SoftwareProductId",
                table: "License",
                column: "SoftwareProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicense_AccountId",
                table: "SoftwareLicense",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicense_OrderId",
                table: "SoftwareLicense",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareLicenseStatus_LicenseStatusId",
                table: "SoftwareLicenseStatus",
                column: "LicenseStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "SoftwareLicenseStatus");

            migrationBuilder.DropTable(
                name: "SoftwareProduct");

            migrationBuilder.DropTable(
                name: "LicenseStatus");

            migrationBuilder.DropTable(
                name: "SoftwareLicense");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
