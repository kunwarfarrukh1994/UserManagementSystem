using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ISalesRepository
    {
        Task <IList<SalesMainVM>> GetAllSales();
        Task<SalesMainVM> GetSaleByID(int Id);

        Task<string> SaveSales(SalesMainVM salesmain);

        Task<string> DeleteSale(int Id);




    }
}
