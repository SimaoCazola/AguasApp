using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AguasApp.Migrations
{
    public partial class SeviceUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerServices_Customers_CustomerNameId",
                table: "CustomerServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerServices_Technicians_TechnicianId",
                table: "CustomerServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerServices_WaterMeters_WaterMeterId",
                table: "CustomerServices");

            migrationBuilder.DropIndex(
                name: "IX_CustomerServices_TechnicianId",
                table: "CustomerServices");

            migrationBuilder.DropIndex(
                name: "IX_CustomerServices_WaterMeterId",
                table: "CustomerServices");

            migrationBuilder.DropColumn(
                name: "DateTimeOpened",
                table: "CustomerServices");

            migrationBuilder.DropColumn(
                name: "ServiceDescription",
                table: "CustomerServices");

            migrationBuilder.RenameColumn(
                name: "WaterMeterId",
                table: "CustomerServices",
                newName: "WaterMeterNumber");

            migrationBuilder.RenameColumn(
                name: "TechnicianId",
                table: "CustomerServices",
                newName: "TechnicianPhone");

            migrationBuilder.RenameColumn(
                name: "CustomerNameId",
                table: "CustomerServices",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerServices_CustomerNameId",
                table: "CustomerServices",
                newName: "IX_CustomerServices_ServiceId");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "CustomerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianName",
                table: "CustomerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WaterMeterName",
                table: "CustomerServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerServices_Service_ServiceId",
                table: "CustomerServices",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerServices_Service_ServiceId",
                table: "CustomerServices");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "CustomerServices");

            migrationBuilder.DropColumn(
                name: "TechnicianName",
                table: "CustomerServices");

            migrationBuilder.DropColumn(
                name: "WaterMeterName",
                table: "CustomerServices");

            migrationBuilder.RenameColumn(
                name: "WaterMeterNumber",
                table: "CustomerServices",
                newName: "WaterMeterId");

            migrationBuilder.RenameColumn(
                name: "TechnicianPhone",
                table: "CustomerServices",
                newName: "TechnicianId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "CustomerServices",
                newName: "CustomerNameId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerServices_ServiceId",
                table: "CustomerServices",
                newName: "IX_CustomerServices_CustomerNameId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeOpened",
                table: "CustomerServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ServiceDescription",
                table: "CustomerServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServices_TechnicianId",
                table: "CustomerServices",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServices_WaterMeterId",
                table: "CustomerServices",
                column: "WaterMeterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerServices_Customers_CustomerNameId",
                table: "CustomerServices",
                column: "CustomerNameId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerServices_Technicians_TechnicianId",
                table: "CustomerServices",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerServices_WaterMeters_WaterMeterId",
                table: "CustomerServices",
                column: "WaterMeterId",
                principalTable: "WaterMeters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
