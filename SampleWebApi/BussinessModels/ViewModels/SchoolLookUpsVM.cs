using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SchoolLookUpsVM
    {
        public IList<CustomerCityLookUp> customerCitylookup { get; set; }
        public IList<CustomerRAgentLookUp> customerRAgentlookup { get; set; }
        public IList<CustomerMAgentLookUp> customerMAgentlookup { get; set; }
        public IList<SchoolAllSchoolLookUpVM> schoolallschoollookup { get; set; }
        public IList<CustomerMainGroupLookUpVM> customermaingrouplookup { get; set; }

        public SchoolLookUpsVM()
        {
            customerCitylookup = new List<CustomerCityLookUp>();
            customerRAgentlookup = new List<CustomerRAgentLookUp>();
            customerMAgentlookup = new List<CustomerMAgentLookUp>();
            schoolallschoollookup = new List<SchoolAllSchoolLookUpVM>();
            customermaingrouplookup = new List<CustomerMainGroupLookUpVM>();
        }
    }
}
