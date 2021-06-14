using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICodeCodingCategoryRepository
    {
        Task<IList<CodeCodingCategoryVM>> GetAllCategories();
        Task<CodeCodingCategoryVM> GetCategoryByID(int Id);
        Task<string> SaveCategory(CodeCodingCategoryVM pCate);
        Task<string> DeleteCategory(int Id);
    }
}
