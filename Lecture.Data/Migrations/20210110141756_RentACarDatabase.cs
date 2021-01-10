using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecture.Data.Migrations
{
    public partial class RentACarDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrivingLicenseIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentRateType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kilometers = table.Column<int>(type: "int", nullable: false),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrations_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartOfRent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfRent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    RentRateId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_RentRates_RentRateId",
                        column: x => x.RentRateId,
                        principalTable: "RentRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DateOfBirth", "DrivingLicenseIdentifier", "FirstName", "LastName", "Oib" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12831121", "Ante", "Antić", "12382172389" },
                    { 2, new DateTime(1998, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12831122", "Matija", "Luketin", "12382172159" },
                    { 3, new DateTime(1993, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12831123", "Krešimir", "Čondić", "12382172129" },
                    { 4, new DateTime(1996, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12831124", "Roko", "Radanović", "12382172139" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Mate", "Matić" },
                    { 2, "Jure", "Jurić" },
                    { 3, "Šime", "Šimić" }
                });

            migrationBuilder.InsertData(
                table: "RentRates",
                columns: new[] { "Id", "Cost", "CreatedAt", "RentRateType" },
                values: new object[,]
                {
                    { 1, 200m, new DateTime(2021, 1, 10, 15, 17, 56, 387, DateTimeKind.Local).AddTicks(224), 1 },
                    { 2, 300m, new DateTime(2021, 1, 10, 15, 17, 56, 389, DateTimeKind.Local).AddTicks(1261), 0 }
                });

            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Volkswagen" },
                    { 2, "Porsche" },
                    { 3, "Yamaha" },
                    { 4, "Citroen" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "BrandId", "Name", "VehicleType" },
                values: new object[,]
                {
                    { 1, 1, "Up", 0 },
                    { 2, 1, "Golf", 0 },
                    { 3, 2, "Cayenne", 0 },
                    { 4, 3, "T-Max", 1 },
                    { 5, 4, "Berlingo", 2 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Kilometers", "VehicleModelId" },
                values: new object[,]
                {
                    { 1, 0, 1 },
                    { 2, 0, 1 },
                    { 3, 20, 2 },
                    { 4, 205, 2 },
                    { 5, 265, 2 },
                    { 6, 205, 3 },
                    { 7, 205, 4 },
                    { 8, 205, 5 }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "Id", "DateOfRegistration", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 7, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 6, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 5, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 3, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 2, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "CustomerId", "EmployeeId", "EndOfRent", "RentRateId", "StartOfRent", "VehicleId" },
                values: new object[,]
                {
                    { 10, 4, 1, new DateTime(2020, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, 1, 1, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, 3, 3, new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 7, 3, 1, new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 3, 1, 2, new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, 2, 2, new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 6, 2, 3, new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 9, 3, 3, new DateTime(2020, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, 4, 2, new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 5, 2, 3, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 17, 1, 1, new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, 4, 1, new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 12, 4, 1, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, 3, 2, new DateTime(2020, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 19, 3, 2, new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, 4, 2, new DateTime(2020, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 2, 1, new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, 2, 3, new DateTime(2020, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 1, 1, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, 2, 2, new DateTime(2020, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_VehicleId",
                table: "Registrations",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CustomerId",
                table: "Rents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_EmployeeId",
                table: "Rents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_RentRateId",
                table: "Rents",
                column: "RentRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_VehicleId",
                table: "Rents",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_BrandId",
                table: "VehicleModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RentRates");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleBrands");
        }
    }
}
