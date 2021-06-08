using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class CodeCodingMainChange4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                schema: "dbo",
                table: "CodeCodingWarehouse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "dbo",
                table: "CodeCodingWarehouse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Del",
                schema: "dbo",
                table: "CodeCodingWarehouse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sync",
                schema: "dbo",
                table: "CodeCodingWarehouse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchID",
                schema: "dbo",
                table: "CodeCodingWarehouse");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "dbo",
                table: "CodeCodingWarehouse");

            migrationBuilder.DropColumn(
                name: "Del",
                schema: "dbo",
                table: "CodeCodingWarehouse");

            migrationBuilder.DropColumn(
                name: "Sync",
                schema: "dbo",
                table: "CodeCodingWarehouse");

            migrationBuilder.DropColumn(
                name: "BranchID",
                schema: "dbo",
                table: "CodeCodingProduction");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "dbo",
                table: "CodeCodingProduction");
        }
    }
}
