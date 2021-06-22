using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IClassRepository
    {
        Task<IList<mClassMainVM>> GetAllClasses(int CompanyId);
        Task<mClassMainVM> GetClassByID(int Id, int CompanyId);
        Task<string> SaveClass(mClassMainVM classes);
        Task<string> DeleteClass(int Id, int CompanyId);

        Task<mClassLookUpsVM> GetLookUpsforClass(int CompanyId);
    }
}
