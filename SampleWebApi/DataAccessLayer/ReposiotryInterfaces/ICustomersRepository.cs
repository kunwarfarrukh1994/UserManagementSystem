using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICustomersRepository
    {
        Task<IList<CustomerVM>> GetAllCustomers(int CompanyId, int BranchId);
        Task<CustomerVM> GetCustomerByID(int Id, int CompanyId, int BranchId);

        Task<string> SaveCustomers(CustomerVM customer);

        Task<string> DeleteCustomer(int Id, int CompanyId, int BranchId);
        Task<CustomerLookUpsVM> GetLookUpsforCustomer(int CompanyId, int BranchId);
    }
}
