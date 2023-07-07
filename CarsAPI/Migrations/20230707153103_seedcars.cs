using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedcars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarClass",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Economy" },
                    { 2, "SUV" },
                    { 3, "Luxury" },
                    { 4, "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "ClassId", "Description", "ImageUrl", "Model", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", 1, "Spacious and reliable sedan.", "car1.jpg", "Corolla", 50.99m, 2020 },
                    { 2, "BMW", 4, "Fast exlusive car", "car2.jpg", "M3", 150.00m, 2021 },
                    { 3, "Skoda", 1, "Comfortable and fuel-efficient sedan.", "car3.jpg", "Octavia", 40m, 2011 },
                    { 4, "Mitsubisy", 2, "Spacious and versatile SUV.", "car4.jpg", "Outlander", 80m, 2019 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarClass",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "CarClass",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarClass",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarClass",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
