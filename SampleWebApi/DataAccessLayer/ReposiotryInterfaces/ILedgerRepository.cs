using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ILedgerRepository
    {
        Task <string> GetLedgerDetail(int accCode, DateTime fDate, DateTime tDate, int branchID, string lg_Type);
        Task<LedgerLookUpVM> GetLookUpsforLedger();
    }
}
