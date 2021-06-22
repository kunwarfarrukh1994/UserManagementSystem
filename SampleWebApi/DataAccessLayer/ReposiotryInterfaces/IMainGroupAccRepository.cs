using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IMainGroupAccRepository
    {
        Task<IList<adMainGroupAccountsVM>> GetAllGroupAccounts(int CompanyId);
        Task<string> SaveGroupAcc(adMainGroupAccountsVM groupAcc);
        Task<adMainGroupAccountsVM> GetGroupAccByID(int Id, int CompanyId);
        Task<string> DeleteGroupAcc(int Id, int CompanyId);
        Task<adMainGroupAccountsLookUpsVM> GetLookUpsforGroupAcc(int CompanyId);

    }
}
