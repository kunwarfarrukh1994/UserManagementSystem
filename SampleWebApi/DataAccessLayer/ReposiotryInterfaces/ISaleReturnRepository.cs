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
        Task<SaleReturnMainVM> GetSaleReturnByID(int Id);

        Task<string> SaveSaleReturn(SaleReturnMainVM salereturnmain);

        //Task<string> DeleteSaleReurn(int Id);
        //Task<SaleReturnLookUpVM> GetLookUpsforSaleReturn();


    }
}
