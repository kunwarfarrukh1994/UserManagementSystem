using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly AppDbContext _context;
        DataTable dtSalesMain, dtSalesSub;
        public SalesRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {
            dtSalesMain = new DataTable();
            dtSalesMain.Columns.Add("BillNo", typeof(string));
            dtSalesMain.Columns.Add("SAccID", typeof(int));
            dtSalesMain.Columns.Add("GSale", typeof(Single));
            dtSalesMain.Columns.Add("SReturn", typeof(Single));
            dtSalesMain.Columns.Add("DiscountUser", typeof(Single));
            dtSalesMain.Columns.Add("CashRece", typeof(Single));
            dtSalesMain.Columns.Add("ChangeReturn", typeof(Single));
            dtSalesMain.Columns.Add("AgentID", typeof(int));
            dtSalesMain.Columns.Add("Goods", typeof(string));
            dtSalesMain.Columns.Add("ContactNo", typeof(string));
            dtSalesMain.Columns.Add("CashAddress", typeof(string));
            dtSalesMain.Columns.Add("Pandi", typeof(string));
            dtSalesMain.Columns.Add("Remarks", typeof(string));
            dtSalesMain.Columns.Add("Packet", typeof(Single));
            dtSalesMain.Columns.Add("PKTQty", typeof(Single));
            dtSalesMain.Columns.Add("CompanyID", typeof(int));
            dtSalesMain.Columns.Add("OperatorID", typeof(int));
            dtSalesMain.Columns.Add("BranchID", typeof(int));
            dtSalesMain.Columns.Add("LocationID", typeof(int));

            dtSalesSub = new DataTable();
            dtSalesSub.Columns.Add("ItemID", typeof(int));
            dtSalesSub.Columns.Add("ItemDescription", typeof(string));
            dtSalesSub.Columns.Add("Unit", typeof(string));
            dtSalesSub.Columns.Add("Packet", typeof(Single));
            dtSalesSub.Columns.Add("PktQty", typeof(Single));
            dtSalesSub.Columns.Add("Qty", typeof(Single));
            dtSalesSub.Columns.Add("Rate", typeof(Single));
            dtSalesSub.Columns.Add("DisRS", typeof(Single));
            dtSalesSub.Columns.Add("DisPer", typeof(Single));
            dtSalesSub.Columns.Add("NetRate", typeof(Single));
            dtSalesSub.Columns.Add("Amount", typeof(Single));
            dtSalesSub.Columns.Add("STRG", typeof(string));
            dtSalesSub.Columns.Add("CompanyID", typeof(int));
            dtSalesSub.Columns.Add("BranchID", typeof(int));

        }


        public void GetSale()
        {

        }

        public async Task<string> InsertSales(SalesMainVM salesmain)
        {
            initDT();
            if (dtSalesMain.Rows.Count > 0)
            {
                dtSalesMain.Rows.Clear();
            }

            if (salesmain.SaleDetail.Count > 0)
            {
                try
                {
                    DataRow row = dtSalesMain.NewRow();

                    row["BillNo"] = salesmain.BillNo;
                    row["SAccID"] = salesmain.SAccID;
                    row["GSale"] = salesmain.GSale;
                    row["SReturn"] = salesmain.SReturn;
                    row["DiscountUser"] = salesmain.DiscountUser;
                    row["CashRece"] = salesmain.CashRece;
                    row["ChangeReturn"] = salesmain.ChangeReturn;
                    row["AgentID"] = salesmain.AgentID;
                    row["Goods"] = salesmain.Goods;
                    row["ContactNo"] = salesmain.ContactNo;
                    row["CashAddress"] = salesmain.CashAddress;
                    row["Pandi"] = salesmain.Pandi;
                    row["Remarks"] = salesmain.Remarks;
                    row["Packet"] = salesmain.Packet;
                    row["PKTQty"] = salesmain.PKTQty;
                    row["CompanyID"] = salesmain.CompanyID;
                    row["OperatorID"] = salesmain.OperatorID;
                    row["BranchID"] = salesmain.BranchID;
                    row["LocationID"] = salesmain.LocationID;

                    dtSalesMain.Rows.InsertAt(row, 0);


                    int i = 0;
                    foreach (var detail in salesmain.SaleDetail)
                    {

                        DataRow srow = dtSalesSub.NewRow();

                        srow["ItemID"] = detail.ItemID;
                        srow["ItemDescription"] = detail.ItemDescription;
                        srow["Unit"] = detail.Unit;
                        srow["Packet"] = detail.Packet;
                        srow["PktQty"] = detail.PktQty;
                        srow["Qty"] = detail.Qty;
                        srow["Rate"] = detail.Rate;
                        srow["DisRS"] = detail.DisRS;
                        srow["DisPer"] = detail.DisPer;
                        srow["NetRate"] = detail.NetRate;
                        srow["Amount"] = detail.Amount;
                        srow["STRG"] = detail.STRG;
                        srow["CompanyID"] = detail.CompanyID;
                        srow["BranchID"] = detail.BranchID;

                        dtSalesSub.Rows.InsertAt(srow, i);

                        i++;
                    }



                    using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                    {
                        //string CS = @"Data Source=CYBERSPACE\EAS;Initial Catalog=Vanya-bak;Persist Security Info=True;User ID=sa;Password=risay";
                        //SqlConnection cn = null;
                        SqlCommand cmd = null;
                        
                        //cn = new SqlConnection(CS);


                        cmd = new SqlCommand("dbo.Insert_Sales", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@SMain", SqlDbType.Structured).Value = dtSalesMain;
                        cmd.Parameters.Add("@SSub", SqlDbType.Structured).Value = dtSalesSub;
                        cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@SmId", SqlDbType.BigInt).Value = salesmain.SMID;

                        

                        var returnParameter = cmd.Parameters.Add("@SmId", SqlDbType.BigInt);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        var result = returnParameter.Value;
                        con.Close();


                        return "Record Saved Successfully";



                    }


                }
                catch (Exception ex)
                {

                    throw new Exception("Insert Failed");
                }




            }

            return "Enter Valid Data First";

        }
    }
}
