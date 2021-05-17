using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ICustomersRepository
    {
        Task<IList<CustomerVM>> GetAllCustomers();
        Task<CustomerVM> GetCustomerByID(int Id);

        Task<string> SaveCustomers(CustomerVM customer);

        Task<string> DeleteCustomer(int Id);
        Task<CustomerLookUpsVM> GetLookUpsforCustomer();
    }
}
