using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class LedgerLookUpVM
    {
        public IList<LedgerAllLookUpVM> ledgeralllookup { get; set; }
        public IList<LedgerAccountsLookUpVM> ledgeraccountslookup { get; set; }
        public LedgerLookUpVM()
        {
            ledgeralllookup = new List<LedgerAllLookUpVM>();
            ledgeraccountslookup = new List<LedgerAccountsLookUpVM>();
        }
    }
}
