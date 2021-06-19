using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IMainGroupAccRepository
    {
        Task<IList<adMainGroupAccountsVM>> GetAllGroupAccounts(int CompanyId, int BranchId);
        Task<string> SaveGroupAcc(adMainGroupAccountsVM groupAcc);
        Task<adMainGroupAccountsVM> GetGroupAccByID(int Id, int CompanyId, int BranchId);
        Task<string> DeleteGroupAcc(int Id, int CompanyId, int BranchId);
        Task<adMainGroupAccountsLookUpsVM> GetLookUpsforGroupAcc(int CompanyId, int BranchId);

    }
}
