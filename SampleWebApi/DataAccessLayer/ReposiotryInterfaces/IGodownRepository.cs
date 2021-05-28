using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IGodownRepository
    {
        Task<IList<GoDownVM>> GetAllGodowns();
        Task<GoDownVM> GetGodownByID(int Id);
        Task<string> SaveGodowns(GoDownVM godown);
        Task<string> DeleteGodown(int Id);
    }
}
