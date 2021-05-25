using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addCtrlAccFieldsinadAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CtrlAccIDCr",
                schema: "dbo",
                table: "adAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CtrlAccIDDr",
                schema: "dbo",
                table: "adAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CtrlAccIDCr",
                schema: "dbo",
                table: "adAccounts");

            migrationBuilder.DropColumn(
                name: "CtrlAccIDDr",
                schema: "dbo",
                table: "adAccounts");
        }
    }
}
