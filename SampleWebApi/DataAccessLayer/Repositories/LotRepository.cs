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
    public class LotRepository : ILotRepository
    {
        private readonly AppDbContext _context;
        DataTable dtLot;
        public LotRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {


            dtLot = new DataTable();
            dtLot.Columns.Add("Title", typeof(string));
            dtLot.Columns.Add("TitleU", typeof(string));
            dtLot.Columns.Add("LotType", typeof(string));
            dtLot.Columns.Add("Number", typeof(string));
            dtLot.Columns.Add("Description", typeof(string));
            dtLot.Columns.Add("CompanyID", typeof(int));
            dtLot.Columns.Add("BranchID", typeof(int));
            dtLot.Columns.Add("OperatorID", typeof(int));
            
        }



        public async Task<string> SaveLot(LotVM lot)
        {
            if (dtLot.Rows.Count > 0)
            {
                dtLot.Rows.Clear();
            }
            try
            {
                DataRow row = dtLot.NewRow();


                row["Title"] = lot.Title;
                row["TitleU"] = lot.TitleU;
                row["LotType"] = lot.LotType;
                row["Number"] = lot.Number;
                row["Description"] = lot.Description;
                row["CompanyID"] = lot.CompanyID;
                row["BranchID"] = lot.BranchID;
                row["OperatorID"] = lot.OperatorID;

                dtLot.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_Lot", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Lot", SqlDbType.Structured).Value = dtLot;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = lot.EDate;
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = lot.CID;



                    var returnParameter = cmd.Parameters.Add("@CID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();


                    return result.ToString();



                }

            }
            catch (Exception ex)
            {

                throw new Exception("Insert Failed");
            }
        }








        public async Task<string> DeleteLot(int Id)
        {
            try
            {
                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Del_Lot", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = Id;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();

                    con.Close();


                    return "Record Deleted Successfully";



                }
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed");
            }
        }

        public async Task<IList<LotVM>> GetAllLots()
        {
            try
            {
                SqlParameter[] @outparams =
               {
                       new SqlParameter("@LotsLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},


                };
                SqlParameter[] @inparams =
                    {

                };
                await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_AllLots", this._context);

                IList<LotVM> lots = JsonConvert.DeserializeObject<IList<LotVM>>(@outparams[0].Value.ToString());

                return lots;
            }
            catch (Exception ex)
            {

                throw new Exception("Get All Lots Failed");
            }
        }

        public async Task<LotVM> GetLotByID(int Id)
        {
            try
            {
                LotVM lotObj = new LotVM();


                var mainlot = await this._context.Lot.Where(x => x.CID == Id).FirstOrDefaultAsync();

                var mainjson = JsonConvert.SerializeObject(mainlot);

                lotObj = JsonConvert.DeserializeObject<LotVM>(mainjson);



                return lotObj;
            }

            catch (Exception ex)
            {

                throw new Exception("Get Lot By ID Failed");
            }
        }

    }
}
