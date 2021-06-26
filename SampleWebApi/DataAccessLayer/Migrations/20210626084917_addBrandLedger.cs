using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addBrandLedger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandLedger",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    LG_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LG_Code = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LG_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrancID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrandId = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtyIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtyOut = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PartyID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommRS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommPer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleManID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManagerID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StoreID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BCID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Narat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandLedger",
                schema: "dbo");
        }
    }
}
