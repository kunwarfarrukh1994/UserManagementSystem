using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICompaniesRepository
    {
        Task<IList<cdCompaniesVM>> GetAllCompanies();
        Task<cdCompaniesVM> GetCompanyByID(int Id);
        Task<string> SaveCompany(cdCompaniesVM company);
        Task<string> DeleteCompany(int Id);
    }
}
