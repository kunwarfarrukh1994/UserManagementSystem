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
                name: "adAccounts",
                schema: "dbo",
                columns: table => new
                {
                    AccID = table.Column<int>(type: "int", nullable: false),
                    CateAccID = table.Column<int>(type: "int", nullable: false),
                    CtrlAccID = table.Column<int>(type: "int", nullable: false),
                    MainGroupID = table.Column<int>(type: "int", nullable: false),
                    GroupAccID = table.Column<int>(type: "int", nullable: false),
                    compID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccFlexCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccTypeID = table.Column<int>(type: "int", nullable: false),
                    AccTransTypeID = table.Column<int>(type: "int", nullable: false),
                    isDeptAcc = table.Column<bool>(type: "bit", nullable: false),
                    isLocationAcc = table.Column<bool>(type: "bit", nullable: false),
                    isAutoOpenBal = table.Column<bool>(type: "bit", nullable: false),
                    isFreeze = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    accCodeID = table.Column<int>(type: "int", nullable: false),
                    accCodeDr = table.Column<int>(type: "int", nullable: false),
                    accCodeCr = table.Column<int>(type: "int", nullable: false),
                    cityID = table.Column<int>(type: "int", nullable: false),
                    areaID = table.Column<int>(type: "int", nullable: false),
                    accAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ntNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isNtnActive = table.Column<bool>(type: "bit", nullable: false),
                    accOpenBal = table.Column<float>(type: "real", nullable: false),
                    opBalType = table.Column<int>(type: "int", nullable: false),
                    accCreditLimit = table.Column<float>(type: "real", nullable: false),
                    accURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "adCategoryAccounts",
                schema: "dbo",
                columns: table => new
                {
                    CateAccID = table.Column<int>(type: "int", nullable: false),
                    FinStatementTypeID = table.Column<int>(type: "int", nullable: false),
                    compID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accHeadID = table.Column<int>(type: "int", nullable: false),
                    accHeadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "adControlAccounts",
                schema: "dbo",
                columns: table => new
                {
                    CtrlAccID = table.Column<int>(type: "int", nullable: false),
                    CateAccID = table.Column<int>(type: "int", nullable: false),
                    CompID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accCodeId = table.Column<int>(type: "int", nullable: false),
                    accCodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "adFinancialStatementCategories",
                schema: "dbo",
                columns: table => new
                {
                    FinStatementCateID = table.Column<int>(type: "int", nullable: false),
                    compID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "adFinancialStatementTypes",
                schema: "dbo",
                columns: table => new
                {
                    FinStatementTypeID = table.Column<int>(type: "int", nullable: false),
                    compID = table.Column<int>(type: "int", nullable: false),
                    FinStatementCateID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "adGroupAccounts",
                schema: "dbo",
                columns: table => new
                {
                    GroupAccID = table.Column<int>(type: "int", nullable: false),
                    CateAccID = table.Column<int>(type: "int", nullable: false),
                    CtrlAccID = table.Column<int>(type: "int", nullable: false),
                    MainGroupID = table.Column<int>(type: "int", nullable: false),
                    CompID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccTypeID = table.Column<int>(type: "int", nullable: false),
                    isChild = table.Column<bool>(type: "bit", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    isCoaItem = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "adMainGroupAccounts",
                schema: "dbo",
                columns: table => new
                {
                    MainGroupID = table.Column<int>(type: "int", nullable: false),
                    CateAccID = table.Column<int>(type: "int", nullable: false),
                    CtrlAccID = table.Column<int>(type: "int", nullable: false),
                    compID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    CID = table.Column<int>(type: "int", nullable: false),
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
                name: "cdCompanies",
                schema: "dbo",
                columns: table => new
                {
                    companyID = table.Column<int>(type: "int", nullable: false),
                    companyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    businessNatureID = table.Column<int>(type: "int", nullable: false),
                    corporateLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    corporatePWD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companySTN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyNTN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinID = table.Column<int>(type: "int", nullable: false),
                    CityNameU = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CodeCodingMain",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
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
                    PSaleRate = table.Column<float>(type: "real", nullable: false),
                    OperatorID = table.Column<int>(type: "int", nullable: false)
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
                name: "Customers",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    CID = table.Column<int>(type: "int", nullable: false),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsappNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    CustType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentID1 = table.Column<int>(type: "int", nullable: false),
                    AgentID2 = table.Column<int>(type: "int", nullable: true),
                    CreditLimit = table.Column<float>(type: "real", nullable: false),
                    OpBal = table.Column<float>(type: "real", nullable: false),
                    SAccID = table.Column<int>(type: "int", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
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
                name: "GoDown",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    GoCid = table.Column<int>(type: "int", nullable: false),
                    GoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Pandi",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: true),
                    CID = table.Column<int>(type: "int", nullable: false),
                    PandiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
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
                    ID = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ID",
                schema: "dbo",
                table: "Agents",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_ID",
                schema: "dbo",
                table: "City",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CodeCodingMain_ID",
                schema: "dbo",
                table: "CodeCodingMain",
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
                name: "IX_Customers_ID",
                schema: "dbo",
                table: "Customers",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoDown_ID",
                schema: "dbo",
                table: "GoDown",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pandi_ID",
                schema: "dbo",
                table: "Pandi",
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

            migrationBuilder.CreateIndex(
                name: "IX_SaleParty_ID",
                schema: "dbo",
                table: "SaleParty",
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

            migrationBuilder.CreateIndex(
                name: "IX_SaleSub_ID",
                schema: "dbo",
                table: "SaleSub",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SaleSubWarehouse_ID",
                schema: "dbo",
                table: "SaleSubWarehouse",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adAccounts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adCategoryAccounts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adControlAccounts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adFinancialStatementCategories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adFinancialStatementTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adGroupAccounts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adMainGroupAccounts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Agents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "cdCompanies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "City",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeCodingMain",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeCodingProduction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeCodingWarehouse",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GoDown",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pandi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SaleMain",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SaleParty",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesOutSourceItems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SaleSub",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SaleSubWarehouse",
                schema: "dbo");
        }
    }
}
