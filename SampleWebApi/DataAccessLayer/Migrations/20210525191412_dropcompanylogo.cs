using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class dropcompanylogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companyLogo",
                schema: "dbo",
                table: "cdCompanies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "companyLogo",
                schema: "dbo",
                table: "cdCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
