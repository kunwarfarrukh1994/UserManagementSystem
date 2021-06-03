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
    public class ClassTypeRepository : IClassTypeRepository
    {
        private readonly AppDbContext _context;
        DataTable dtClassType;
        public ClassTypeRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

       

        public void initDT()
        {
            dtClassType = new DataTable();
            dtClassType.Columns.Add("ClassType", typeof(string));
            dtClassType.Columns.Add("CompanyID", typeof(int));
            dtClassType.Columns.Add("BranchID", typeof(int));
            dtClassType.Columns.Add("OperatorID", typeof(int));

        }

        public async Task<string> SaveClassType(mClassTypeVM classtype)
        {
            if (dtClassType.Rows.Count > 0)
            {
                dtClassType.Rows.Clear();
            }
            try
            {
                DataRow row = dtClassType.NewRow();


                row["ClassType"] = classtype.ClassType;
                row["CompanyID"] = classtype.CompanyID;
                row["BranchID"] = classtype.BranchID;
                row["OperatorID"] = classtype.OperatorID;

                dtClassType.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_ClassType", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClassType", SqlDbType.Structured).Value = dtClassType;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = classtype.EDate;
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = classtype.CID;



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

        public async Task<IList<mClassTypeVM>> GetAllClassTypes()
        {
            var list = await this._context.mClassType.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<mClassTypeVM> classTypeList = JsonConvert.DeserializeObject<IList<mClassTypeVM>>(json);

            return classTypeList;
        }



        public async Task<mClassTypeVM> GetClassTypeByID(int Id)
        {
            mClassTypeVM classTypeObj = new mClassTypeVM();


            var mainClassType = await this._context.mClassType.Where(x => x.CID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainClassType);

            classTypeObj = JsonConvert.DeserializeObject<mClassTypeVM>(mainjson);



            return classTypeObj;
        }

        public async Task<string> DeleteClassType(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_ClassType", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }



    }
}
