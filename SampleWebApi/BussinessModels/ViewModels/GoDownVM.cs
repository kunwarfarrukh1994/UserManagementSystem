using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class GoDownVM
    {
        
        public int GoCid { get; set; }
        public DateTime EDate { get; set; }
        public string GoName { get; set; }
        public string GoNameU { get; set; }
        public string ShortName { get; set; }
        public int SortOrder { get; set; }
        public string PhoneNo { get; set; }
        public string AddressU { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }


        public GoDownVM()
        {

        }

    }
}
