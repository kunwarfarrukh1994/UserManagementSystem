using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICategoryAccRepository
    {
        Task<IList<adCategoryAccountsVM>> GetAllCategoriesAcc();
        Task<adCategoryAccountsVM> GetCategoryAccByID(int Id);
        Task<string> SaveCategoryAcc(adCategoryAccountsVM categoryAcc);
        Task<string> DeleteCategoryAcc(int Id);
    }
}
