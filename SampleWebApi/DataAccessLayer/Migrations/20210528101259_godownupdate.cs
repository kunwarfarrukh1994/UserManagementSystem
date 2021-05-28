using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class godownupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoType",
                schema: "dbo",
                table: "GoDown",
                newName: "ShortName");

            migrationBuilder.RenameColumn(
                name: "FinId",
                schema: "dbo",
                table: "GoDown",
                newName: "SortOrder");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "GoDown",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressU",
                schema: "dbo",
                table: "GoDown",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "GoDown",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GoNameU",
                schema: "dbo",
                table: "GoDown",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                schema: "dbo",
                table: "GoDown",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropColumn(
                name: "AddressU",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropColumn(
                name: "GoNameU",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.RenameColumn(
                name: "SortOrder",
                schema: "dbo",
                table: "GoDown",
                newName: "FinId");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                schema: "dbo",
                table: "GoDown",
                newName: "GoType");
        }
    }
}
