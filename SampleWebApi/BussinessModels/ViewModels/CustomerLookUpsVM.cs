using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class CustomerLookUpsVM
    {
        public IList<CustomerCityLookUp> customerCitylookup { get; set; }
        public IList<CustomerRAgentLookUp> customerRAgentlookup { get; set; }
        public IList<CustomerMAgentLookUp> customerMAgentlookup { get; set; }
        public IList<CustomerAllcustomersLookUpVM> customerallcustomerslookup { get; set; }

        public CustomerLookUpsVM()
        {
            customerCitylookup = new List<CustomerCityLookUp>();
            customerRAgentlookup = new List<CustomerRAgentLookUp>();
            customerMAgentlookup = new List<CustomerMAgentLookUp>();
            customerallcustomerslookup = new List<CustomerAllcustomersLookUpVM>();
        }
    }
}
