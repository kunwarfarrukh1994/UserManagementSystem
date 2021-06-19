﻿using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SaleReturnRepository : ISaleReturnRepository
    {
        private readonly AppDbContext _context;
        DataTable dtSaleReturnMain, dtSaleReturnSub;
        public SaleReturnRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

     

        public void initDT()
        {
            dtSaleReturnMain = new DataTable();
            dtSaleReturnMain.Columns.Add("SMID", typeof(int));
            dtSaleReturnMain.Columns.Add("AccID", typeof(int));
            dtSaleReturnMain.Columns.Add("Remarks", typeof(string));
            dtSaleReturnMain.Columns.Add("SReturn", typeof(Single));
            dtSaleReturnMain.Columns.Add("DiscountUser", typeof(Single));
            dtSaleReturnMain.Columns.Add("CompanyID", typeof(int));
            dtSaleReturnMain.Columns.Add("BranchID", typeof(int));
            dtSaleReturnMain.Columns.Add("LocationID", typeof(int));
            dtSaleReturnMain.Columns.Add("OperatorID", typeof(int));

            dtSaleReturnSub = new DataTable();
            dtSaleReturnSub.Columns.Add("SMID", typeof(int));
            dtSaleReturnSub.Columns.Add("ItemD", typeof(int));
            dtSaleReturnSub.Columns.Add("itemDescription", typeof(string));
            dtSaleReturnSub.Columns.Add("Rate", typeof(Single));
            dtSaleReturnSub.Columns.Add("Qty", typeof(Single));
            dtSaleReturnSub.Columns.Add("GodownID", typeof(int));
            dtSaleReturnSub.Columns.Add("DisPer", typeof(Single));
            dtSaleReturnSub.Columns.Add("NetTotal", typeof(Single));
            dtSaleReturnSub.Columns.Add("CompanyID", typeof(int));
            dtSaleReturnSub.Columns.Add("BranchID", typeof(int));



        }

        public async Task<SaleReturnLookUpsVM> GetSaleReturnByID(int Id, int CompanyID, int BranchID)
        {
            SqlParameter[] @outparams =
                   {
                       new SqlParameter("@SaleMainLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@SaleSubLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@GodownLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},

                };
            SqlParameter[] @inparams =
                {
                    new SqlParameter("@SMID", Id),
                    new SqlParameter("@CompanyID", CompanyID),
                    new SqlParameter("@BranchID", BranchID)
                };
            await DBMethods.EXECUTE_SP(@inparams, @outparams, "GetSaleDetailByID", this._context);

            SaleReturnMainVM SRMain = new SaleReturnMainVM();
            SaleReturnLookUpsVM lookups = new SaleReturnLookUpsVM();
            lookups.salereturnmainlookup = JsonConvert.DeserializeObject<IList<SaleReturnMainLookUpVM>>(@outparams[0].Value.ToString());
            lookups.salereturnsublookup = JsonConvert.DeserializeObject<IList<SaleReturnSubLookUpVM>>(@outparams[1].Value.ToString());
            lookups.salereturngodownlookup = JsonConvert.DeserializeObject<IList<SaleReturnGodownLookUpVM>>(@outparams[2].Value.ToString());


            return lookups;
        }

        public async Task<string> SaveSaleReturn(SaleReturnMainVM salereturnmain)
        {
            if (salereturnmain.SaleReturn.Count > 0)
            {
                try
                {
                    DataRow row = dtSaleReturnMain.NewRow();

                    row["SMID"] = salereturnmain.SMID;
                    row["AccID"] = salereturnmain.AccID;
                    row["Remarks"] = salereturnmain.Remarks;
                    row["SReturn"] = salereturnmain.SReturn;
                    row["DiscountUser"] = salereturnmain.DiscountUser;
                    row["CompanyID"] = salereturnmain.CompanyID;
                    row["BranchID"] = salereturnmain.BranchID;
                    row["LocationID"] = salereturnmain.LocationID;
                    row["OperatorID"] = salereturnmain.OperatorID;

                    dtSaleReturnMain.Rows.InsertAt(row, 0);

                    int i = 0;
                    foreach (var detail in salereturnmain.SaleReturn)
                    {
                        DataRow srow = dtSaleReturnSub.NewRow();
                        srow["SMID"] = detail.SMID;
                        srow["ItemD"] = detail.ItemD;
                        srow["itemDescription"] = detail.itemDescription;
                        srow["Rate"] = detail.Rate;
                        srow["Qty"] = detail.Qty;
                        srow["GodownID"] = detail.GodownID;
                        srow["DisPer"] = detail.DisPer;
                        srow["NetTotal"] = detail.NetTotal;
                        srow["CompanyID"] = detail.CompanyID;
                        srow["BranchID"] = detail.BranchID;
                        

                        dtSaleReturnSub.Rows.InsertAt(srow, i);

                    }

                    using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                    {
                        //string CS = @"Data Source=CYBERSPACE\EAS;Initial Catalog=Vanya-bak;Persist Security Info=True;User ID=sa;Password=risay";
                        //SqlConnection cn = null;
                        SqlCommand cmd = null;

                        //cn = new SqlConnection(CS);


                        cmd = new SqlCommand("dbo.Insert_SaleReturn", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@SRMain", SqlDbType.Structured).Value = dtSaleReturnMain;
                        cmd.Parameters.Add("@SRSub", SqlDbType.Structured).Value = dtSaleReturnSub;
                        cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = DateTime.Now; //salereturnmain.EDate;
                        cmd.Parameters.Add("@SRID", SqlDbType.BigInt).Value = salereturnmain.SRID;



                        var returnParameter = cmd.Parameters.Add("@SRId", SqlDbType.BigInt);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        con.Open();
                        await cmd.ExecuteNonQueryAsync();
                        var result = returnParameter.Value;
                        con.Close();

                        return result.ToString();
                        //return "Record Saved Successfully for ID:" + result;



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
