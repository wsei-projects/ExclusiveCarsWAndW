using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class addimageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CarId", "DateOfCreate", "Description", "ImageUrl", "LongDescription", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 10, 20, 20, 34, 837, DateTimeKind.Local).AddTicks(4716), "Krótki opiss na bloga", "https://stimg.cardekho.com/images/carexteriorimages/630x420/Jaguar/F-TYPE/7810/1675671305429/front-left-side-47.jpg?tr=w-456", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tincidunt nec tellus eu congue. Integer imperdiet ex non ante ullamcorper feugiat. Quisque aliquet ex ipsum, vitae congue eros lacinia suscipit. Pellentesque arcu diam, efficitur nec ullamcorper nec, facilisis nec velit. Maecenas eu bibendum lectus. Curabitur luctus orci eget eros ullamcorper convallis. Nunc dictum mauris eu diam aliquet fermentum. Fusce iaculis tellus eget odio auctor, at dapibus velit aliquam. Sed sed eros nec velit elementum elementum. Cras sollicitudin mauris lobortis lobortis aliquet.", "Title" },
                    { 2, 2, new DateTime(2023, 7, 10, 20, 20, 34, 837, DateTimeKind.Local).AddTicks(4723), "Krótki opiss na bloga", "https://stimg.cardekho.com/images/carexteriorimages/630x420/Bentley/Continental/7771/1676965640042/front-left-side-47.jpg?tr=w-456", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tincidunt nec tellus eu congue. Integer imperdiet ex non ante ullamcorper feugiat. Quisque aliquet ex ipsum, vitae congue eros lacinia suscipit. Pellentesque arcu diam, efficitur nec ullamcorper nec, facilisis nec velit. Maecenas eu bibendum lectus. Curabitur luctus orci eget eros ullamcorper convallis. Nunc dictum mauris eu diam aliquet fermentum. Fusce iaculis tellus eget odio auctor, at dapibus velit aliquam. Sed sed eros nec velit elementum elementum. Cras sollicitudin mauris lobortis lobortis aliquet.", "Title" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBGuw2y+sEkKwZ47kztXcvzrzgd13YIAjnxT1KtQZv97FKc8z70EDhtIoSTTg0jtoA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA6/jbTLz941INZbQxvbCHvA0FYLEOiXuzDBjC2phqsyBuUnArwNFCkNrWG/iXX2qA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://stimg.cardekho.com/images/carexteriorimages/630x420/Jaguar/F-TYPE/7810/1675671305429/front-left-side-47.jpg?tr=w-456");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://stimg.cardekho.com/images/carexteriorimages/630x420/BMW/M2/10257/1686225075596/front-left-side-47.jpg?tr=w-456");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://stimg.cardekho.com/images/carexteriorimages/630x420/Bentley/Continental/7771/1676965640042/front-left-side-47.jpg?tr=w-456");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://stimg.cardekho.com/images/carexteriorimages/630x420/BMW/Z4/10183/1685003672330/front-left-side-47.jpg?impolicy=resize&imwidth=420");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://stimg.cardekho.com/images/carexteriorimages/630x420/Lamborghini/Huracan-EVO/6729/1678692048287/front-left-side-47.jpg?tr=w-456");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAO+SpsdU6VNf7kIPa2oRYcPlEhtU6Z7Zh+k/VxxhiX/vCHqPj/FrCg4GEuDOOI7PA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEH/sw5mjAQtiIC3ILFfCqMD912U9uxq3ocBcHlWHsF/rD70QeLLQo1GsenRyj2WiSQ==");
        }
    }
}
