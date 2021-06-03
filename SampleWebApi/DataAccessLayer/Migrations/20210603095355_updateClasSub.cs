using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class updateClasSub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassID",
                schema: "dbo",
                table: "mClassSub");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassID",
                schema: "dbo",
                table: "mClassSub",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
