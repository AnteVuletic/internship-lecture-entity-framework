using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecture.Data.Migrations
{
    public partial class DatabaseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, 200m, new DateTime(2021, 1, 10, 13, 59, 24, 703, DateTimeKind.Local).AddTicks(9858), 1 },
                    { 2, 300m, new DateTime(2021, 1, 10, 13, 59, 24, 712, DateTimeKind.Local).AddTicks(5045), 0 }
                });

            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1, "Volkswagen" },
                    { 2, "Porsche" },
                    { 3, "Yamaha" },
                    { 4, "Citroen" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "BrandId", "Model", "VehicleType" },
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RentRates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentRates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
