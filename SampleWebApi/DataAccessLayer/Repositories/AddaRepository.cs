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
    public class AddaRepository : IAddaRepository
    {
        private readonly AppDbContext _context;
        DataTable dtAdda;
        public AddaRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {

            dtAdda = new DataTable();
            dtAdda.Columns.Add("Title", typeof(string));
            dtAdda.Columns.Add("TitleU", typeof(string));
            dtAdda.Columns.Add("BranchID", typeof(int));
            dtAdda.Columns.Add("OperatorID", typeof(int));

        }



        public async Task<string> SaveAdda(AddaVM adda)
        {
            if (dtAdda.Rows.Count > 0)
            {
                dtAdda.Rows.Clear();
            }
            try
            {
                DataRow row = dtAdda.NewRow();


                row["Title"] = adda.Title;
                row["TitleU"] = adda.TitleU;
                row["BranchID"] = adda.BranchID;
                row["OperatorID"] = adda.OperatorID;
                
                dtAdda.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_Adda", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Adda", SqlDbType.Structured).Value = dtAdda;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = adda.EDate;
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = adda.CID;



                    var returnParameter = cmd.Parameters.Add("@CID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();

                    return result.ToString();
                    //return "Record Saved Successfully for ID:" + result;



                }

            }
            catch (Exception ex)
            {

                throw new Exception("Insert Failed");
            }

        }

        public async Task<string> DeleteAdda(int Id)
        {
            try 
            {
                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Del_Adda", con);
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

        public async Task<IList<AddaVM>> GetAllAdda()
        {
            var list = await this._context.Adda.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<AddaVM> addaList = JsonConvert.DeserializeObject<IList<AddaVM>>(json);

            return addaList;
        }


        public async Task<AddaVM> GetAddaByID(int Id)
        {
            AddaVM addaObj = new AddaVM();


            var mainAdda = await this._context.Adda.Where(x => x.CID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainAdda);

            addaObj = JsonConvert.DeserializeObject<AddaVM>(mainjson);



            return addaObj;
        }


    }
}
