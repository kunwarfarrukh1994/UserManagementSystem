using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleReturnSubLookUpVM
    {
        public int SMID { get; set; }
        public int ItemID { get; set; }
        public string ItemDescription { get; set; }
        public Single Rate { get; set; }
        public Single Qty { get; set; }
        public Single DisRs { get; set; }
        public Single DisPer { get; set; }
        public SaleReturnSubLookUpVM()
        {

        }
    }
}
