using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class LedgerAccountsLookUpVM
    {
        public int AccID { get; set; }
        public string Title { get; set; }
        public string accAddress { get; set; }
        public string telephone { get; set; }

        public LedgerAccountsLookUpVM()
        {

        }
    }
}
