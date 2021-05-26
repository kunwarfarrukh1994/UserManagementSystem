using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class adMainGroupAccountsLookUpsVM
    {
        public IList<adMainGroupAccountsCtrlAccLookUpVM> admaingroupaccountsctrlacclookup { get; set; }

        public adMainGroupAccountsLookUpsVM()
        {
            admaingroupaccountsctrlacclookup = new List<adMainGroupAccountsCtrlAccLookUpVM>();
        }




    }
}
