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
            dtSubAcc.Columns.Add("EDate", typeof(DateTime));
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
            dtSubAcc.Columns.Add("CtrlAccIDDr", typeof(int));
            dtSubAcc.Columns.Add("CtrlAccIDCr", typeof(int));
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
                       new SqlParameter("@CityLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@AllAccountsLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@MainGroupAccLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

                };


                var sql = "EXEC[SubAccountGetSearchLookUps] @AccTypeLookUp OUTPUT, @BalTypeLookUp OUTPUT, @CtrlAccLookUp OUTPUT, @CityLookUp OUTPUT, @AllAccountsLookUp OUTPUT, @MainGroupAccLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0], @params[1], @params[2], @params[3], @params[4],@params[5]);



                adAccountsLookUpsVm lookups = new adAccountsLookUpsVm();




                lookups.adaccountsacctypelookup = JsonConvert.DeserializeObject<IList<adAccountsAccTypeLookUpVM>>(@params[0].Value.ToString());
                lookups.adaccountsbaltypelookup = JsonConvert.DeserializeObject<IList<adAccountsBalTypeLookUpVM>>(@params[1].Value.ToString());
                lookups.adaccountsctrlacclookup = JsonConvert.DeserializeObject<IList<adAccountsCtrlAccLookUpVM>>(@params[2].Value.ToString());
                lookups.adaccountscitylookup = JsonConvert.DeserializeObject<IList<adAccountsCityLookUpVM>>(@params[3].Value.ToString());
                lookups.adaccountsallaccountslookup = JsonConvert.DeserializeObject<IList<adAccountsAllAccountsLookUpVM>>(@params[4].Value.ToString());
                lookups.adaccountsmaingroupacclookup = JsonConvert.DeserializeObject<IList<adAccountsMainGroupAccLookUpVM>>(@params[5].Value.ToString());
                con.Close();


                return lookups;



            }
        }

        public async Task<string> SaveSubAcc(adAccountsVM subAcc)
        {
            if(dtSubAcc.Rows.Count > 0) 
            {
                dtSubAcc.Rows.Clear();
            }
            try 
            {
                var maxGID = new adGroupAccounts();
                int gid = 0;
                var maxCode = "";
                if (subAcc.AccID == 0) 
                {
                    maxGID = await this._context.adGroupAccounts.OrderByDescending(x => x.GroupAccID).FirstOrDefaultAsync();
                    if (maxGID == null)
                    {
                        maxGID = new adGroupAccounts();
                        maxGID.GroupAccID = 0;
                    }
                    gid = maxGID.GroupAccID + 1;
                    subAcc.GroupAccID = gid;
                }
                
                if(subAcc.MainGroupID == subAcc.tempGrpAccID) 
                {
                    maxCode = subAcc.tempCode;
                }
                else 
                {
                    maxCode = this._context.adGroupAccounts.Where(x => x.MainGroupID == subAcc.MainGroupID).Max(x => x.Code);

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




                
                

                subAcc.Code = maxCode;

                subAcc.AccFlexCode = maxCode + maxCode + maxCode;


                DataRow row = dtSubAcc.NewRow();

                row["EDate"] = subAcc.EDate;
                row["CateAccID"] = subAcc.CateAccID;
                row["CtrlAccID"] = subAcc.CtrlAccID;
                row["MainGroupID"] = subAcc.MainGroupID;
                row["GroupAccID"] = subAcc.GroupAccID;
                row["compID"] = subAcc.compID;
                row["Code"] = subAcc.Code;
                row["AccFlexCode"] = subAcc.AccFlexCode;
                row["Title"] = subAcc.Title;
                row["TitleU"] = subAcc.TitleU;
                row["AccTypeID"] = subAcc.AccTypeID;
                row["AccTransTypeID"] = subAcc.AccTransTypeID;
                row["isDeptAcc"] = subAcc.isDeptAcc;
                row["isLocationAcc"] = subAcc.isLocationAcc;
                row["isAutoOpenBal"] = subAcc.isAutoOpenBal;
                row["isFreeze"] = subAcc.isFreeze;
                row["isActive"] = subAcc.isActive;

                row["accCodeDr"] = subAcc.accCodeDr;
                row["accCodeCr"] = subAcc.accCodeCr;
                row["cityID"] = subAcc.cityID;
                row["areaID"] = subAcc.areaID;
                row["accAddress"] = subAcc.accAddress;
                row["telephone"] = subAcc.telephone;
                row["stNumber"] = subAcc.stNumber;
                row["ntNumber"] = subAcc.ntNumber;
                row["isNtnActive"] = subAcc.isNtnActive;
                row["accOpenBal"] = subAcc.accOpenBal;
                row["opBalType"] = subAcc.opBalType;
                row["accCreditLimit"] = subAcc.accCreditLimit;
                row["accURL"] = subAcc.accURL;
                row["CtrlAccIDDr"] = subAcc.CtrlAccIDDr;
                row["CtrlAccIDCr"] = subAcc.CtrlAccIDCr;
                row["BranchID"] = subAcc.BranchID;
                
                dtSubAcc.Rows.InsertAt(row, 0);



                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                    //string CS = @"Data Source=CYBERSPACE\EAS;Initial Catalog=Vanya-bak;Persist Security Info=True;User ID=sa;Password=risay";
                    //SqlConnection cn = null;
                    SqlCommand cmd = null;

                    //cn = new SqlConnection(CS);


                    cmd = new SqlCommand("dbo.Insert_SubAccounts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@adAccount", SqlDbType.Structured).Value = dtSubAcc;
                    //cmd.Parameters.Add("@MainGroupID", SqlDbType.BigInt).Value = subAcc.MainGroupID;
                    cmd.Parameters.Add("@GroupAccID", SqlDbType.BigInt).Value = subAcc.GroupAccID;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = subAcc.EDate;
                    cmd.Parameters.Add("@AccID", SqlDbType.BigInt).Value = subAcc.AccID;



                    var returnParameter = cmd.Parameters.Add("@AccID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();


                    return "Record Saved Successfully for ID:" + result;



                }
            }

            catch (Exception ex)
            {

                throw new Exception("Insert Failed");
            }
           
        }


        public async Task<string> UpdateSubAcc(adAccountsVM subAcc)
        {
            if (dtSubAcc.Rows.Count > 0)
            {
                dtSubAcc.Rows.Clear();
            }
            try
            {
              
                DataRow row = dtSubAcc.NewRow();

                row["EDate"] = subAcc.EDate;
                row["CateAccID"] = subAcc.CateAccID;
                row["CtrlAccID"] = subAcc.CtrlAccID;
                row["MainGroupID"] = subAcc.MainGroupID;
                row["GroupAccID"] = subAcc.GroupAccID;
                row["compID"] = subAcc.compID;
                row["Code"] = subAcc.Code;
                row["AccFlexCode"] = subAcc.AccFlexCode;
                row["Title"] = subAcc.Title;
                row["TitleU"] = subAcc.TitleU;
                row["AccTypeID"] = subAcc.AccTypeID;
                row["AccTransTypeID"] = subAcc.AccTransTypeID;
                row["isDeptAcc"] = subAcc.isDeptAcc;
                row["isLocationAcc"] = subAcc.isLocationAcc;
                row["isAutoOpenBal"] = subAcc.isAutoOpenBal;
                row["isFreeze"] = subAcc.isFreeze;
                row["isActive"] = subAcc.isActive;

                row["accCodeDr"] = subAcc.accCodeDr;
                row["accCodeCr"] = subAcc.accCodeCr;
                row["cityID"] = subAcc.cityID;
                row["areaID"] = subAcc.areaID;
                row["accAddress"] = subAcc.accAddress;
                row["telephone"] = subAcc.telephone;
                row["stNumber"] = subAcc.stNumber;
                row["ntNumber"] = subAcc.ntNumber;
                row["isNtnActive"] = subAcc.isNtnActive;
                row["accOpenBal"] = subAcc.accOpenBal;
                row["opBalType"] = subAcc.opBalType;
                row["accCreditLimit"] = subAcc.accCreditLimit;
                row["accURL"] = subAcc.accURL;
                row["CtrlAccIDDr"] = subAcc.CtrlAccIDDr;
                row["CtrlAccIDCr"] = subAcc.CtrlAccIDCr;
                row["BranchID"] = subAcc.BranchID;

                dtSubAcc.Rows.InsertAt(row, 0);



                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                    //string CS = @"Data Source=CYBERSPACE\EAS;Initial Catalog=Vanya-bak;Persist Security Info=True;User ID=sa;Password=risay";
                    //SqlConnection cn = null;
                    SqlCommand cmd = null;

                    //cn = new SqlConnection(CS);


                    cmd = new SqlCommand("dbo.Insert_SubAccounts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@adAccount", SqlDbType.Structured).Value = dtSubAcc;
                    cmd.Parameters.Add("@MainGroupID", SqlDbType.BigInt).Value = subAcc.MainGroupID;
                    cmd.Parameters.Add("@GroupAccID", SqlDbType.BigInt).Value = subAcc.GroupAccID;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = subAcc.EDate;
                    cmd.Parameters.Add("@AccID", SqlDbType.BigInt).Value = subAcc.AccID;



                    var returnParameter = cmd.Parameters.Add("@AccID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();


                    return "Record Saved Successfully for ID:" + result;



                }
            }

            catch (Exception ex)
            {

                throw new Exception("Insert Failed");
            }

        }





        public async Task<IList<adAccountsVM>> GetAllSubAccounts()
        {
            var list = await this._context.adAccounts.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<adAccountsVM> accountsList = JsonConvert.DeserializeObject<IList<adAccountsVM>>(json);

            return accountsList;
        }

        public async Task<adAccountsVM> GetSubAccountByID(int Id)
        {
            adAccountsVM subAccObj = new adAccountsVM();


            var mainSchool = await this._context.adAccounts.Where(x => x.AccID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainSchool);

            subAccObj = JsonConvert.DeserializeObject<adAccountsVM>(mainjson);



            return subAccObj;
        }

        public async Task<string> DeleteSubAccount(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_SubAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AccID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }
    }
}
