using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class SaleReturnMain
    {
        public int? ID { get; set; }
        public int  SRID { get; set; }
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
        public int Del { get; set; }
        public int Sync { get; set; }





    }
}
