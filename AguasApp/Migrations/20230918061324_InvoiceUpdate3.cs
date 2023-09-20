using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AguasApp.Migrations
{
    public partial class InvoiceUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_Invoices_InvoiceId",
                table: "Consumptions");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Consumptions_RegisteredConsumptionId",
                table: "MeterReadings");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Customers_CustomerId",
                table: "MeterReadings");

            migrationBuilder.DropIndex(
                name: "IX_Consumptions_InvoiceId",
                table: "Consumptions");

            migrationBuilder.DropColumn(
                name: "LastReadingDate",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Consumptions");

            migrationBuilder.RenameColumn(
                name: "RegisteredConsumptionId",
                table: "MeterReadings",
                newName: "NifId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "MeterReadings",
                newName: "CustomerNameId");

            migrationBuilder.RenameIndex(
                name: "IX_MeterReadings_RegisteredConsumptionId",
                table: "MeterReadings",
                newName: "IX_MeterReadings_NifId");

            migrationBuilder.RenameIndex(
                name: "IX_MeterReadings_CustomerId",
                table: "MeterReadings",
                newName: "IX_MeterReadings_CustomerNameId");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "Invoices",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "IssueDate",
                table: "Invoices",
                newName: "LastReadingDate");

            migrationBuilder.AddColumn<double>(
                name: "RegisteredConsumption",
                table: "MeterReadings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Entity",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Invoices",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Nif",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reference",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Scalation",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "Invoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Nif",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Address",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Customers_CustomerNameId",
                table: "MeterReadings");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Customers_NifId",
                table: "MeterReadings");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "RegisteredConsumption",
                table: "MeterReadings");

            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Entity",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Nif",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Scalation",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "NifId",
                table: "MeterReadings",
                newName: "RegisteredConsumptionId");

            migrationBuilder.RenameColumn(
                name: "CustomerNameId",
                table: "MeterReadings",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_MeterReadings_NifId",
                table: "MeterReadings",
                newName: "IX_MeterReadings_RegisteredConsumptionId");

            migrationBuilder.RenameIndex(
                name: "IX_MeterReadings_CustomerNameId",
                table: "MeterReadings",
                newName: "IX_MeterReadings_CustomerId");

            migrationBuilder.RenameColumn(
                name: "LastReadingDate",
                table: "Invoices",
                newName: "IssueDate");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Invoices",
                newName: "PaymentStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastReadingDate",
                table: "MeterReadings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToPay",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Nif",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadings_Consumptions_RegisteredConsumptionId",
                table: "MeterReadings",
                column: "RegisteredConsumptionId",
                principalTable: "Consumptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadings_Customers_CustomerId",
                table: "MeterReadings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
