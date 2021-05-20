using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class accoutTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accCodeID",
                schema: "dbo",
                table: "adAccounts");

            migrationBuilder.AddColumn<string>(
                name: "TitleU",
                schema: "dbo",
                table: "adAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleU",
                schema: "dbo",
                table: "adAccounts");

            migrationBuilder.AddColumn<int>(
                name: "accCodeID",
                schema: "dbo",
                table: "adAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
