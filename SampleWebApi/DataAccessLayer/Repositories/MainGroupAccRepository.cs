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
    public class MainGroupAccRepository : IMainGroupAccRepository
    {
        private readonly AppDbContext _context;
        DataTable dtMainGroupAcc;
        public MainGroupAccRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {
            dtMainGroupAcc = new DataTable();

            //dtMainGroupAcc.Columns.Add("EDate", typeof(DateTime));
            dtMainGroupAcc.Columns.Add("CateAccID", typeof(int));
            dtMainGroupAcc.Columns.Add("CtrlAccID", typeof(int));
            dtMainGroupAcc.Columns.Add("compID", typeof(int));
            dtMainGroupAcc.Columns.Add("Code", typeof(string));
            dtMainGroupAcc.Columns.Add("Title", typeof(string));
            dtMainGroupAcc.Columns.Add("TitleU", typeof(string));
            dtMainGroupAcc.Columns.Add("BranchID", typeof(int));

        }

        public async Task<string> SaveGroupAcc(adMainGroupAccountsVM groupAcc)
        {
            if(dtMainGroupAcc.Rows.Count > 0) 
            {
                dtMainGroupAcc.Rows.Clear();
            }
            try
            {
                var maxCode = "";
                //if (groupAcc.MainGroupID == 0) 
                if (groupAcc.CtrlAccID == groupAcc.tempCtrlAccID)
                {
                    maxCode = groupAcc.tempCode;
                }
                else
                { 

                    maxCode = this._context.adMainGroupAccounts.Where(x => x.CtrlAccID == groupAcc.CtrlAccID).Max(x => x.Code);

                    if (maxCode == null)
                    {
                        maxCode = "000";
                    }
                    int MC = Convert.ToInt32(maxCode.ToString()) + 1;
                    if (Convert.ToString(MC).Length == 1)
                        maxCode = "00" + MC.ToString();
                    else if (Convert.ToString(MC).Length == 2)
                        maxCode = "0" + MC.ToString();
                    else
                        maxCode = MC.ToString();

                }



                groupAcc.Code = maxCode;



                DataRow row = dtMainGroupAcc.NewRow();

                row["CateAccID"] = groupAcc.CateAccID;
                row["CtrlAccID"] = groupAcc.CtrlAccID;
                row["compID"] = groupAcc.compID;
                row["Code"] = groupAcc.Code;
                row["Title"] = groupAcc.Title;
                row["TitleU"] = groupAcc.TitleU;
                row["BranchID"] = groupAcc.BranchID;

                dtMainGroupAcc.Rows.InsertAt(row, 0);

                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                    SqlCommand cmd = null;

                    //cn = new SqlConnection(CS);


                    cmd = new SqlCommand("dbo.Insert_MainGroupAcc", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MainGroupAcc", SqlDbType.Structured).Value = dtMainGroupAcc;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = groupAcc.EDate;
                    cmd.Parameters.Add("@MainGroupID", SqlDbType.BigInt).Value = groupAcc.MainGroupID;



                    var returnParameter = cmd.Parameters.Add("@MainGroupID", SqlDbType.BigInt);
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


        public async Task<adMainGroupAccountsLookUpsVM> GetLookUpsforGroupAcc()
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@CtrlAccLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}
                       


                };


                var sql = "EXEC[MainGroupAccGetSearchLookUps] @CtrlAccLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0]);



                adMainGroupAccountsLookUpsVM lookups = new adMainGroupAccountsLookUpsVM();


                lookups.admaingroupaccountsctrlacclookup = JsonConvert.DeserializeObject<IList<adMainGroupAccountsCtrlAccLookUpVM>>(@params[0].Value.ToString());

             
                con.Close();


                return lookups;



            }
        }


        public async Task<IList<adMainGroupAccountsVM>> GetAllGroupAccounts()
        {
            var list = await this._context.adMainGroupAccounts.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<adMainGroupAccountsVM> grpAccList = JsonConvert.DeserializeObject<IList<adMainGroupAccountsVM>>(json);

            return grpAccList;
        }

        public async Task<adMainGroupAccountsVM> GetGroupAccByID(int Id)
        {
            adMainGroupAccountsVM mainGrpObj = new adMainGroupAccountsVM();


            var mainSchool = await this._context.adMainGroupAccounts.Where(x => x.MainGroupID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainSchool);

            mainGrpObj = JsonConvert.DeserializeObject<adMainGroupAccountsVM>(mainjson);



            return mainGrpObj;
        }

        public async Task<string> DeleteGroupAcc(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_MainGroupAcc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@MainGroupID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }


    }
}
