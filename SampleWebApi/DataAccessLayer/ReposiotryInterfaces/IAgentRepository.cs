using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BussinessModels.ViewModels;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IAgentRepository
    {
        Task<IList<AgentsVM>> GetAllMAgents(int CompanyID, int BranchID);
        Task<IList<AgentsVM>> GetAllRAgents(int CompanyID, int BranchID);
        Task<string> SaveAgent(AgentsVM agent);
        Task<AgentsVM> GetAgentByID(int Id, int CompanyID, int BranchID);
        //Task<AgentsVM> GetRAgentByID(int Id);
        Task<string> DeleteAgent(int Id, int CompanyID, int BranchID);
        
    }
}
