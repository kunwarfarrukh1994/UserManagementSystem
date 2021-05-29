using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class GenLookUpsVM
    {
        public IList<GenAccountsLookUpVM> genaccountslookup { get; set; }


        public GenLookUpsVM()
        {
            genaccountslookup = new List<GenAccountsLookUpVM>();
        }
    }
}
