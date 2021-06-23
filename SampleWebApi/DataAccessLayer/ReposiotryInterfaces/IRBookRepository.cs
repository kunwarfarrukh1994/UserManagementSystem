using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IRBookRepository
    {
        Task<IList<RBookMainVM>> GetAllRBooks(int CompanyId, int BranchId);
        Task<RBookMainVM> GetRBookByID(int Id, int CompanyId, int BranchId);
        Task<string> SaveRBook(RBookMainVM rbookmain);
        Task<string> DeleteRBook(int Id, int CompanyId, int BranchId);
        Task<RBookLookUpsVM> GetLookUpsforRBook(int CompanyId, int BranchId);
    }
}
