using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateadminuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPMaPFS3bK0iunWtUK/n5S6SCpmyg14uzmr175xg4aOB8+fN9T3294Wg+NDPmjLk3g==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKKlKeLIff4409PRxZ8xpA3snu1syuvIv3rhGYlLzNAP9DF6MTihlKtxdQpTXk9UzA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAq48pY1iSTWImifAzdi3koHpeFZvWJiibI3fQCMHe1hkGLAcfkW7Bwi8coXQKOAZw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAq48pY1iSTWImifAzdi3koHpeFZvWJiibI3fQCMHe1hkGLAcfkW7Bwi8coXQKOAZw==");
        }
    }
}
