using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class SalesOutSourceItems
    {
        public int? ID { get; set; }
        public int SMID { get; set; }
        public int SOID { get; set; }
        public int ItemID { get; set; }
        public string ItemDescription { get; set; }
        public Single Amount { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }

    }
}
