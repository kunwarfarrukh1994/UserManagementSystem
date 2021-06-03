using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class mClassType
    {
        public int? ID { get; set; }
        public int CID { get; set; }
        public DateTime EDate { get; set; }
        public string ClassType { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
