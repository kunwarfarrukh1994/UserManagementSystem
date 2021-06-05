using BussinessModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface ILedgerRepository
    {
        //Task <LedgerVM> GetLedgerDetail(int accCode, DateTime fDate, DateTime tDate, int branchID, string lg_Type);
        Task<LedgerLookUpVM> GetLedgerDetail(LedgerAllInputs ledInputs);

        Task<LedgerLookUpVM> GetLookUpsforLedger();
    }
}
