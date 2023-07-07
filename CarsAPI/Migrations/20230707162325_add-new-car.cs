using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class addnewcar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "ClassId", "Description", "ImageUrl", "Model", "PricePerDay", "Year" },
                values: new object[] { 5, "Skoda", 1, "Spacious and versatile SUV. Lorem ipsum", "https://stimg.cardekho.com/images/carexteriorimages/630x420/Lamborghini/Huracan-EVO/6729/1678692048287/front-left-side-47.jpg?tr=w-456", "Fabia", 50m, 2022 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
