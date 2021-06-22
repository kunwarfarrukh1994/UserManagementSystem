using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ILoginRepository
    {
        //Task<string> GetLogin(LoginVM login);
       Task<IList<LoginVM>> GetLogin(string CorporateLogin, string CorporatePWD);
    }
}
