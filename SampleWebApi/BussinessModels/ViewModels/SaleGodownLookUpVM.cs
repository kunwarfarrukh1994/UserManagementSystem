using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleGodownLookUpVM
    {
        public int? GodownId { get; set; }
        public Single Qty { get; set; }
        public Single? QtyReq { get; set; }

        public List<SalesGodownNameLookUpVM> G { get; set; }
        public SaleGodownLookUpVM()
        {
            QtyReq = 0;
            G = new List<SalesGodownNameLookUpVM>();
        }
    }
}
