using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleReturnLookUpsVM
    {
        public IList<SaleReturnMainLookUpVM> salereturnmainlookup { get; set; }
        public IList<SaleReturnSubLookUpVM> salereturnsublookup { get; set; }
        public IList<SaleReturnGodownLookUpVM> salereturngodownlookup { get; set; }

        public SaleReturnLookUpsVM()
        {
            salereturnmainlookup = new List<SaleReturnMainLookUpVM>();
            salereturnsublookup = new List<SaleReturnSubLookUpVM>();
            salereturngodownlookup = new List<SaleReturnGodownLookUpVM>();

        }
    }
}
