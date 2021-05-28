using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addDelSync : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Del",
                schema: "dbo",
                table: "GoDown",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sync",
                schema: "dbo",
                table: "GoDown",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Del",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropColumn(
                name: "Sync",
                schema: "dbo",
                table: "GoDown");
        }
    }
}
