using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class SaleSubWarehouse
    {
        public int ID { get; set; }
        public int SMID { get; set; }
        public int GodownID { get; set; }
        public Single Packet { get; set; }
        public Single PktQty { get; set; }
        public Single Qty { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
