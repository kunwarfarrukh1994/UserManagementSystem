using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                schema: "dbo",
                table: "GoDown",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "dbo",
                table: "GoDown",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperatorID",
                schema: "dbo",
                table: "GoDown",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchID",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropColumn(
                name: "OperatorID",
                schema: "dbo",
                table: "GoDown");
        }
    }
}
