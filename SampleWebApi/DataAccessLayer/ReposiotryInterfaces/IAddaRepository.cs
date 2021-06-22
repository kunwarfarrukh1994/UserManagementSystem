using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IAddaRepository
    {
        Task<IList<AddaVM>> GetAllAdda(int CompanyId);
        Task<AddaVM> GetAddaByID(int Id,int CompanyId);
        Task<string> SaveAdda(AddaVM adda);
        Task<string> DeleteAdda(int Id, int CompanyId);
    }
}
