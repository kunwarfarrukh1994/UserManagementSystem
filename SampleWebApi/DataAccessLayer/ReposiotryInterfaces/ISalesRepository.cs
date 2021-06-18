using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ISalesRepository
    {
        Task <IList<SalesMainVM>> GetAllSales(int CompanyID, int BranchID);
        Task<SalesMainVM> GetSaleByID(int Id, int CompanyID, int BranchID);

        Task<string> SaveSales(SalesMainVM salesmain);

        Task <string> DeleteSale(int Id);

        Task <SalesLookUpsVM> GetLookUpsforSale();
        Task<SalesLookUpsVM> GetLookUpsforSalesInvoice();


    }
}
