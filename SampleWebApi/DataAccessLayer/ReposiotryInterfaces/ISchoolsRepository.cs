using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ISchoolsRepository
    {
        Task<IList<SchoolsVM>> GetAllSchools();

        Task<SchoolsVM> GetSchoolByID(int Id);

        Task<string> SaveSchools(SchoolsVM school);

        Task<string> DeleteSchool(int Id);
        Task<SchoolLookUpsVM> GetLookUpsforSchool();
    }
}
