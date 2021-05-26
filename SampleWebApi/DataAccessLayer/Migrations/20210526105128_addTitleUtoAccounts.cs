using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addTitleUtoAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "companyTitleU",
                schema: "dbo",
                table: "cdCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleU",
                schema: "dbo",
                table: "adMainGroupAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleU",
                schema: "dbo",
                table: "adGroupAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleU",
                schema: "dbo",
                table: "adFinancialStatementTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleU",
                schema: "dbo",
                table: "adFinancialStatementCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleU",
                schema: "dbo",
                table: "adControlAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleU",
                schema: "dbo",
                table: "adCategoryAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleU",
                schema: "dbo",
                table: "adAccountTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleU",
                schema: "dbo",
                table: "adAccountTransactionTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companyTitleU",
                schema: "dbo",
                table: "cdCompanies");

            migrationBuilder.DropColumn(
                name: "TitleU",
                schema: "dbo",
                table: "adMainGroupAccounts");

            migrationBuilder.DropColumn(
                name: "TitleU",
                schema: "dbo",
                table: "adGroupAccounts");

            migrationBuilder.DropColumn(
                name: "TitleU",
                schema: "dbo",
                table: "adFinancialStatementTypes");

            migrationBuilder.DropColumn(
                name: "TitleU",
                schema: "dbo",
                table: "adFinancialStatementCategories");

            migrationBuilder.DropColumn(
                name: "TitleU",
                schema: "dbo",
                table: "adControlAccounts");

            migrationBuilder.DropColumn(
                name: "TitleU",
                schema: "dbo",
                table: "adCategoryAccounts");

            migrationBuilder.DropColumn(
                name: "TitleU",
                schema: "dbo",
                table: "adAccountTypes");

            migrationBuilder.DropColumn(
                name: "TitleU",
                schema: "dbo",
                table: "adAccountTransactionTypes");
        }
    }
}
