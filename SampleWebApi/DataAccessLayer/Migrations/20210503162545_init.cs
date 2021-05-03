using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "CodeCodingMain",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CID = table.Column<float>(type: "real", nullable: false),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DpttCID = table.Column<float>(type: "real", nullable: false),
                    ItemCID = table.Column<float>(type: "real", nullable: false),
                    SubCategoryCID = table.Column<float>(type: "real", nullable: false),
                    DesignNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MadeIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyID = table.Column<float>(type: "real", nullable: false),
                    PurchaseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommRS = table.Column<float>(type: "real", nullable: false),
                    CommPer = table.Column<float>(type: "real", nullable: false),
                    VolumeCID = table.Column<float>(type: "real", nullable: false),
                    ReOrderLevel = table.Column<float>(type: "real", nullable: false),
                    Ignore = table.Column<int>(type: "int", nullable: false),
                    CostRate = table.Column<float>(type: "real", nullable: false),
                    SaleRate = table.Column<float>(type: "real", nullable: false),
                    OpenQty = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPer = table.Column<float>(type: "real", nullable: false),
                    DiscountRs = table.Column<float>(type: "real", nullable: false),
                    OpeningBit = table.Column<short>(type: "smallint", nullable: false),
                    PacketQty = table.Column<float>(type: "real", nullable: false),
                    Packet = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    BatchFile = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    FinID = table.Column<int>(type: "int", nullable: false),
                    BCID = table.Column<float>(type: "real", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false),
                    Colours = table.Column<int>(type: "int", nullable: false),
                    GRNCID = table.Column<float>(type: "real", nullable: false),
                    Block = table.Column<int>(type: "int", nullable: false),
                    T1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuitLength = table.Column<float>(type: "real", nullable: false),
                    GRNDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PCostRate = table.Column<float>(type: "real", nullable: false),
                    PSaleRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GoDown",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    GoCid = table.Column<int>(type: "int", nullable: false),
                    GoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SaleMain",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    SMID = table.Column<int>(type: "int", nullable: true),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAccID = table.Column<int>(type: "int", nullable: true),
                    GSale = table.Column<float>(type: "real", nullable: true),
                    SReturn = table.Column<float>(type: "real", nullable: true),
                    DiscountUser = table.Column<float>(type: "real", nullable: true),
                    CashRece = table.Column<float>(type: "real", nullable: true),
                    ChqRece = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangeReturn = table.Column<float>(type: "real", nullable: true),
                    BiltyExp = table.Column<float>(type: "real", nullable: true),
                    FreightExp = table.Column<float>(type: "real", nullable: true),
                    OtherExp = table.Column<float>(type: "real", nullable: true),
                    CommissionExp = table.Column<float>(type: "real", nullable: true),
                    CreditDays = table.Column<int>(type: "int", nullable: true),
                    AgentID = table.Column<int>(type: "int", nullable: true),
                    AgentID2 = table.Column<int>(type: "int", nullable: true),
                    BiltyNo = table.Column<int>(type: "int", nullable: true),
                    Goods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pandi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txt1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txt2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txt3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    N1 = table.Column<int>(type: "int", nullable: true),
                    N2 = table.Column<int>(type: "int", nullable: true),
                    N3 = table.Column<int>(type: "int", nullable: true),
                    Packet = table.Column<float>(type: "real", nullable: true),
                    PKTQty = table.Column<float>(type: "real", nullable: true),
                    Post = table.Column<int>(type: "int", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    OperatorID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    Del = table.Column<int>(type: "int", nullable: true),
                    Sync = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SaleParty",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<float>(type: "real", nullable: false),
                    CID = table.Column<float>(type: "real", nullable: false),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    BCID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false),
                    PartyConcate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NTN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleMan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditLimit = table.Column<float>(type: "real", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlACCID = table.Column<float>(type: "real", nullable: false),
                    OPBal = table.Column<float>(type: "real", nullable: false),
                    BalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatorID = table.Column<int>(type: "int", nullable: false),
                    N1 = table.Column<short>(type: "smallint", nullable: false),
                    N2 = table.Column<short>(type: "smallint", nullable: false),
                    N3 = table.Column<short>(type: "smallint", nullable: false),
                    N4 = table.Column<short>(type: "smallint", nullable: false),
                    PartyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SaleSub",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    SMID = table.Column<int>(type: "int", nullable: true),
                    SSID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Packet = table.Column<float>(type: "real", nullable: true),
                    PktQty = table.Column<float>(type: "real", nullable: true),
                    Qty = table.Column<float>(type: "real", nullable: true),
                    Rate = table.Column<float>(type: "real", nullable: true),
                    DisRS = table.Column<float>(type: "real", nullable: true),
                    DisPer = table.Column<float>(type: "real", nullable: true),
                    NetRate = table.Column<float>(type: "real", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: true),
                    STRG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommisionRs = table.Column<float>(type: "real", nullable: true),
                    CommisionPer = table.Column<float>(type: "real", nullable: true),
                    Bardana = table.Column<float>(type: "real", nullable: true),
                    Tulai = table.Column<float>(type: "real", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    Del = table.Column<int>(type: "int", nullable: true),
                    Sync = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SaleSubWarehouse",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    SMID = table.Column<int>(type: "int", nullable: false),
                    SSID = table.Column<int>(type: "int", nullable: false),
                    SWID = table.Column<int>(type: "int", nullable: false),
                    GodownID = table.Column<int>(type: "int", nullable: true),
                    ItemID = table.Column<int>(type: "int", nullable: true),
                    Packet = table.Column<float>(type: "real", nullable: true),
                    PktQty = table.Column<float>(type: "real", nullable: true),
                    Qty = table.Column<float>(type: "real", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    Del = table.Column<int>(type: "int", nullable: true),
                    Sync = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "subAccount",
                schema: "dbo",
                columns: table => new
                {
                    SAccName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinID = table.Column<int>(type: "int", nullable: false),
                    SAccDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccCodeID = table.Column<int>(type: "int", nullable: false),
                    AccCodeDr = table.Column<int>(type: "int", nullable: false),
                    AccCodeCr = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpBal = table.Column<float>(type: "real", nullable: false),
                    Baltype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<short>(type: "smallint", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    SAccNameU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAccID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleMain_ID",
                schema: "dbo",
                table: "SaleMain",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SaleSub_ID",
                schema: "dbo",
                table: "SaleSub",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeCodingMain",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GoDown",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SaleMain",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SaleParty",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SaleSub",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SaleSubWarehouse",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "subAccount",
                schema: "dbo");
        }
    }
}
