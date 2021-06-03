using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class mClassSub
    {
        public int? ID { get; set; }
        public int CID { get; set; }
        public int ClassTypeID { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
