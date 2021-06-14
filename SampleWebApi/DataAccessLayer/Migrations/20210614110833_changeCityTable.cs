using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class changeCityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinID",
                schema: "dbo",
                table: "City",
                newName: "CompanyID");

            migrationBuilder.AddColumn<string>(
                name: "CityCode",
                schema: "dbo",
                table: "City",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityCode",
                schema: "dbo",
                table: "City");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                schema: "dbo",
                table: "City",
                newName: "FinID");
        }
    }
}
