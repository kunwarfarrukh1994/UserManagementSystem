using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BussinessModels.DBModels
{
    
    public class SaleSub
    {
    
        public int? ID { get; set; }
        public int? SMID { get; set; }
        public int? ItemID { get; set; }
        public string? ItemDescription { get; set; }
        public string? Unit { get; set; }
        public Single? Packet { get; set; }
        public Single? PktQty { get; set; }
        public Single? Qty { get; set; }
        public Single? Rate { get; set; }
        public Single? DisRS { get; set; }
        public Single? DisPer { get; set; }
        public Single? NetRate { get; set; }
        public Single? Amount { get; set; }
        public string? STRG { get; set; }
        public Single? CommisionRs { get; set; }
        public Single? CommisionPer { get; set; }
        public Single? Bardana { get; set; }
        public Single? Tulai { get; set; }
        public int? CompanyID { get; set; }
        public int? BranchID { get; set; }
        public int? Del { get; set; }
        public int? Sync { get; set; }
      


    }
}
