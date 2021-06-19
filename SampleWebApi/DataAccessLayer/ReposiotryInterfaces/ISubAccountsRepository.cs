using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ISubAccountsRepository
    {
        Task<IList<adAccountsVM>> GetAllSubAccounts(int CompanyId, int BranchId);
        Task<adAccountsVM> GetSubAccountByID(int Id, int CompanyId, int BranchId);
        Task<adAccountsLookUpsVm> GetLookUpsforSubAccount(int CompanyId, int BranchId);
        Task<string> SaveSubAcc(adAccountsVM subAcc);
        Task<string> UpdateSubAcc(adAccountsVM subAcc);
        Task<string> DeleteSubAccount(int Id, int CompanyId, int BranchId);
    }
}
