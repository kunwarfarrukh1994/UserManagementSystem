using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleReturnMainLookUpVM
    {
        public int SMID { get; set; }
        public DateTime EDate { get; set; }
        public int AccID { get; set;  }
        public string? AccName { get; set; }
        public string CashAddress { get; set; }
        public int OperatorID { get; set; }

        public SaleReturnMainLookUpVM()
        {

         
                
        }
    }
}
