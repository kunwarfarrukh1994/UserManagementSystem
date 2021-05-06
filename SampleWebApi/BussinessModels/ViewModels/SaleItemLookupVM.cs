using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleItemLookupVM
    {
        public string Barcode { get; set; }
        public Single ItemID { get; set; }
        public Single CostRate { get; set; }
        public int GodownID { get; set; }
        public int Qty { get; set; }
    }
}
