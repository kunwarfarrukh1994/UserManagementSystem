using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IPandiRepository
    {
        Task<IList<PandiVM>> GetAllPandi();
        Task<PandiVM> GetPandiByID(int Id);
        Task<string> SavePandi(PandiVM adda);
        Task<string> DeletePandi(int Id);
    }
}
