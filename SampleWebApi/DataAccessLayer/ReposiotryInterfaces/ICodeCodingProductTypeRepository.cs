using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICodeCodingProductTypeRepository
    {
        Task<IList<CodeCodingProductTypeVM>> GetAllProductTypes();
        Task<CodeCodingProductTypeVM> GetProductTypeByID(int Id);
        Task<string> SaveProductType(CodeCodingProductTypeVM pType);
        Task<string> DeleteProductType(int Id);
    }
}
