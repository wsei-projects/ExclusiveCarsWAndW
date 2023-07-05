using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Class", "Model", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { 1, "Audi", 0, "A7", 50m, 2020 },
                    { 2, "BMW", 3, "M3", 150m, 2021 },
                    { 3, "Skoda", 1, "Octavia", 40m, 2011 },
                    { 4, "Mitsubisy", 2, "Outlander", 80m, 2019 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
