using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class customerContact2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactPerson",
                schema: "dbo",
                table: "CustomerContacts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                schema: "dbo",
                table: "CustomerContacts",
                newName: "ContactNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "CustomerContacts",
                newName: "ContactPerson");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                schema: "dbo",
                table: "CustomerContacts",
                newName: "ContactName");
        }
    }
}
