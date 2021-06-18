using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ISeriesRepository
    {
        Task<IList<mSeriesVM>> GetAllSeries();
        Task<mSeriesVM> GetSeriesByID(int Id);
        Task<string> SaveSeries(mSeriesVM series);
        Task<string> DeleteSeries(int Id);
    }
}
