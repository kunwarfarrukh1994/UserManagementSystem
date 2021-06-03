using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IClassRepository
    {
        Task<IList<mClassMainVM>> GetAllClasses();
        Task<mClassMainVM> GetClassByID(int Id);
        Task<string> SaveClass(mClassMainVM classes);
        Task<string> DeleteClass(int Id);

        Task<mClassLookUpsVM> GetLookUpsforClass();
    }
}
