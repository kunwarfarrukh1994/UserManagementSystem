using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly AppDbContext _context;

        DataTable dtCustomers;

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
            dtCustomers.Columns.Add("CustomerCategory", typeof(string));
            dtCustomers.Columns.Add("WhatsappNo", typeof(Single));
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
                row["Name"] = customer.Name;
                row["Email"] = customer.Email;
                row["PhoneNo"] = customer.PhoneNo;
                row["CustomerCategory"] = customer.CustomerCategory;
                row["WhatsappNo"] = customer.WhatsappNo;
                row["CityID"] = customer.CityID;
                row["Type"] = customer.Type;
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


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                    //string CS = @"Data Source=CYBERSPACE\EAS;Initial Catalog=Vanya-bak;Persist Security Info=True;User ID=sa;Password=risay";
                    //SqlConnection cn = null;
                    SqlCommand cmd = null;

                    //cn = new SqlConnection(CS);


                    cmd = new SqlCommand("dbo.Insert_Customers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Customers", SqlDbType.Structured).Value = dtCustomers;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = customer.CID;



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





            return "Enter Valid Data First";
        }

        public Task<string> DeleteCustomer(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CustomerVM>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerVM> GetCustomerByID(int Id)
        {
            throw new NotImplementedException();
        }

    
    }
}
