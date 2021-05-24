using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class GenSub
    {
        public int? ID { get; set; }
        public int CID { get; set; }
        public int AccID { get; set; }
        public string AccDesc { get; set; }
        public string Narat { get; set; }
        public Single DrAmt { get; set; }
        public Single CrAmt { get; set; }
        public int FinID { get; set; }
        public Single BCID { get; set; }
        public int BranchID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
