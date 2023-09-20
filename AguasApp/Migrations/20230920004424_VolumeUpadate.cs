using Microsoft.EntityFrameworkCore.Migrations;

namespace AguasApp.Migrations
{
    public partial class VolumeUpadate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Volume",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "Invoices",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
    }
}
