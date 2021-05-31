using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addMainGropuIdCutomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerCategory",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "MainGroupID",
                schema: "dbo",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainGroupID",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "CustomerCategory",
                schema: "dbo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
