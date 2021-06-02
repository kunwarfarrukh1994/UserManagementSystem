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
    public class AgentRepository : IAgentRepository
    {
        private readonly AppDbContext _context;

        DataTable dtAgents;

        public AgentRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {
             
            dtAgents = new DataTable();
            dtAgents.Columns.Add("AgentName", typeof(string));
            dtAgents.Columns.Add("Category", typeof(int));
            dtAgents.Columns.Add("PhoneNumber", typeof(string));
            dtAgents.Columns.Add("Email", typeof(string));
            dtAgents.Columns.Add("ReferBy", typeof(string));
            dtAgents.Columns.Add("UserName", typeof(string));
            dtAgents.Columns.Add("Password", typeof(string));
            dtAgents.Columns.Add("IdCardNo", typeof(string));
            dtAgents.Columns.Add("CompanyID", typeof(int));
            dtAgents.Columns.Add("BranchID", typeof(int));
            dtAgents.Columns.Add("OperatorID", typeof(int));



        }


        public async Task<string> SaveAgent(AgentsVM agent)
        {
            if (dtAgents.Rows.Count > 0)
            {
                dtAgents.Rows.Clear();
            }
            try
            {
                DataRow row = dtAgents.NewRow();
          
                row["AgentName"] = agent.AgentName;
                row["Category"] = agent.Category;
                row["PhoneNumber"] = agent.PhoneNumber;
                row["Email"] = agent.Email;
                row["ReferBy"] = agent.ReferBy;
                row["UserName"] = agent.UserName;
                row["Password"] = agent.Password;
                row["IdCardNo"] = agent.IdCardNo;
                row["CompanyID"] = agent.CompanyID;
                row["BranchID"] = agent.BranchID;
                row["OperatorID"] = agent.OperatorID;



                dtAgents.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                   
                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_Agents", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Agents", SqlDbType.Structured).Value = dtAgents;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = agent.EDate;
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = agent.CID;



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


        public async Task<string> DeleteAgent(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_Agent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }


        public async Task<IList<AgentsVM>> GetAllMAgents()
        {
            var list = await this._context.Agents.Where(x => x.Del == 0 && x.Category == 1).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<AgentsVM> agentsList = JsonConvert.DeserializeObject<IList<AgentsVM>>(json);

            return agentsList;
        }

        public async Task<IList<AgentsVM>> GetAllRAgents()
        {
            var list = await this._context.Agents.Where(x => x.Del == 0 && x.Category == 2).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<AgentsVM> agentsList = JsonConvert.DeserializeObject<IList<AgentsVM>>(json);

            return agentsList;
        }


        public async Task<AgentsVM> GetAgentByID(int Id)
        {
            AgentsVM agentObj = new AgentsVM();


            var mainAgent = await this._context.Agents.Where(x => x.CID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainAgent);

            agentObj = JsonConvert.DeserializeObject<AgentsVM>(mainjson);



            return agentObj;
        }

        //public async Task<AgentsVM> GetRAgentByID(int Id)
        //{
        //    AgentsVM agentObj = new AgentsVM();


        //    var mainAgent = await this._context.Agents.Where(x => x.CID == Id).FirstOrDefaultAsync();

        //    var mainjson = JsonConvert.SerializeObject(mainAgent);

        //    agentObj = JsonConvert.DeserializeObject<AgentsVM>(mainjson);



        //    return agentObj;
        //}
    }
}
