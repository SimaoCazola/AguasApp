using Microsoft.EntityFrameworkCore.Migrations;

namespace AguasApp.Migrations
{
    public partial class UpdateNewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Customers_CustomerNameId",
                table: "MeterReadings");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Customers_NifId",
                table: "MeterReadings");

            migrationBuilder.DropIndex(
                name: "IX_MeterReadings_CustomerNameId",
                table: "MeterReadings");

            migrationBuilder.DropIndex(
                name: "IX_MeterReadings_NifId",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "CustomerNameId",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "NifId",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "RegisteredConsumption",
                table: "MeterReadings");

            migrationBuilder.AddColumn<string>(
                name: "CounterName",
                table: "MeterReadings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CounterNumber",
                table: "MeterReadings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "MeterReadings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MeterReadings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nif",
                table: "MeterReadings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Volume",
                table: "MeterReadings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Volume",
                table: "Consumptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CounterName",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "CounterNumber",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "Nif",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "MeterReadings");

            migrationBuilder.AddColumn<int>(
                name: "CustomerNameId",
                table: "MeterReadings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NifId",
                table: "MeterReadings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RegisteredConsumption",
                table: "MeterReadings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "Consumptions",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_CustomerNameId",
                table: "MeterReadings",
                column: "CustomerNameId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_NifId",
                table: "MeterReadings",
                column: "NifId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadings_Customers_CustomerNameId",
                table: "MeterReadings",
                column: "CustomerNameId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadings_Customers_NifId",
                table: "MeterReadings",
                column: "NifId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
