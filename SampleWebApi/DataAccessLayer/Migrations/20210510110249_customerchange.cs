using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class customerchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "dbo",
                table: "Customers",
                newName: "CustType");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "Customers",
                newName: "CName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustType",
                schema: "dbo",
                table: "Customers",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "CName",
                schema: "dbo",
                table: "Customers",
                newName: "Name");
        }
    }
}
