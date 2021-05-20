using BussinessModels.DBModels;
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
    public class SubAccountsRepository : ISubAccountsRepository
    {
        private readonly AppDbContext _context;
        DataTable dtSubAcc;

        public SubAccountsRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {
       

            dtSubAcc = new DataTable();
            dtSubAcc.Columns.Add("CateAccID", typeof(int));
            dtSubAcc.Columns.Add("CtrlAccID", typeof(int));
            dtSubAcc.Columns.Add("MainGroupID", typeof(int));
            dtSubAcc.Columns.Add("GroupAccID", typeof(int));
            dtSubAcc.Columns.Add("compID", typeof(int));
            dtSubAcc.Columns.Add("Code", typeof(string));
            dtSubAcc.Columns.Add("AccFlexCode", typeof(string));
            dtSubAcc.Columns.Add("Title", typeof(string));
            dtSubAcc.Columns.Add("TitleU", typeof(string));
            dtSubAcc.Columns.Add("AccTypeID", typeof(int));
            dtSubAcc.Columns.Add("AccTransTypeID", typeof(int));
            dtSubAcc.Columns.Add("isDeptAcc", typeof(bool));
            dtSubAcc.Columns.Add("isLocationAcc", typeof(bool));
            dtSubAcc.Columns.Add("isAutoOpenBal", typeof(bool));
            dtSubAcc.Columns.Add("isFreeze", typeof(bool));
            dtSubAcc.Columns.Add("isActive", typeof(bool));

             dtSubAcc.Columns.Add("accCodeDr", typeof(int));
            dtSubAcc.Columns.Add("accCodeCr", typeof(int));
            dtSubAcc.Columns.Add("cityID", typeof(int));
            dtSubAcc.Columns.Add("areaID", typeof(int));
            dtSubAcc.Columns.Add("accAddress", typeof(string));
            dtSubAcc.Columns.Add("telephone", typeof(string));
            dtSubAcc.Columns.Add("stNumber", typeof(string));
            dtSubAcc.Columns.Add("ntNumber", typeof(string));

             dtSubAcc.Columns.Add("isNtnActive", typeof(bool));
            dtSubAcc.Columns.Add("accOpenBal", typeof(Single));
            dtSubAcc.Columns.Add("opBalType", typeof(int));
            dtSubAcc.Columns.Add("accCreditLimit", typeof(Single));
              dtSubAcc.Columns.Add("accURL", typeof(string));
            dtSubAcc.Columns.Add("BranchID", typeof(int));

            

        }






            public async Task<adAccountsLookUpsVm> GetLookUpsforSubAccount()
            {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@AccTypeLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@BalTypeLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@CtrlAccLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@CityLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

                };


                var sql = "EXEC[SubAccountGetSearchLookUps] @AccTypeLookUp OUTPUT, @BalTypeLookUp OUTPUT, @CtrlAccLookUp OUTPUT, @CityLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0], @params[1], @params[2], @params[3]);



                adAccountsLookUpsVm lookups = new adAccountsLookUpsVm();




                lookups.adaccountsacctypelookup = JsonConvert.DeserializeObject<IList<adAccountsAccTypeLookUpVM>>(@params[0].Value.ToString());
                lookups.adaccountsbaltypelookup = JsonConvert.DeserializeObject<IList<adAccountsBalTypeLookUpVM>>(@params[1].Value.ToString());
                lookups.adaccountsctrlacclookup = JsonConvert.DeserializeObject<IList<adAccountsCtrlAccLookUpVM>>(@params[2].Value.ToString());
                lookups.adaccountscitylookup = JsonConvert.DeserializeObject<IList<adAccountsCityLookUpVM>>(@params[3].Value.ToString());


                con.Close();


                return lookups;



            }
        }

        public async Task<string> SaveSubAcc(adAccountsVM subAcc)
        {
            var maxMGID = new adMainGroupAccounts();
            

            int mgid = 0;
            var maxCode = "";
            if (subAcc.MainGroupID == 0)
            {
                maxMGID =await this._context.adMainGroupAccounts.OrderByDescending(x => x.MainGroupID).FirstOrDefaultAsync();
                if (maxMGID == null)
                {
                    maxMGID = new adMainGroupAccounts();
                    maxMGID.MainGroupID = 0;
                    
                }
                mgid = maxMGID.MainGroupID + 1;
            }
            else
            {
                mgid = subAcc.MainGroupID;
            }

            maxCode = await this._context.adMainGroupAccounts.Where(x => x.Code == subAcc.Code).OrderByDescending(x => x.Code).Select(x => x.Code).FirstOrDefaultAsync();
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

            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                //string CS = @"Data Source=CYBERSPACE\EAS;Initial Catalog=Vanya-bak;Persist Security Info=True;User ID=sa;Password=risay";
                //SqlConnection cn = null;
                SqlCommand cmd = null;

                //cn = new SqlConnection(CS);


                cmd = new SqlCommand("dbo.Insert_adAccounts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@adAccount", SqlDbType.Structured).Value = dtSubAcc;
                cmd.Parameters.Add("@MainGroupID", SqlDbType.BigInt).Value = subAcc.MainGroupID;
                cmd.Parameters.Add("@AccID", SqlDbType.BigInt).Value = subAcc.AccID;



                var returnParameter = cmd.Parameters.Add("@SmId", SqlDbType.BigInt);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                var result = returnParameter.Value;
                con.Close();


                return "Record Saved Successfully for ID:" + result;



            }
        }
    }
}
