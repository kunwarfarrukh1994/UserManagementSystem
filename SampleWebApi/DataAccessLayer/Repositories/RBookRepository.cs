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
    public class RBookRepository : IRBookRepository
    {
        public readonly AppDbContext _context;
        DataTable dtRBookMain, dtRBookSub;
        public RBookRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {
            dtRBookMain = new DataTable();

            dtRBookMain.Columns.Add("BookSerial", typeof(string));
            dtRBookMain.Columns.Add("BookNo", typeof(Single));
            dtRBookMain.Columns.Add("SAccId", typeof(Single));
            dtRBookMain.Columns.Add("Descriptions", typeof(string));
            dtRBookMain.Columns.Add("Cheques", typeof(Single));
            dtRBookMain.Columns.Add("Cash", typeof(Single));
            dtRBookMain.Columns.Add("Bank", typeof(Single));
            dtRBookMain.Columns.Add("Discount", typeof(Single));
            dtRBookMain.Columns.Add("T1", typeof(string));
            dtRBookMain.Columns.Add("N2", typeof(Single));
            dtRBookMain.Columns.Add("CompanyID", typeof(int));
            dtRBookMain.Columns.Add("BranchID", typeof(int));
            dtRBookMain.Columns.Add("OperatorID", typeof(int));

            dtRBookSub = new DataTable();

            dtRBookSub.Columns.Add("SaccId", typeof(Single));
            dtRBookSub.Columns.Add("Narat", typeof(string));
            dtRBookSub.Columns.Add("EType", typeof(int));
            dtRBookSub.Columns.Add("Amount", typeof(Single));
            dtRBookSub.Columns.Add("PCID", typeof(Single));
            dtRBookSub.Columns.Add("ChqBank", typeof(string));
            dtRBookSub.Columns.Add("ChqNo", typeof(string));
            dtRBookSub.Columns.Add("ChqDate", typeof(DateTime));
            dtRBookSub.Columns.Add("TC", typeof(string));
            dtRBookSub.Columns.Add("TCBank", typeof(string));
            dtRBookSub.Columns.Add("TCQty", typeof(Single));
            dtRBookSub.Columns.Add("TCRate", typeof(Single));
            dtRBookSub.Columns.Add("RecAgainst", typeof(Single));
            dtRBookSub.Columns.Add("ChqSr", typeof(int));
            dtRBookSub.Columns.Add("ChqNoS", typeof(int));
            dtRBookSub.Columns.Add("Remarks", typeof(string));
            dtRBookSub.Columns.Add("T2", typeof(string));
            dtRBookSub.Columns.Add("N2", typeof(Single));
            dtRBookSub.Columns.Add("CompanyID", typeof(int));
            dtRBookSub.Columns.Add("BranchID", typeof(int));


        }

        public async Task<string> SaveRBook(RBookMainVM rbookmain)
        {
            if (dtRBookMain.Rows.Count > 0)
            {
                dtRBookMain.Rows.Clear();
            }
            if (dtRBookSub.Rows.Count > 0)
            {
                dtRBookSub.Rows.Clear();
            }
            if (rbookmain.RBookDetail.Count > 0)
            {
                try
                {
                 

                    DataRow row = dtRBookMain.NewRow();

                    row["BookSerial"] = rbookmain.BookSerial;
                    row["BookNo"] = rbookmain.BookNo;
                    row["SAccId"] = rbookmain.SAccId;
                    row["Descriptions"] = rbookmain.Descriptions;
                    row["Cheques"] = rbookmain.Cheques;
                    row["Cash"] = rbookmain.Cash;
                    row["Bank"] = rbookmain.Bank;
                    row["Discount"] = rbookmain.Discount;
                    row["T1"] = rbookmain.T1;
                    row["N2"] = rbookmain.N2;
                    row["CompanyID"] = rbookmain.CompanyID;
                    row["BranchID"] = rbookmain.BranchID;
                    row["OperatorID"] = rbookmain.OperatorID;

                    dtRBookMain.Rows.InsertAt(row, 0);


                    int i = 0;
                    foreach (var rbooksub in rbookmain.RBookDetail)
                    {
                        DataRow srow = dtRBookSub.NewRow();
                        srow["SaccId"] = rbooksub.SaccId;
                        srow["Narat"] = rbooksub.Narat;
                        srow["EType"] = rbooksub.EType;
                        srow["Amount"] = rbooksub.Amount;
                        srow["PCID"] = rbooksub.PCID;
                        srow["ChqBank"] = rbooksub.ChqBank;
                        srow["ChqNo"] = rbooksub.ChqNo;
                        srow["ChqDate"] = rbooksub.ChqDate;
                        srow["TC"] = rbooksub.TC;

                        srow["TCBank"] = rbooksub.TCBank;
                        srow["TCQty"] = rbooksub.TCQty;
                        srow["TCRate"] = rbooksub.TCRate;
                        srow["RecAgainst"] = rbooksub.RecAgainst;
                        srow["ChqSr"] = rbooksub.ChqSr;
                        srow["ChqNoS"] = rbooksub.ChqNoS;
                        srow["Remarks"] = rbooksub.Remarks;
                        srow["T2"] = rbooksub.T2;
                        srow["N2"] = rbooksub.N2;
                        srow["CompanyID"] = rbooksub.CompanyID;
                        srow["BranchID"] = rbooksub.BranchID;

                        dtRBookSub.Rows.InsertAt(srow, i);

                    }


                    using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                    {

                        SqlCommand cmd = null;

                        cmd = new SqlCommand("dbo.Insert_RBook", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@RMain", SqlDbType.Structured).Value = dtRBookMain;
                        cmd.Parameters.Add("@RSub", SqlDbType.Structured).Value = dtRBookSub;
                        cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = rbookmain.Edate;
                        cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = rbookmain.Cid;



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
                    throw new Exception ("Insert Failed");
                }

              
            }


            else
            {
                return "Enter Valid Data First";
            }

        }

        public async Task<string> DeleteRBook(int Id, int CompanyId, int BranchId)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_RBook", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = Id;
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = CompanyId;
                cmd.Parameters.Add("@BranchId", SqlDbType.BigInt).Value = BranchId;

                var returnParameter = cmd.Parameters.Add("@CID", SqlDbType.BigInt);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                var result = returnParameter.Value;
                con.Close();

                return result.ToString();


            }
        }

        public async Task<IList<RBookMainVM>> GetAllRBooks(int CompanyId, int BranchId)
        {
            SqlParameter[] @outparams =
              {
                       new SqlParameter("@RBookLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

                };
            SqlParameter[] @inparams =
                {
                    new SqlParameter("@CompanyId", CompanyId),
                    new SqlParameter("@BranchId", BranchId),


                };
            await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_AllRBooks", this._context);

            IList<RBookMainVM> rbookList = JsonConvert.DeserializeObject<IList<RBookMainVM>>(@outparams[0].Value.ToString());


            return rbookList;
        }

        public async Task<RBookLookUpsVM> GetLookUpsforRBook(int CompanyId, int BranchId)
        {
            SqlParameter[] @outparams =
                 {
                     new SqlParameter("@AccountLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                      

                };
            SqlParameter[] @inparams =
                {
                    new SqlParameter("@CompanyId", CompanyId),
                    new SqlParameter("@BranchId", BranchId),
                };
            await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_SearchLookUpsRBook", this._context);

            RBookLookUpsVM lookups = new RBookLookUpsVM();

            lookups.accountlookup = JsonConvert.DeserializeObject<IList<RBookAccountLookUpVM>>(@outparams[0].Value.ToString());
           

            return lookups;
        }

        public async Task<RBookMainVM> GetRBookByID(int Id, int CompanyId, int BranchId)
        {
            RBookMainVM rbookobj = new RBookMainVM();


            var maincode = this._context.RBookMain.Where(x => x.Cid == Id && x.CompanyID == CompanyId && x.BranchID == BranchId).FirstOrDefault();

            var mainjson = JsonConvert.SerializeObject(maincode);

            rbookobj = JsonConvert.DeserializeObject<RBookMainVM>(mainjson);

            if (rbookobj != null)
            {
                var rbookSub = await this._context.RBookSub.Where(x => x.CID == rbookobj.Cid && x.CompanyID == CompanyId && x.BranchID == BranchId).ToListAsync();
                var subjson = JsonConvert.SerializeObject(rbookSub);
                rbookobj.RBookDetail = JsonConvert.DeserializeObject<List<RBookSubVM>>(subjson);
            }

            return rbookobj;
        }

       
    }
}
