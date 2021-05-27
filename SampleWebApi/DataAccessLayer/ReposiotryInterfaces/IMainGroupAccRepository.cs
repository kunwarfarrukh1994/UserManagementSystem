using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IMainGroupAccRepository
    {
        Task<IList<adMainGroupAccountsVM>> GetAllGroupAccounts();
        Task<string> SaveGroupAcc(adMainGroupAccountsVM groupAcc);
        Task<adMainGroupAccountsVM> GetGroupAccByID(int Id);
        Task<string> DeleteGroupAcc(int Id);
        Task<adMainGroupAccountsLookUpsVM> GetLookUpsforGroupAcc();

    }
}
