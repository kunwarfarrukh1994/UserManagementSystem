using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ISchoolsRepository
    {
        Task<IList<SchoolsVM>> GetAllSchools(int CompanyID, int BranchID);

        Task<SchoolsVM> GetSchoolByID(int Id, int CompanyID, int BranchID);

        Task<string> SaveSchools(SchoolsVM school);

        Task<string> DeleteSchool(int Id, int CompanyID, int BranchID);
        Task<SchoolLookUpsVM> GetLookUpsforSchool(int CompanyID, int BranchID);
    }
}
