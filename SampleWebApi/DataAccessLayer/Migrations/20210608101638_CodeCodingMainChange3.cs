using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class CodeCodingMainChange3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPID",
                schema: "dbo",
                table: "CodeCodingProduction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CPID",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
