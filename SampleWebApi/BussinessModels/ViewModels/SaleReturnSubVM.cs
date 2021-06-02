using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleReturnSubVM
    {
        
        public int SMID { get; set; }
        public int ItemD { get; set; }
        public string itemDescription { get; set; }
        public Single Rate { get; set; }
        public Single Qty { get; set; }
        public int GodownID { get; set; }
        public Single DisPer { get; set; }
        public Single NetTotal { get; set; }
        public int? CompanyID { get; set; }
        public int? BranchID { get; set; }

        public SaleReturnSubVM()
        {

        }
    }
}
