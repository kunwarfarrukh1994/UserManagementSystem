using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class removedCWIDCodeCodingWare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CWID",
                schema: "dbo",
                table: "CodeCodingWarehouse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CWID",
                schema: "dbo",
                table: "CodeCodingWarehouse",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
