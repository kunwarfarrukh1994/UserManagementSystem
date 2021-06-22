using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IGodownRepository
    {
        Task<IList<GoDownVM>> GetAllGodowns(int CompanyId, int BranchId);
        Task<GoDownVM> GetGodownByID(int Id, int CompanyId, int BranchId);
        Task<string> SaveGodowns(GoDownVM godown);
        Task<string> DeleteGodown(int Id, int CompanyId, int BranchId);
    }
}
