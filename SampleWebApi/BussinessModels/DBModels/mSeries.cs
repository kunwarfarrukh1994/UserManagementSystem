using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class mSeries
    {
        public int? ID { get; set; }
        public int SID { get; set; }
        public string SeriesName { get; set; }
        public int Status { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
