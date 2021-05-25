using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ISubAccountsRepository
    {
        Task<IList<adAccountsVM>> GetAllSubAccounts();
        Task<adAccountsVM> GetSubAccountByID(int Id);
        Task<adAccountsLookUpsVm> GetLookUpsforSubAccount();
        Task<string> SaveSubAcc(adAccountsVM subAcc);

        Task<string> DeleteSubAccount(int Id);
    }
}
