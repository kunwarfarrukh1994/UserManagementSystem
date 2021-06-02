using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleReturnMainVM
    {
        public int SRID { get; set; }
        public int SMID { get; set; }
        public DateTime EDate { get; set; }
        public int AccID { get; set; }
        public string Remarks { get; set; }
        public Single SReturn { get; set; }
        public Single DiscountUser { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int LocationID { get; set; }
        public int OperatorID { get; set; }

        public List<SaleReturnSubVM> SaleReturn { get; set; }
        public SaleReturnMainVM()
        {
            SaleReturn = new List<SaleReturnSubVM>();
        }
    }
}
