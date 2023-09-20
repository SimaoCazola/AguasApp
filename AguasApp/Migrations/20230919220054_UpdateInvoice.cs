using Microsoft.EntityFrameworkCore.Migrations;

namespace AguasApp.Migrations
{
    public partial class UpdateInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceConsumptionViewModelId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_InvoiceConsumptionViewModelId",
                table: "Customers",
                column: "InvoiceConsumptionViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Invoices_InvoiceConsumptionViewModelId",
                table: "Customers",
                column: "InvoiceConsumptionViewModelId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Invoices_InvoiceConsumptionViewModelId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_InvoiceConsumptionViewModelId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceConsumptionViewModelId",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
