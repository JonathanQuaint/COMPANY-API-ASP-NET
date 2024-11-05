using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branchs_Companys_CompanyID",
                table: "Branchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companys",
                table: "Companys");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfde3b03-ba5d-4cb1-9633-f36f74a67d40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec03d9af-01be-47fa-b5ff-809a095f4d3d");

            migrationBuilder.RenameTable(
                name: "Companys",
                newName: "Companies");

            migrationBuilder.RenameColumn(
                name: "HeadOffice",
                table: "Branchs",
                newName: "State");

            migrationBuilder.AddColumn<DateTime>(
                name: "AcquisitionDate",
                table: "Equipments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Branchs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Branchs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Branchs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Branchs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Areas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Areas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CompanyType",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a0a274d-9b44-48ea-a59c-fd31bbe035af", null, "Admin", "ADMIN" },
                    { "7c696140-ccf6-4c9d-9e76-c24c9235bbc2", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Branchs_Companies_CompanyID",
                table: "Branchs",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branchs_Companies_CompanyID",
                table: "Branchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a0a274d-9b44-48ea-a59c-fd31bbe035af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c696140-ccf6-4c9d-9e76-c24c9235bbc2");

            migrationBuilder.DropColumn(
                name: "AcquisitionDate",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "CompanyType",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Companys");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Branchs",
                newName: "HeadOffice");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companys",
                table: "Companys",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cfde3b03-ba5d-4cb1-9633-f36f74a67d40", null, "User", "USER" },
                    { "ec03d9af-01be-47fa-b5ff-809a095f4d3d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Branchs_Companys_CompanyID",
                table: "Branchs",
                column: "CompanyID",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
