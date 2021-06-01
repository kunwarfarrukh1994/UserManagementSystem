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
    public class SchoolsRepository : ISchoolsRepository
    {
        private readonly AppDbContext _context;

        DataTable dtSchools;

        public SchoolsRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {
           
            dtSchools = new DataTable();
            dtSchools.Columns.Add("SchoolName", typeof(string));
            dtSchools.Columns.Add("ContactPerson", typeof(string));
            dtSchools.Columns.Add("Principal", typeof(string));
            dtSchools.Columns.Add("Email", typeof(string));
            dtSchools.Columns.Add("PhoneNo", typeof(string));
            dtSchools.Columns.Add("MainGroupID", typeof(string));
            dtSchools.Columns.Add("WhatsappNo", typeof(string));
            dtSchools.Columns.Add("MailAddress", typeof(string));
            dtSchools.Columns.Add("CityID", typeof(int));
            dtSchools.Columns.Add("SchlType", typeof(string));
            dtSchools.Columns.Add("SchoolBranches", typeof(int));
            dtSchools.Columns.Add("SchoolStrength", typeof(int));
            dtSchools.Columns.Add("SessionStart", typeof(string));
            dtSchools.Columns.Add("AgentID1", typeof(int));
            dtSchools.Columns.Add("AgentID2", typeof(int));
            dtSchools.Columns.Add("OpBal", typeof(Single));
            dtSchools.Columns.Add("CreditLimit", typeof(Single));
            dtSchools.Columns.Add("SAccID", typeof(int));
            dtSchools.Columns.Add("LocationID", typeof(int));
            dtSchools.Columns.Add("CompanyID", typeof(int));
            dtSchools.Columns.Add("BranchID", typeof(int));
            dtSchools.Columns.Add("OperatorID", typeof(int));


        }


        public async Task<string> SaveSchools(SchoolsVM school)
        {
            if (dtSchools.Rows.Count > 0)
            {
                dtSchools.Rows.Clear();
            }

            try
            {
                DataRow row = dtSchools.NewRow();

                row["SchoolName"] = school.SchoolName;
                row["ContactPerson"] = school.ContactPerson;
                row["Principal"] = school.Principal;
                row["Email"] = school.Email;
                row["PhoneNo"] = school.PhoneNo;
                row["MainGroupID"] = school.MainGroupID;
                row["WhatsappNo"] = school.WhatsappNo;
                row["MailAddress"] = school.MailAddress;
                row["CityID"] = school.CityID;
                row["SchlType"] = school.SchlType;
                row["SchoolBranches"] = school.SchoolBranches;
                row["SchoolStrength"] = school.SchoolStrength;
                row["SessionStart"] = school.SessionStart;
                row["AgentID1"] = school.AgentID1;
                row["AgentID2"] = school.AgentID2;
                row["OpBal"] = school.OpBal;
                row["CreditLimit"] = school.CreditLimit;
                row["SAccID"] = school.SAccID;
                row["LocationID"] = school.LocationID;
                row["CompanyID"] = school.CompanyID;
                row["BranchID"] = school.BranchID;
                row["OperatorID"] = school.OperatorID;


                dtSchools.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                    //string CS = @"Data Source=CYBERSPACE\EAS;Initial Catalog=Vanya-bak;Persist Security Info=True;User ID=sa;Password=risay";
                    //SqlConnection cn = null;
                    SqlCommand cmd = null;

                    //cn = new SqlConnection(CS);


                    cmd = new SqlCommand("dbo.Insert_Schools", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Schools", SqlDbType.Structured).Value = dtSchools;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = school.CID;



                    var returnParameter = cmd.Parameters.Add("@CID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();

                    if (Convert.ToInt32(result) > 0)
                    {
                        return result.ToString();
                    }

                    else
                    {
                        return result.ToString();
                    }


                }

            }
            catch (Exception ex)
            {

                throw new Exception("Insert Failed");
            }
        }

        public async Task<string> DeleteSchool(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_Schools", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }

        public async Task<IList<SchoolsVM>> GetAllSchools()
        {
            var list = await this._context.Schools.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<SchoolsVM> schoolsList = JsonConvert.DeserializeObject<IList<SchoolsVM>>(json);

            return schoolsList;
        }

        public async Task<SchoolLookUpsVM> GetLookUpsforSchool()
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@CityLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@RAgentLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@MAgentLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@SchoolLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@MainGroupLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}


                };


                var sql = "EXEC[SchoolsGetSearchLookUps] @CityLookUp OUTPUT, @RAgentLookUp OUTPUT,@MAgentLookUp OUTPUT,@SchoolLookUp OUTPUT, @MainGroupLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0], @params[1], @params[2], @params[3], @params[4]);



                SchoolLookUpsVM lookups = new SchoolLookUpsVM();


                lookups.customerCitylookup = JsonConvert.DeserializeObject<IList<CustomerCityLookUp>>(@params[0].Value.ToString());

                lookups.customerRAgentlookup = JsonConvert.DeserializeObject<IList<CustomerRAgentLookUp>>(@params[1].Value.ToString());
                lookups.customerMAgentlookup = JsonConvert.DeserializeObject<IList<CustomerMAgentLookUp>>(@params[2].Value.ToString());
                lookups.schoolallschoollookup = JsonConvert.DeserializeObject<IList<SchoolAllSchoolLookUpVM>>(@params[3].Value.ToString());
                lookups.customermaingrouplookup = JsonConvert.DeserializeObject<IList<CustomerMainGroupLookUpVM>>(@params[4].Value.ToString());

                con.Close();


                return lookups;



            }
        }

        public async Task<SchoolsVM> GetSchoolByID(int Id)
        {
            SchoolsVM schoolObj = new SchoolsVM();


            var mainSchool = await this._context.Schools.Where(x => x.CID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainSchool);

            schoolObj = JsonConvert.DeserializeObject<SchoolsVM>(mainjson);



            return schoolObj;
        }

       
    }
}
