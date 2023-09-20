using Microsoft.EntityFrameworkCore.Migrations;

namespace AguasApp.Migrations
{
    public partial class Consumption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Consumptions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ScalationId",
                table: "Consumptions",
                newName: "Scalation");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Consumptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Consumptions",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "Scalation",
                table: "Consumptions",
                newName: "ScalationId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Consumptions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
