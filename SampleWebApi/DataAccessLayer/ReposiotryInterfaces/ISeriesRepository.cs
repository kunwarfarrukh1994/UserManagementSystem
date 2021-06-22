using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ISeriesRepository
    {
        Task<IList<mSeriesVM>> GetAllSeries(int CompanyId);
        Task<mSeriesVM> GetSeriesByID(int Id, int CompanyId);
        Task<string> SaveSeries(mSeriesVM series);
        Task<string> DeleteSeries(int Id, int CompanyId);
    }
}
