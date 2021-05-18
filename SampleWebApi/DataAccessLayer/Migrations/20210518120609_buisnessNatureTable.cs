using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class buisnessNatureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuisnessNature",
                schema: "dbo",
                columns: table => new
                {
                    BNID = table.Column<int>(type: "int", nullable: false),
                    BNCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BNTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuisnessNature",
                schema: "dbo");
        }
    }
}
