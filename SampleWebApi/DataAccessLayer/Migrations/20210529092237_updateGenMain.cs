using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class updateGenMain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                schema: "dbo",
                table: "GenSub");

            migrationBuilder.RenameColumn(
                name: "CDate",
                schema: "dbo",
                table: "GenMain",
                newName: "EDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EDate",
                schema: "dbo",
                table: "GenMain",
                newName: "CDate");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "GenSub",
                type: "int",
                nullable: true);
        }
    }
}
