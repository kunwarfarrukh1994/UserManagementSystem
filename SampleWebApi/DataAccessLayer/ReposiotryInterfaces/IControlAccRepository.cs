using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IControlAccRepository
    {
        Task<IList<adControlAccountsVM>> GetAllControlAcc(int CompanyId);
        Task<adControlAccountsVM> GetControllAccByID(int Id, int CompanyId);
        Task<string> SaveControlAcc(adControlAccountsVM controlAcc);
        Task<string> DeleteControlAcc(int Id, int CompanyId);

        Task<adControlAccountsLookUpVM> GetLookUpsforCtrlAcc(int CompanyId);
    }
}
