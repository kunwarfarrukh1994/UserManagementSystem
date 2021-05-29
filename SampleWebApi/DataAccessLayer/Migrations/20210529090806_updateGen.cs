using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class updateGen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "dbo",
                table: "GenSub",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpertorID",
                schema: "dbo",
                table: "GenSub",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "dbo",
                table: "GenMain",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpertorID",
                schema: "dbo",
                table: "GenMain",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "dbo",
                table: "GenSub");

            migrationBuilder.DropColumn(
                name: "OpertorID",
                schema: "dbo",
                table: "GenSub");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "dbo",
                table: "GenMain");

            migrationBuilder.DropColumn(
                name: "OpertorID",
                schema: "dbo",
                table: "GenMain");
        }
    }
}
