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
    public class ControlAccRepository : IControlAccRepository
    {
        private readonly AppDbContext _context;
        DataTable dtControl;

        public ControlAccRepository( AppDbContext context)
        {
            this._context = context;
            initDT();

        }

        public void initDT()
        {

            dtControl = new DataTable();
            dtControl.Columns.Add("CateAccID", typeof(int));
            dtControl.Columns.Add("CompID", typeof(int));
            dtControl.Columns.Add("Code", typeof(string));
            dtControl.Columns.Add("Title", typeof(string));
            dtControl.Columns.Add("BranchID", typeof(int));


        }



        public async  Task<string> SaveControlAcc(adControlAccountsVM controlAcc, int lblCate)
        {
            if (dtControl.Rows.Count > 0)
            {
                dtControl.Rows.Clear();
            }
            try
            {
                var list = "";
                if (controlAcc.CtrlAccID == 0)
                {

                    list = await this._context.adControlAccounts.Where(x => x.CateAccID == controlAcc.CateAccID).OrderByDescending(x => x.Code).Select(x => x.Code).FirstOrDefaultAsync();
                    if (list == null)
                    {
                        list = "00";
                    }
                    int MC = Convert.ToInt32(list.ToString()) + 1;
                    if (Convert.ToString(MC).Length == 1)
                        list = "0" + MC.ToString();
                    else
                        list = MC.ToString();
                }
                else 
                {
                    if (controlAcc.CateAccID != lblCate)
                    {
                        list = await this._context.adControlAccounts.Where(x => x.CateAccID == controlAcc.CateAccID).OrderByDescending(x => x.Code).Select(x => x.Code).FirstOrDefaultAsync();
                        if (list == null)
                        {
                            list = "00";
                        }
                        int MC = Convert.ToInt32(list.ToString()) + 1;
                        if (Convert.ToString(MC).Length == 1)
                            list = "0" + MC.ToString();
                        else
                            list = MC.ToString();
                    }
                    else 
                    {
                        list = controlAcc.Code;
                    }
                    
                   
                }

                DataRow row = dtControl.NewRow();
          
                row["CateAccID"] = controlAcc.CateAccID;
                row["CompID"] = controlAcc.CompID;
                row["Code"] = list;
                row["Title"] = controlAcc.Title;
                row["BranchID"] = controlAcc.BranchID;




                dtControl.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_ControlAccounts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ControlAcc", SqlDbType.Structured).Value = dtControl;
                    cmd.Parameters.Add("@CtrlAccID", SqlDbType.BigInt).Value = controlAcc.CtrlAccID;



                    var returnParameter = cmd.Parameters.Add("@CtrlAccID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();


                    return "Control Account Saved Successfully for ID:" + result;



                }

            }
            catch (Exception ex)
            {

                throw new Exception("Insert Failed");
            }

        }
        public async Task<string> DeleteControlAcc(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_ControlAcc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CtrlAccID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }

        public async Task<IList<adControlAccountsVM>> GetAllControlAcc()
        {
            var list = await this._context.adControlAccounts.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<adControlAccountsVM> controlAccList = JsonConvert.DeserializeObject<IList<adControlAccountsVM>>(json);

            return controlAccList;
        }

        public async Task<adControlAccountsVM> GetControllAccByID(int Id)
        {
            adControlAccountsVM cntrlObj = new adControlAccountsVM();


            var mainComp = await this._context.adControlAccounts.Where(x => x.CtrlAccID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainComp);

            cntrlObj = JsonConvert.DeserializeObject<adControlAccountsVM>(mainjson);



            return cntrlObj;
        }

    
    }
}
