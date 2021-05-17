using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class CustomerLookUpsVM
    {
        public IList<CustomerCityLookUp> customerCitylookup { get; set; }
        public IList<CustomerAgentLookUp> customerAgentlookup { get; set; }

        public CustomerLookUpsVM()
        {
            customerCitylookup = new List<CustomerCityLookUp>();
            customerAgentlookup = new List<CustomerAgentLookUp>();
        }
    }
}
