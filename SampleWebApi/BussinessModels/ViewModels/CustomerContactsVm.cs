using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class CustomerContactsVm
    {
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
     
        public CustomerContactsVm()
        {

        }
    }
}
