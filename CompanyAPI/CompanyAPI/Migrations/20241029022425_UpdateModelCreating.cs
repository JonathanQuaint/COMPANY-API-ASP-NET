using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Branchs_LinkedBranchId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Branchs_Company_CompanyLinkedID",
                table: "Branchs");

            migrationBuilder.RenameColumn(
                name: "CompanyLinkedID",
                table: "Branchs",
                newName: "CompanyID");

            migrationBuilder.RenameIndex(
                name: "IX_Branchs_CompanyLinkedID",
                table: "Branchs",
                newName: "IX_Branchs_CompanyID");

            migrationBuilder.RenameColumn(
                name: "LinkedBranchId",
                table: "Areas",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Areas_LinkedBranchId",
                table: "Areas",
                newName: "IX_Areas_BranchId");

            migrationBuilder.AddColumn<int>(
                name: "AreaModelId",
                table: "Equipments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaModelId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_AreaModelId",
                table: "Equipments",
                column: "AreaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AreaModelId",
                table: "Employees",
                column: "AreaModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Branchs_BranchId",
                table: "Areas",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branchs_Company_CompanyID",
                table: "Branchs",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Areas_AreaModelId",
                table: "Employees",
                column: "AreaModelId",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Areas_AreaModelId",
                table: "Equipments",
                column: "AreaModelId",
                principalTable: "Areas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Branchs_BranchId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Branchs_Company_CompanyID",
                table: "Branchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Areas_AreaModelId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Areas_AreaModelId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_AreaModelId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AreaModelId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AreaModelId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "AreaModelId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Branchs",
                newName: "CompanyLinkedID");

            migrationBuilder.RenameIndex(
                name: "IX_Branchs_CompanyID",
                table: "Branchs",
                newName: "IX_Branchs_CompanyLinkedID");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Areas",
                newName: "LinkedBranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Areas_BranchId",
                table: "Areas",
                newName: "IX_Areas_LinkedBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Branchs_LinkedBranchId",
                table: "Areas",
                column: "LinkedBranchId",
                principalTable: "Branchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branchs_Company_CompanyLinkedID",
                table: "Branchs",
                column: "CompanyLinkedID",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
