using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IGenRepository
    {
        Task<IList<GenMainVM>> GetAllGen(int CompanyId, int BranchId);
        Task<GenMainVM> GetGenByID(int Id, int CompanyId, int BranchId);
        Task<string> SaveGen(GenMainVM genmain);
        Task<string> DeleteGen(int Id, int CompanyId, int BranchId);
        Task<GenLookUpsVM> GetLookUpsforGen(int CompanyId, int BranchId);
    }
}
