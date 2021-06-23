using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class RBookLookUpsVM
    {
        public IList<RBookAccountLookUpVM> accountlookup { get; set; }
        public RBookLookUpsVM()
        {
            accountlookup = new List<RBookAccountLookUpVM>();
        }
    }
}
