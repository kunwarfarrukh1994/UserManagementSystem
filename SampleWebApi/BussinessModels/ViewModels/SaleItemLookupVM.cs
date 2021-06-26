using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleItemLookupVM
    {
        public string Barcode { get; set; }
        public Single ItemID { get; set; }
        public string ItemDescription { get; set; }
        public Single SaleRate { get; set; }
        public Single BoraQty { get; set; }
     

        public SaleItemLookupVM()
        {
          
        }

    }

}
