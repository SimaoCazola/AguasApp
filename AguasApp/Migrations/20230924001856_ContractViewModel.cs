using Microsoft.EntityFrameworkCore.Migrations;

namespace AguasApp.Migrations
{
    public partial class ContractViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Customers_CustomerNameId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_CustomerNameId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerNameId",
                table: "Contracts");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "CustomerNameId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CustomerNameId",
                table: "Contracts",
                column: "CustomerNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Customers_CustomerNameId",
                table: "Contracts",
                column: "CustomerNameId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
