using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecture.Data.Migrations
{
    public partial class AddCostToRentRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "RentRates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "RentRates");
        }
    }
}
