using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICodeCodingRepository
    {
        Task<IList<CodeCodingMainVM>> GetAllProducts(int CompanyId);
        Task <CodeCodingMainVM> GetProductByID(int Id, int CompanyId);

        Task<string> SaveProduct(CodeCodingMainVM codemain);

        Task<string> DeleteProduct(int Id, int CompanyId);

        Task<CodeCodingLookUpsVM> GetLookUpsforProduct(int CompanyId);
    }
}
