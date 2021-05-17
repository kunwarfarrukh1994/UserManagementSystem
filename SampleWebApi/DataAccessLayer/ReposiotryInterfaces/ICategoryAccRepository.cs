using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICategoryAccRepository
    {
        Task<string> SaveCategoryAcc(adCategoryAccountsVM categoryAcc);
    }
}
