using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class adControlAccountsLookUpVM
    {

        public IList<adControlAccountsCategoryLookUpVM> adcontrolaccountscategorylookup { get; set; }

        public adControlAccountsLookUpVM()
        {
            adcontrolaccountscategorylookup = new List<adControlAccountsCategoryLookUpVM>();
        }
    }
}
