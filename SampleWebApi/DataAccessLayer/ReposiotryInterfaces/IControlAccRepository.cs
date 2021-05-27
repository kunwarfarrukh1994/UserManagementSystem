using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IControlAccRepository
    {
        Task<IList<adControlAccountsVM>> GetAllControlAcc();
        Task<adControlAccountsVM> GetControllAccByID(int Id);
        Task<string> SaveControlAcc(adControlAccountsVM controlAcc);
        Task<string> DeleteControlAcc(int Id);

        Task<adControlAccountsLookUpVM> GetLookUpsforCtrlAcc();
    }
}
