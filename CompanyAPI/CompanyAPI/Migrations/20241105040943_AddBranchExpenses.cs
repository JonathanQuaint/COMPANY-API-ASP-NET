using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchExpenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72ecb38d-a00b-4149-96a9-bcd2e45eebb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4767900-608d-4b2e-9edd-c05b54d8dbc4");

            migrationBuilder.AddColumn<double>(
                name: "AreasExpense",
                table: "Branchs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EmployeesExpense",
                table: "Branchs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EquipmentsExpense",
                table: "Branchs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EmployeesExpense",
                table: "Areas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EquipmentsExpense",
                table: "Areas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cfde3b03-ba5d-4cb1-9633-f36f74a67d40", null, "User", "USER" },
                    { "ec03d9af-01be-47fa-b5ff-809a095f4d3d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfde3b03-ba5d-4cb1-9633-f36f74a67d40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec03d9af-01be-47fa-b5ff-809a095f4d3d");

            migrationBuilder.DropColumn(
                name: "AreasExpense",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "EmployeesExpense",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "EquipmentsExpense",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "EmployeesExpense",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "EquipmentsExpense",
                table: "Areas");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72ecb38d-a00b-4149-96a9-bcd2e45eebb0", null, "Admin", "ADMIN" },
                    { "c4767900-608d-4b2e-9edd-c05b54d8dbc4", null, "User", "USER" }
                });
        }
    }
}
