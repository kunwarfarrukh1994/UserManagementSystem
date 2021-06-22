using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICodeCodingCategoryRepository
    {
        Task<IList<CodeCodingCategoryVM>> GetAllCategories(int CompanyId);
        Task<CodeCodingCategoryVM> GetCategoryByID(int Id, int CompanyId);
        Task<string> SaveCategory(CodeCodingCategoryVM pCate);
        Task<string> DeleteCategory(int Id, int CompanyId);
    }
}
