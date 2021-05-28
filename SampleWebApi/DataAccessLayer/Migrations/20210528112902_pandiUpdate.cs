using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class pandiUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                schema: "dbo",
                table: "Pandi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "dbo",
                table: "Pandi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperatorID",
                schema: "dbo",
                table: "Pandi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "PerPhaira",
                schema: "dbo",
                table: "Pandi",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                schema: "dbo",
                table: "Pandi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchID",
                schema: "dbo",
                table: "Pandi");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "dbo",
                table: "Pandi");

            migrationBuilder.DropColumn(
                name: "OperatorID",
                schema: "dbo",
                table: "Pandi");

            migrationBuilder.DropColumn(
                name: "PerPhaira",
                schema: "dbo",
                table: "Pandi");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                schema: "dbo",
                table: "Pandi");
        }
    }
}
