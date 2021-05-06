using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class CodeCodingWarehouse
    {
        public int? ID { get; set; }
        public Single CID { get; set; }
        public Single CWID { get; set; }
        public int GodownID { get; set; }
        public Single Qty { get; set; }
    }
}
