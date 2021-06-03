using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IClassTypeRepository
    {
        Task<string> SaveClassType(mClassTypeVM classtype);
        Task<IList<mClassTypeVM>> GetAllClassTypes();
        Task<mClassTypeVM> GetClassTypeByID(int Id);
        Task<string> DeleteClassType(int Id);
    }
}
