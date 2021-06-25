using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class changecodecoding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AgentMinRate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentMinRate",
                schema: "dbo",
                table: "CodeCodingMain");
        }
    }
}
