using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICodeCodingProductTypeRepository
    {
        Task<IList<CodeCodingProductTypeVM>> GetAllProductTypes(int CompanyId);
        Task<CodeCodingProductTypeVM> GetProductTypeByID(int Id, int CompanyId);
        Task<string> SaveProductType(CodeCodingProductTypeVM pType);
        Task<string> DeleteProductType(int Id, int CompanyId);
    }
}
