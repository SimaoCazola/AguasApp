using Microsoft.EntityFrameworkCore.Migrations;

namespace AguasApp.Migrations
{
    public partial class InvoiceUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Consumptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_InvoiceId",
                table: "Consumptions",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumptions_Invoices_InvoiceId",
                table: "Consumptions",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_Invoices_InvoiceId",
                table: "Consumptions");

            migrationBuilder.DropIndex(
                name: "IX_Consumptions_InvoiceId",
                table: "Consumptions");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Consumptions");
        }
    }
}
