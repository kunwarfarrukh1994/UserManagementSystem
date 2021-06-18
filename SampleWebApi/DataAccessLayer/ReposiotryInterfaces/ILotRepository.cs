using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ILotRepository
    {
        Task<IList<LotVM>> GetAllLots();
        Task<LotVM> GetLotByID(int Id);
        Task<string> SaveLot(LotVM lot);
        Task<string> DeleteLot(int Id);

    }
}
