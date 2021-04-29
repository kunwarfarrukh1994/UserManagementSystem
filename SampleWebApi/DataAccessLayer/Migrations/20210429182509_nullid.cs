using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class nullid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SaleSub_ID",
                schema: "dbo",
                table: "SaleSub");

            migrationBuilder.DropIndex(
                name: "IX_SaleMain_ID",
                schema: "dbo",
                table: "SaleMain");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "SaleSub",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "SaleMain",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SaleSub_ID",
                schema: "dbo",
                table: "SaleSub",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SaleMain_ID",
                schema: "dbo",
                table: "SaleMain",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SaleSub_ID",
                schema: "dbo",
                table: "SaleSub");

            migrationBuilder.DropIndex(
                name: "IX_SaleMain_ID",
                schema: "dbo",
                table: "SaleMain");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "SaleSub",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "SaleMain",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleSub_ID",
                schema: "dbo",
                table: "SaleSub",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleMain_ID",
                schema: "dbo",
                table: "SaleMain",
                column: "ID",
                unique: true);
        }
    }
}
