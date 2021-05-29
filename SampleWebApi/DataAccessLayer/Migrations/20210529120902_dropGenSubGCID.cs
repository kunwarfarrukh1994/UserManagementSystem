using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class dropGenSubGCID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GCID",
                schema: "dbo",
                table: "GenSub");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GCID",
                schema: "dbo",
                table: "GenSub",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
