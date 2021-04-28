using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class changeBranchId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrachID",
                schema: "dbo",
                table: "SaleMain",
                newName: "BranchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BranchID",
                schema: "dbo",
                table: "SaleMain",
                newName: "BrachID");
        }
    }
}
