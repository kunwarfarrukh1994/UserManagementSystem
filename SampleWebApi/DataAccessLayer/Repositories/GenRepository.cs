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
    public class GenRepository : IGenRepository
    {
        private readonly AppDbContext _context;
        DataTable dtGenMain, dtGenSub;
        public GenRepository(AppDbContext context)
        {
            this._context = context;
            initDt();
        }

        public void initDt() 
        {


            dtGenMain = new DataTable();
            dtGenMain.Columns.Add("HeadID", typeof(int));
            dtGenMain.Columns.Add("Narat", typeof(string));
            dtGenMain.Columns.Add("CompanyID", typeof(int));
            dtGenMain.Columns.Add("BranchID", typeof(int));
            dtGenMain.Columns.Add("OpertorID", typeof(int));

            dtGenSub = new DataTable();

  
            dtGenSub.Columns.Add("AccID", typeof(int));
            dtGenSub.Columns.Add("AccDesc", typeof(string));
            dtGenSub.Columns.Add("Narat", typeof(string));
            dtGenSub.Columns.Add("DrAmt", typeof(Single));
            dtGenSub.Columns.Add("CrAmt", typeof(Single));
            dtGenSub.Columns.Add("CompanyID", typeof(int));
            dtGenSub.Columns.Add("BranchID", typeof(int));
            dtGenSub.Columns.Add("OpertorID", typeof(int));



        }



        public async Task<string> SaveGen(GenMainVM genmain)
        {

            try
            {
                if(dtGenMain.Rows.Count > 0)
                {
                    dtGenMain.Rows.Clear();
                }
                if(dtGenSub.Rows.Count > 0) 
                {
                    dtGenSub.Rows.Clear();
                }


                DataRow row = dtGenMain.NewRow();

                row["HeadID"] = genmain.HeadID;
                row["Narat"] = genmain.Narat;
                row["CompanyID"] = genmain.CompanyID;
                row["BranchID"] = genmain.BranchID;
                row["OpertorID"] = genmain.OpertorID;


                dtGenMain.Rows.InsertAt(row, 0);



                int i = 0;
                foreach (var detail in genmain.GenSub)
                {
                    DataRow srow = dtGenSub.NewRow();

                    srow["AccID"] = detail.AccID;
                    srow["AccDesc"] = detail.AccDesc;
                    srow["Narat"] = detail.Narat;
                    srow["DrAmt"] = detail.DrAmt;
                    srow["CrAmt"] = detail.CrAmt;
                    srow["CompanyID"] = detail.CompanyID;
                    srow["BranchID"] = detail.BranchID;
                    srow["OpertorID"] = detail.OpertorID;

                    dtGenSub.Rows.InsertAt(srow, i);

                    i++;

                }


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                    
                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Insert_Gen", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@GMain", SqlDbType.Structured).Value = dtGenMain;
                    cmd.Parameters.Add("@GSub", SqlDbType.Structured).Value = dtGenSub;
                    
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = genmain.EDate;
                    
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = genmain.CID;



                    var returnParameter = cmd.Parameters.Add("@CID", SqlDbType.BigInt);
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


        public async Task<IList<GenMainVM>> GetAllGen()
        {
            var list = await this._context.SaleMain.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<GenMainVM> genList = JsonConvert.DeserializeObject<IList<GenMainVM>>(json);

            return genList;
        }

        public async Task<GenMainVM> GetGenByID(int Id)
        {
            GenMainVM genmainobj = new GenMainVM();


            var maingen = await this._context.GenMain.Where(x => x.CID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(maingen);

            genmainobj = JsonConvert.DeserializeObject<GenMainVM>(mainjson);

            if (genmainobj != null)
            {
                var subgen = await this._context.GenSub.Where(x => x.CID == genmainobj.CID).ToListAsync();
                var subjson = JsonConvert.SerializeObject(subgen);
                genmainobj.GenSub = JsonConvert.DeserializeObject<List<GenSubVM>>(subjson);

            }

            return genmainobj;
        }

        public async Task<string> DeleteGen(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_Gen", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }


        public async Task<GenLookUpsVM> GetLookUpsforGen()
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@AccountLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}
                      
                };

                var sql = "EXEC[GetSearchLookUpsGen] @AccountLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0]);

                GenLookUpsVM lookups = new GenLookUpsVM();

                lookups.genaccountslookup = JsonConvert.DeserializeObject<IList<GenAccountsLookUpVM>>(@params[0].Value.ToString());

                con.Close();

                return lookups;



            }
        }

    }
}
