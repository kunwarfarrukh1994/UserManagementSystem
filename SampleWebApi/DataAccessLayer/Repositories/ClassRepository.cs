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
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;
        DataTable dtClassMain, dtClassSub;

        public ClassRepository(AppDbContext context)
        {
            this._context = context;

            initDT();
        }
        public void initDT()
        {
           

            dtClassMain = new DataTable();
            dtClassMain.Columns.Add("ClassName", typeof(string));
            dtClassMain.Columns.Add("CStatus", typeof(int));
            dtClassMain.Columns.Add("CompanyID", typeof(int));
            dtClassMain.Columns.Add("BranchID", typeof(int));
            dtClassMain.Columns.Add("OperatorID", typeof(int));

            dtClassSub = new DataTable();
            dtClassSub.Columns.Add("ClassTypeID",typeof(int));
            dtClassSub.Columns.Add("CompanyID",typeof(int));
            dtClassSub.Columns.Add("BranchID",typeof(int));


        }


        public async Task<string> SaveClass(mClassMainVM classes)
        {
            try 
            {
                if(dtClassMain.Rows.Count > 0) 
                {
                    dtClassMain.Rows.Clear();
                    dtClassSub.Rows.Clear();
                }

                DataRow row = dtClassMain.NewRow();

                row["ClassName"] = classes.ClassName;
                row["CStatus"] = classes.CStatus;
                row["CompanyID"] = classes.CompanyID;
                row["BranchID"] = classes.BranchID;
                row["OperatorID"] = classes.OperatorID;

                dtClassMain.Rows.InsertAt(row, 0);

                int i = 0;
                foreach (var detail in classes.ClassDetail)
                {
                    DataRow srow = dtClassSub.NewRow();

                    srow["ClassTypeID"] = detail.ClassTypeID;
                    srow["CompanyID"] = detail.CompanyID;
                    srow["BranchID"] = detail.BranchID;

                    dtClassSub.Rows.InsertAt(srow, i);

                    i++;

                }

                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Insert_Class", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CMain", SqlDbType.Structured).Value = dtClassMain;
                    cmd.Parameters.Add("@CSub", SqlDbType.Structured).Value = dtClassSub;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = classes.EDate;
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = classes.CID;



                    var returnParameter = cmd.Parameters.Add("@CID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();


                    return  result.ToString();



                }


            }
            catch (Exception ex) 
            {
                throw new Exception("Insert Failed");
            }
        }

        public async Task<string> DeleteClass(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_Class", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }

        public async Task<IList<mClassMainVM>> GetAllClasses()
        {
            var list = await this._context.mClassMain.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<mClassMainVM> classList = JsonConvert.DeserializeObject<IList<mClassMainVM>>(json);

            return classList;
        }

        public async Task<mClassMainVM> GetClassByID(int Id)
        {
            mClassMainVM classMainobj = new mClassMainVM();


            var mainClass = await this._context.mClassMain.Where(x => x.CID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainClass);

            classMainobj = JsonConvert.DeserializeObject<mClassMainVM>(mainjson);

            if (classMainobj != null)
            {
                var subClass = await this._context.mClassSub.Where(x => x.CID == classMainobj.CID).ToListAsync();
                var subjson = JsonConvert.SerializeObject(subClass);
                classMainobj.ClassDetail = JsonConvert.DeserializeObject<List<mClassSubVM>>(subjson);

            }

            return classMainobj;
        }


        public async Task<mClassLookUpsVM> GetLookUpsforClass()
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@ClassTypeLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

                };

                var sql = "EXEC[GetSearchLookUpsClass] @ClassTypeLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0]);

                mClassLookUpsVM lookups = new mClassLookUpsVM();

                lookups.mclassclasstypelookup = JsonConvert.DeserializeObject<IList<mClassClassTypeLookUpVM>>(@params[0].Value.ToString());

                con.Close();

                return lookups;



            }
        }



    }
}
