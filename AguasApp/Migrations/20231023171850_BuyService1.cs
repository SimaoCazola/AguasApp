using Microsoft.EntityFrameworkCore.Migrations;

namespace AguasApp.Migrations
{
    public partial class BuyService1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyServices_AspNetUsers_UserId",
                table: "BuyServices");

            migrationBuilder.DropIndex(
                name: "IX_BuyServices_UserId",
                table: "BuyServices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BuyServices");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "BuyServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "BuyServices");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BuyServices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuyServices_UserId",
                table: "BuyServices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyServices_AspNetUsers_UserId",
                table: "BuyServices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
