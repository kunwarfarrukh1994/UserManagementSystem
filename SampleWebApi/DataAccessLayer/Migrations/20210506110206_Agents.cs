using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Agents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                schema: "dbo",
                table: "GoDown",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "OperatorID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Agents",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    CID = table.Column<float>(type: "real", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    OperatorID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CodeCodingProduction",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    CID = table.Column<float>(type: "real", nullable: false),
                    CPID = table.Column<float>(type: "real", nullable: false),
                    Gatta = table.Column<float>(type: "real", nullable: false),
                    TitleMaterial = table.Column<float>(type: "real", nullable: false),
                    Astar = table.Column<float>(type: "real", nullable: false),
                    InnerMaterial = table.Column<float>(type: "real", nullable: false),
                    Pages = table.Column<float>(type: "real", nullable: false),
                    Printing = table.Column<float>(type: "real", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CodeCodingWarehouse",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    CID = table.Column<float>(type: "real", nullable: false),
                    CWID = table.Column<float>(type: "real", nullable: false),
                    GodownID = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SalesOutSourceItems",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    SMID = table.Column<int>(type: "int", nullable: false),
                    SOID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_subAccount_ID",
                schema: "dbo",
                table: "subAccount",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleSubWarehouse_ID",
                schema: "dbo",
                table: "SaleSubWarehouse",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SaleParty_ID",
                schema: "dbo",
                table: "SaleParty",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoDown_ID",
                schema: "dbo",
                table: "GoDown",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CodeCodingMain_ID",
                schema: "dbo",
                table: "CodeCodingMain",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ID",
                schema: "dbo",
                table: "Agents",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CodeCodingProduction_ID",
                schema: "dbo",
                table: "CodeCodingProduction",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CodeCodingWarehouse_ID",
                schema: "dbo",
                table: "CodeCodingWarehouse",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOutSourceItems_ID",
                schema: "dbo",
                table: "SalesOutSourceItems",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeCodingProduction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeCodingWarehouse",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesOutSourceItems",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_subAccount_ID",
                schema: "dbo",
                table: "subAccount");

            migrationBuilder.DropIndex(
                name: "IX_SaleSubWarehouse_ID",
                schema: "dbo",
                table: "SaleSubWarehouse");

            migrationBuilder.DropIndex(
                name: "IX_SaleParty_ID",
                schema: "dbo",
                table: "SaleParty");

            migrationBuilder.DropIndex(
                name: "IX_GoDown_ID",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropIndex(
                name: "IX_CodeCodingMain_ID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "OperatorID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "dbo",
                table: "GoDown",
                newName: "id");
        }
    }
}
