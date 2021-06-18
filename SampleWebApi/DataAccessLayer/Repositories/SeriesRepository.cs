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
    public class SeriesRepository : ISeriesRepository
    {
        private readonly AppDbContext _context;
        DataTable dtSeries;
        public SeriesRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }
        public void initDT()
        {
            dtSeries = new DataTable();
            dtSeries.Columns.Add("SeriesName", typeof(string));
            dtSeries.Columns.Add("SeriesNameU", typeof(string));
            dtSeries.Columns.Add("Status", typeof(int));
            dtSeries.Columns.Add("CompanyID", typeof(int));
            dtSeries.Columns.Add("BranchID", typeof(int));
            dtSeries.Columns.Add("OperatorID", typeof(int));

        }

        public async Task<string> SaveSeries(mSeriesVM series)
        {
            if (dtSeries.Rows.Count > 0)
            {
                dtSeries.Rows.Clear();
            }
            try
            {
                DataRow row = dtSeries.NewRow();


                row["SeriesName"] = series.SeriesName;
                row["SeriesNameU"] = series.SeriesNameU;
                row["Status"] = series.Status;
                row["CompanyID"] = series.CompanyID;
                row["BranchID"] = series.BranchID;
                row["OperatorID"] = series.OperatorID;

                dtSeries.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_mSeries", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Series", SqlDbType.Structured).Value = dtSeries;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = series.EDate;
                    cmd.Parameters.Add("@SID", SqlDbType.BigInt).Value = series.SID;



                    var returnParameter = cmd.Parameters.Add("@SID", SqlDbType.BigInt);
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

        public async Task<string> DeleteSeries(int Id)
        {
            try
            {
                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Del_mSeries", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SID", SqlDbType.BigInt).Value = Id;

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

        public async Task<IList<mSeriesVM>> GetAllSeries()
        {
            try
            {
                SqlParameter[] @outparams =
               {
                       new SqlParameter("@SeriesLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},


                };
                SqlParameter[] @inparams =
                    {

                };
                await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_AllSeries", this._context);

                IList<mSeriesVM> series = JsonConvert.DeserializeObject<IList<mSeriesVM>>(@outparams[0].Value.ToString());

                return series;
            }
            catch (Exception ex)
            {

                throw new Exception("Get All Series Failed");
            }
        }

        public async Task<mSeriesVM> GetSeriesByID(int Id)
        {
            try
            {
                mSeriesVM seriesObj = new mSeriesVM();


                var mainSeries = await this._context.mSeries.Where(x => x.SID == Id).FirstOrDefaultAsync();

                var mainjson = JsonConvert.SerializeObject(mainSeries);

                seriesObj = JsonConvert.DeserializeObject<mSeriesVM>(mainjson);



                return seriesObj;
            }

            catch (Exception ex)
            {

                throw new Exception("Get Series By ID Failed");
            }
        }

      
    }
}
