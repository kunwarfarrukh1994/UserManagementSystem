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
    public class CustomersRepository : ICustomersRepository
    {
        private readonly AppDbContext _context;

        DataTable dtCustomers, dtCustomerDetail;

        public CustomersRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

 

        public void initDT()
        {
  
   
            dtCustomers = new DataTable();
            dtCustomers.Columns.Add("CustomerName", typeof(string));
            dtCustomers.Columns.Add("ContactPerson", typeof(string));
            dtCustomers.Columns.Add("Name", typeof(string));
            dtCustomers.Columns.Add("Email", typeof(string));
            dtCustomers.Columns.Add("PhoneNo", typeof(string));
            dtCustomers.Columns.Add("MainGroupID", typeof(string));
            dtCustomers.Columns.Add("WhatsappNo", typeof(string));
            dtCustomers.Columns.Add("CityID", typeof(int));
            dtCustomers.Columns.Add("Type", typeof(string));
            dtCustomers.Columns.Add("MailAddress", typeof(string));
            dtCustomers.Columns.Add("AgentID1", typeof(int));
            dtCustomers.Columns.Add("AgentID2", typeof(int));
            dtCustomers.Columns.Add("CreditLimit", typeof(Single));
            dtCustomers.Columns.Add("OpBal", typeof(Single));
            dtCustomers.Columns.Add("SAccID", typeof(int));
            dtCustomers.Columns.Add("LocationID", typeof(int));
            dtCustomers.Columns.Add("CompanyID", typeof(int));
            dtCustomers.Columns.Add("BranchID", typeof(int));
            dtCustomers.Columns.Add("OperatorID", typeof(int));


            dtCustomerDetail = new DataTable();
            dtCustomerDetail.Columns.Add("ContactName", typeof(string));
            dtCustomerDetail.Columns.Add("ContactNo", typeof(string));
            dtCustomerDetail.Columns.Add("Designation", typeof(int));
            dtCustomerDetail.Columns.Add("CompanyID", typeof(int));
            dtCustomerDetail.Columns.Add("BranchID", typeof(int));




    }


    public async Task<string> SaveCustomers(CustomerVM customer)
        {
            if (dtCustomers.Rows.Count > 0)
            {
                dtCustomers.Rows.Clear();
            }
            try 
            {
                DataRow row = dtCustomers.NewRow();


                row["CustomerName"] = customer.CustomerName;
                row["ContactPerson"] = customer.ContactPerson;
                row["Name"] = customer.CName;
                row["Email"] = customer.Email;
                row["PhoneNo"] = customer.PhoneNo;
                row["MainGroupID"] = customer.MainGroupID;
                row["WhatsappNo"] = customer.WhatsappNo;
                row["CityID"] = customer.CityID;
                row["Type"] = customer.CustType;
                row["MailAddress"] = customer.MailAddress;
                row["AgentID1"] = customer.AgentID1;
                row["AgentID2"] = customer.AgentID2;
                row["CreditLimit"] = customer.CreditLimit;
                row["OpBal"] = customer.OpBal;
                row["SAccID"] = customer.SAccID;
                row["LocationID"] = customer.LocationID;
                row["CompanyID"] = customer.CompanyID;
                row["BranchID"] = customer.BranchID;
                row["OperatorID"] = customer.OperatorID;


                dtCustomers.Rows.InsertAt(row, 0);


                int i = 0;
                foreach (var detail in customer.customerContact)
                {
                    DataRow srow = dtCustomerDetail.NewRow();
                    srow["ContactName"] = detail.ContactName;
                    srow["ContactNo"] = detail.ContactNo;
                    srow["Designation"] = detail.ContactName;
                    srow["CompanyID"] = detail.ContactName;
                    srow["BranchID"] = detail.ContactName;

                    dtCustomerDetail.Rows.InsertAt(srow, i);
                }


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                    //string CS = @"Data Source=CYBERSPACE\EAS;Initial Catalog=Vanya-bak;Persist Security Info=True;User ID=sa;Password=risay";
                    //SqlConnection cn = null;
                    SqlCommand cmd = null;

                    //cn = new SqlConnection(CS);


                    cmd = new SqlCommand("dbo.Insert_Customers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Customers", SqlDbType.Structured).Value = dtCustomers;
                    cmd.Parameters.Add("@CContacts", SqlDbType.Structured).Value = dtCustomerDetail;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = customer.EDate;
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = customer.CID;
                    



                    var returnParameter = cmd.Parameters.Add("@CID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();

                    if(Convert.ToInt32(result) > 0) 
                    {
                        return  result.ToString();
                    }

                    else 
                    {
                        return  result.ToString();
                    }

                    



                }

            }
            catch (Exception ex)
            {
                
                throw new Exception("Insert Failed");
            }





            
        }


        public async Task<IList<CustomerVM>> GetAllCustomers()
        {
            var list = await this._context.Customers.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<CustomerVM> customersList = JsonConvert.DeserializeObject<IList<CustomerVM>>(json);

            return customersList;
        }

        public async Task<CustomerVM> GetCustomerByID(int Id)
        {
            CustomerVM custObj = new CustomerVM();


            var mainCust = await this._context.Customers.Where(x => x.CID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainCust);

            custObj = JsonConvert.DeserializeObject<CustomerVM>(mainjson);

    

            return custObj;
        }


        public async Task<string> DeleteCustomer(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_Customers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }

        }


        public async Task<CustomerLookUpsVM> GetLookUpsforCustomer()
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@CityLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@RAgentLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@MAgentLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@CustomerLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@MainGroupLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}


                };


                var sql = "EXEC[CustomersGetSearchLookUps] @CityLookUp OUTPUT, @RAgentLookUp OUTPUT,@MAgentLookUp OUTPUT,@CustomerLookUp OUTPUT, @MainGroupLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0], @params[1], @params[2], @params[3],@params[4]);



                CustomerLookUpsVM lookups = new CustomerLookUpsVM();


                lookups.customerCitylookup = JsonConvert.DeserializeObject<IList<CustomerCityLookUp>>(@params[0].Value.ToString());

                lookups.customerRAgentlookup = JsonConvert.DeserializeObject<IList<CustomerRAgentLookUp>>(@params[1].Value.ToString());
                lookups.customerMAgentlookup = JsonConvert.DeserializeObject<IList<CustomerMAgentLookUp>>(@params[2].Value.ToString());
                lookups.customerallcustomerslookup = JsonConvert.DeserializeObject<IList<CustomerAllcustomersLookUpVM>>(@params[3].Value.ToString());
                lookups.customermaingrouplookup = JsonConvert.DeserializeObject<IList<CustomerMainGroupLookUpVM>>(@params[4].Value.ToString());

                con.Close();


                return lookups;



            }
        }

    }
}
