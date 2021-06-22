using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GodownRpository : IGodownRepository
    {
        private readonly AppDbContext _context;
        DataTable dtGodown;
        public GodownRpository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {
         

            dtGodown = new DataTable();
            dtGodown.Columns.Add("GoName", typeof(string));
            dtGodown.Columns.Add("GoNameU", typeof(string));
            dtGodown.Columns.Add("ShortName", typeof(string));
            dtGodown.Columns.Add("SortOrder", typeof(int));
            dtGodown.Columns.Add("PhoneNo", typeof(string));
            dtGodown.Columns.Add("AddressU", typeof(string));
            dtGodown.Columns.Add("Address", typeof(string));
            dtGodown.Columns.Add("Description", typeof(string));
            dtGodown.Columns.Add("CompanyID", typeof(int));
            dtGodown.Columns.Add("BranchID", typeof(int));
            dtGodown.Columns.Add("OperatorID", typeof(int));

           

    }

        public async Task<string> SaveGodowns(GoDownVM godown)
        {
            if (dtGodown.Rows.Count > 0)
            {
                dtGodown.Rows.Clear();
            }
            try
            {
      


               DataRow row = dtGodown.NewRow();
                row["GoName"] = godown.GoName;
                row["GoNameU"] = godown.GoNameU;
                row["ShortName"] = godown.ShortName;
                row["SortOrder"] = godown.SortOrder;
                row["PhoneNo"] = godown.PhoneNo;
                row["AddressU"] = godown.AddressU;
                row["Address"] = godown.Address;
                row["Description"] = godown.Description;
                row["CompanyID"] = godown.CompanyID;
                row["BranchID"] = godown.BranchID;
                row["OperatorID"] = godown.OperatorID;


                dtGodown.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_Godown", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Godown", SqlDbType.Structured).Value = dtGodown;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = godown.EDate;
                    cmd.Parameters.Add("@GoCid", SqlDbType.BigInt).Value = godown.GoCid;



                    var returnParameter = cmd.Parameters.Add("@GoCid", SqlDbType.BigInt);
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

        public async Task<IList<GoDownVM>> GetAllGodowns(int CompanyID, int BranchID)
        {
            var list = await this._context.GoDown.Where(x => x.Del == 0 && x.CompanyID == CompanyID && x.BranchID == BranchID).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<GoDownVM> godownList = JsonConvert.DeserializeObject<IList<GoDownVM>>(json);

            return godownList;
        }

        public async Task<GoDownVM> GetGodownByID(int Id, int CompanyID, int BranchID)
        {
            GoDownVM godownObj = new GoDownVM();


            var mainGodown = await this._context.GoDown.Where(x => x.GoCid == Id && x.CompanyID == CompanyID && x.BranchID == BranchID).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainGodown);

            godownObj = JsonConvert.DeserializeObject<GoDownVM>(mainjson);



            return godownObj;
        }

        public async Task<string> DeleteGodown(int Id, int CompanyID, int BranchID)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_Godown", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@GoCid", SqlDbType.BigInt).Value = Id;
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = CompanyID;
                cmd.Parameters.Add("@BranchId", SqlDbType.BigInt).Value = BranchID;

                var returnParameter = cmd.Parameters.Add("@GoCid", SqlDbType.BigInt);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                var result = returnParameter.Value;
                con.Close();

                return result.ToString();


            }
        }


    }
}
