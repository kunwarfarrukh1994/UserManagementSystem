using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class mSeriesVM
    {
        public int SID { get; set; }
        public DateTime EDate { get; set; }
        public string SeriesName { get; set; }
        public string SeriesNameU { get; set; }
        public int Status { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }
        
        public mSeriesVM()
        {

        }
    }
}
