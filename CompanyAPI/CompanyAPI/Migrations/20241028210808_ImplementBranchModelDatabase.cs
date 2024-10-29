using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyAPI.Migrations
{
    /// <inheritdoc />   
    public partial class ImplementBranchModelDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branchs_Company_CompanyModelId",
                table: "Branchs");

            migrationBuilder.DropIndex(
                name: "IX_Branchs_CompanyModelId",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "CompanyModelId",
                table: "Branchs");

            migrationBuilder.AddColumn<int>(
                name: "CompanyLinkedID",
                table: "Branchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_CompanyLinkedID",
                table: "Branchs",
                column: "CompanyLinkedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Branchs_Company_CompanyLinkedID",
                table: "Branchs",
                column: "CompanyLinkedID",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branchs_Company_CompanyLinkedID",
                table: "Branchs");

            migrationBuilder.DropIndex(
                name: "IX_Branchs_CompanyLinkedID",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "CompanyLinkedID",
                table: "Branchs");

            migrationBuilder.AddColumn<int>(
                name: "CompanyModelId",
                table: "Branchs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_CompanyModelId",
                table: "Branchs",
                column: "CompanyModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branchs_Company_CompanyModelId",
                table: "Branchs",
                column: "CompanyModelId",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
