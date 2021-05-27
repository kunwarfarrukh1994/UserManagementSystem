using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class adCategoryAccountsLookUpsVM
    {

        public IList<adCategoryAccountsCompanyLookUpVM> adcategoryaccountscompanylookup { get; set; }

        public adCategoryAccountsLookUpsVM()
        {
            adcategoryaccountscompanylookup = new List<adCategoryAccountsCompanyLookUpVM>();
        }
    }
}
