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
    public class PandiRepository : IPandiRepository
    {
        private readonly AppDbContext _context;
        DataTable dtPandi;
        public PandiRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }


        public void initDT()
        {

            dtPandi = new DataTable();
            dtPandi.Columns.Add("PandiName", typeof(string));
            dtPandi.Columns.Add("PhoneNo", typeof(string));
            dtPandi.Columns.Add("PerPhaira", typeof(Single));
            dtPandi.Columns.Add("CompanyID", typeof(int));
            dtPandi.Columns.Add("BranchID", typeof(int));
            dtPandi.Columns.Add("OperatorID", typeof(int));



        }

        public async Task<string> SavePandi(PandiVM pandi)
        {
            if (dtPandi.Rows.Count > 0)
            {
                dtPandi.Rows.Clear();
            }
            try
            {
                DataRow row = dtPandi.NewRow();


                row["PandiName"] = pandi.PandiName;
                row["PhoneNo"] = pandi.PhoneNo;
                row["PerPhaira"] = pandi.PerPhaira;
                row["CompanyID"] = pandi.CompanyID;
                row["BranchID"] = pandi.BranchID;
                row["OperatorID"] = pandi.OperatorID;

                dtPandi.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_Pandi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Pandi", SqlDbType.Structured).Value = dtPandi;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = pandi.EDate;
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = pandi.CID;



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

        public async Task<string> DeletePandi(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_Pandi", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }

        public async Task<IList<PandiVM>> GetAllPandi()
        {
            var list = await this._context.Pandi.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<PandiVM> pandiList = JsonConvert.DeserializeObject<IList<PandiVM>>(json);

            return pandiList;
        }

        public async Task<PandiVM> GetPandiByID(int Id)
        {
            PandiVM pandiObj = new PandiVM();


            var mainPandi = await this._context.Pandi.Where(x => x.CID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainPandi);

            pandiObj = JsonConvert.DeserializeObject<PandiVM>(mainjson);



            return pandiObj;
        }


    }
}
