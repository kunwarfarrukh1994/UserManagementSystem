using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addEdateCodeCodingtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EDate",
                schema: "dbo",
                table: "CodeCodingProductType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EDate",
                schema: "dbo",
                table: "CodeCodingOptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EDate",
                schema: "dbo",
                table: "CodeCodingCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EDate",
                schema: "dbo",
                table: "CodeCodingProductType");

            migrationBuilder.DropColumn(
                name: "EDate",
                schema: "dbo",
                table: "CodeCodingOptions");

            migrationBuilder.DropColumn(
                name: "EDate",
                schema: "dbo",
                table: "CodeCodingCategory");
        }
    }
}
