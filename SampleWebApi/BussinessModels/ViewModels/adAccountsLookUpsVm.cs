using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class adAccountsLookUpsVm
    {
        public IList<adAccountsAccTypeLookUpVM> adaccountsacctypelookup { get; set; }
        public IList<adAccountsBalTypeLookUpVM> adaccountsbaltypelookup { get; set; }
        public IList<adAccountsCtrlAccLookUpVM> adaccountsctrlacclookup { get; set; }
        public IList<adAccountsCityLookUpVM> adaccountscitylookup { get; set; }
        public IList<adAccountsAllAccountsLookUpVM> adaccountsallaccountslookup { get; set; }


        public adAccountsLookUpsVm()
        {
            adaccountsacctypelookup = new List<adAccountsAccTypeLookUpVM>();
            adaccountsbaltypelookup = new List<adAccountsBalTypeLookUpVM>();
            adaccountsctrlacclookup = new List<adAccountsCtrlAccLookUpVM>();
            adaccountscitylookup = new List<adAccountsCityLookUpVM>();
            adaccountsallaccountslookup = new List<adAccountsAllAccountsLookUpVM>();

        }
    }
}
