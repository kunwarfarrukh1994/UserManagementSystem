using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BussinessModels.ViewModels;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IAgentRepository
    {
        Task<IList<AgentsVM>> GetAllAgents();
        Task<string> SaveAgent(AgentsVM agent);
        Task<AgentsVM> GetAgentByID(int Id);
        Task<string> DeleteAgent(int Id);
        
    }
}
