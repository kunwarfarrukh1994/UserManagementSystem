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
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;
        DataTable dtCity;
        public CityRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }
        public void initDT()
        {
            dtCity = new DataTable();
            dtCity.Columns.Add("CityName", typeof(string));
            dtCity.Columns.Add("CityNameU", typeof(string));
            dtCity.Columns.Add("CityCode", typeof(string));
            dtCity.Columns.Add("CompanyID", typeof(int));

        }

        public async Task<string> SaveCity(CityVM city)
        {
            if (dtCity.Rows.Count > 0)
            {
                dtCity.Rows.Clear();
            }
            try
            {
                DataRow row = dtCity.NewRow();


                row["CityName"] = city.CityName;
                row["CityNameU"] = city.CityNameU;
                row["CityCode"] = city.CityCode;
                row["CompanyID"] = city.CompanyID;
              
                dtCity.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_City", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@City", SqlDbType.Structured).Value = dtCity;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = city.EDate;
                    cmd.Parameters.Add("@CityId", SqlDbType.BigInt).Value = city.CityId;



                    var returnParameter = cmd.Parameters.Add("@CityId", SqlDbType.BigInt);
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





        public async Task<string> DeleteCity(int Id, int CompanyId)
        {
            try
            {
                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Del_City", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CityId", SqlDbType.BigInt).Value = Id;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = CompanyId;


                    var returnParameter = cmd.Parameters.Add("@CityId", SqlDbType.BigInt);
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

                throw new Exception("Delete Failed");
            }
        }

        public async Task<IList<CityVM>> GetAllCities(int CompanyId)
        {
            try
            {
                SqlParameter[] @outparams =
               {
                       new SqlParameter("@CityLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},


                };
                SqlParameter[] @inparams =
                {
                    new SqlParameter("@CompanyID", CompanyId)
                };
                await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_AllCities", this._context);

                IList<CityVM> cities = JsonConvert.DeserializeObject<IList<CityVM>>(@outparams[0].Value.ToString());

                return cities;
            }

            catch (Exception ex)
            {

                throw new Exception("Get All Cities Failed");
            }
        }

        public async Task<CityVM> GetCityByID(int Id, int CompanyId)
        {
            try
            {
                CityVM cityObj = new CityVM();


                var mainCity = await this._context.City.Where(x => x.CityId == Id && x.CompanyID == CompanyId).FirstOrDefaultAsync();

                var mainjson = JsonConvert.SerializeObject(mainCity);

                cityObj = JsonConvert.DeserializeObject<CityVM>(mainjson);



                return cityObj;
            }

            catch (Exception ex)
            {

                throw new Exception("Get City By ID Failed");
            }
        }

     

       
    }
}
