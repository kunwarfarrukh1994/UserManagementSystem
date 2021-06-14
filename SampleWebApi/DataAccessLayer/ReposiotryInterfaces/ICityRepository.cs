using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICityRepository
    {
        Task<IList<CityVM>> GetAllCities();
        Task<CityVM> GetCityByID(int Id);
        Task<string> SaveCity(CityVM city);
        Task<string> DeleteCity(int Id);
    }
}
