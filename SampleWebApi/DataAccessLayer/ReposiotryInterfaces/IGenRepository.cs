using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IGenRepository
    {
        Task<IList<GenMainVM>> GetAllGen();
        Task<GenMainVM> GetGenByID(int Id);
        Task<string> SaveGen(GenMainVM genmain);
        Task<string> DeleteGen(int Id);
        Task<GenLookUpsVM> GetLookUpsforGen();
    }
}
