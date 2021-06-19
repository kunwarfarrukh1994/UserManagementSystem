using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ISaleReturnRepository
    {
        //Task<IList<SaleReturnMainVM>> GetAllSaleReturns();
        Task<SaleReturnLookUpsVM> GetSaleReturnByID(int Id, int CompanyID, int BranchID);

        Task<string> SaveSaleReturn(SaleReturnMainVM salereturnmain);

        //Task<string> DeleteSaleReurn(int Id);
        //Task<SaleReturnLookUpVM> GetLookUpsforSaleReturn();


    }
}
