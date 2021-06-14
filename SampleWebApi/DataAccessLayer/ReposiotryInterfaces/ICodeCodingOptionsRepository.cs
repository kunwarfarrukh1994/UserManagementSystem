using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public  interface ICodeCodingOptionsRepository
    {
        Task<IList<CodeCodingOptionsVM>> GetAllOptions();
        Task<CodeCodingOptionsVM> GetOptionByID(int Id);
        Task<string> SaveOption(CodeCodingOptionsVM pOption);
        Task<string> DeleteOption(int Id);
    }
}
