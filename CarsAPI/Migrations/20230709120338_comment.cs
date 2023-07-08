using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostID",
                table: "Comment",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Posts_PostID",
                table: "Comment",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Posts_PostID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_PostID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "Comment");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEL8LKDLvLhJBXkSKFYgOoy/HQXYTfRORFb/yURjG56HFnOyBGmIwPSCzbZhzpctO6A==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEyv2Ugc+reBuuF35P2mXCPA2n7qQgbS2qEJgWi8ljtE7xTTv72ejXnYKe5ADTqOnw==");
        }
    }
}
