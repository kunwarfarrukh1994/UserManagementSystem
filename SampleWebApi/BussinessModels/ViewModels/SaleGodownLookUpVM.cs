using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleGodownLookUpVM
    {
        public Single ItemID { get; set; }
        public Single GodownId { get; set; }
        public string GodownName { get; set; }
        public Single Qty { get; set; }
        public Single? QtyReq { get; set; }
        
        public SaleGodownLookUpVM()
        {
            
        }
    }
}
