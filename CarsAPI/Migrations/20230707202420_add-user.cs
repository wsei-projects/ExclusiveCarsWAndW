using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class adduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "RoleId" },
                values: new object[,]
                {
                    { 1, "user@test.com", "AQAAAAIAAYagAAAAEAq48pY1iSTWImifAzdi3koHpeFZvWJiibI3fQCMHe1hkGLAcfkW7Bwi8coXQKOAZw==", 1 },
                    { 2, "admin@test.com", "AQAAAAIAAYagAAAAEAq48pY1iSTWImifAzdi3koHpeFZvWJiibI3fQCMHe1hkGLAcfkW7Bwi8coXQKOAZw==", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
