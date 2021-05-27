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
    public class ControlAccRepository : IControlAccRepository
    {
        private readonly AppDbContext _context;
        DataTable dtControl;

        public ControlAccRepository( AppDbContext context)
        {
            this._context = context;
            initDT();

        }

        public void initDT()
        {

            dtControl = new DataTable();
            dtControl.Columns.Add("EDate", typeof(DateTime));
            dtControl.Columns.Add("CateAccID", typeof(int));
            dtControl.Columns.Add("CompID", typeof(int));
            dtControl.Columns.Add("Code", typeof(string));
            dtControl.Columns.Add("Title", typeof(string));
            dtControl.Columns.Add("TitleU", typeof(string));
            dtControl.Columns.Add("BranchID", typeof(int));


        }



        public async  Task<string> SaveControlAcc(adControlAccountsVM controlAcc)
        {
            if (dtControl.Rows.Count > 0)
            {
                dtControl.Rows.Clear();
            }
            try
            {
                var maxCode = "";
                if (controlAcc.CateAccID == controlAcc.tmpCateAccID)
                {
                    maxCode = controlAcc.Code;
                }

                else
                {

                    maxCode = this._context.adControlAccounts.Where(x => x.CateAccID == controlAcc.CateAccID).Max(x => x.Code);

                    if (maxCode == null)
                    {
                        maxCode = "00";
                    }
                    int MC = Convert.ToInt32(maxCode.ToString()) + 1;
                    if (Convert.ToString(MC).Length == 1)
                        maxCode = "0" + MC.ToString();
                    else 
                        maxCode = MC.ToString();
                    
                }

                controlAcc.Code = maxCode;

                DataRow row = dtControl.NewRow();

                row["EDate"] = controlAcc.EDate;
                row["CateAccID"] = controlAcc.CateAccID;
                row["CompID"] = controlAcc.CompID;
                row["Code"] = controlAcc.Code;
                row["Title"] = controlAcc.Title;
                row["TitleU"] = controlAcc.TitleU;
                row["BranchID"] = controlAcc.BranchID;




                dtControl.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_ControlAccounts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ControlAcc", SqlDbType.Structured).Value = dtControl;
                    cmd.Parameters.Add("@CtrlAccID", SqlDbType.BigInt).Value = controlAcc.CtrlAccID;



                    var returnParameter = cmd.Parameters.Add("@CtrlAccID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();


                    return "Control Account Saved Successfully for ID:" + result;



                }

            }
            catch (Exception ex)
            {

                throw new Exception("Insert Failed");
            }

        }
        public async Task<string> DeleteControlAcc(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_ControlAcc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CtrlAccID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }

        public async Task<IList<adControlAccountsVM>> GetAllControlAcc()
        {
            var list = await this._context.adControlAccounts.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<adControlAccountsVM> controlAccList = JsonConvert.DeserializeObject<IList<adControlAccountsVM>>(json);

            return controlAccList;
        }

        public async Task<adControlAccountsVM> GetControllAccByID(int Id)
        {
            adControlAccountsVM cntrlObj = new adControlAccountsVM();


            var mainComp = await this._context.adControlAccounts.Where(x => x.CtrlAccID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainComp);

            cntrlObj = JsonConvert.DeserializeObject<adControlAccountsVM>(mainjson);



            return cntrlObj;
        }



        public async Task<adControlAccountsLookUpVM> GetLookUpsforCtrlAcc()
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@CateAccLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}



                };


                var sql = "EXEC[GetSearchLookUpsControlAcc] @CateAccLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0]);



                adControlAccountsLookUpVM lookups = new adControlAccountsLookUpVM();


                lookups.adcontrolaccountscategorylookup = JsonConvert.DeserializeObject<IList<adControlAccountsCategoryLookUpVM>>(@params[0].Value.ToString());


                con.Close();


                return lookups;



            }
        }


    }
}
