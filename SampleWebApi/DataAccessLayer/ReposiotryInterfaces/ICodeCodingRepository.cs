using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICodeCodingRepository
    {
        Task<IList<CodeCodingMainVM>> GetAllProducts();
        Task<CodeCodingMainVM> GetProductByID(int Id);

        Task<string> SaveProduct(CodeCodingMainVM codemain);

        Task<string> DeleteProduct(int Id);

        Task<CodeCodingLookUpsVM> GetLookUpsforProduct();
    }
}
