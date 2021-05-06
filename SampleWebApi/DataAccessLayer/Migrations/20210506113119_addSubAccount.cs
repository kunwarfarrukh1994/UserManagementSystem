using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addSubAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "SubAccount",
                schema: "dbo",
                newName: "subAccount",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_SubAccount_ID",
                schema: "dbo",
                table: "subAccount",
                newName: "IX_subAccount_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "subAccount",
                schema: "dbo",
                newName: "SubAccount",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_subAccount_ID",
                schema: "dbo",
                table: "SubAccount",
                newName: "IX_SubAccount_ID");
        }
    }
}
