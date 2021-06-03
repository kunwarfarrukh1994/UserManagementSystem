using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class mClassMainVM
    {
        public int CID { get; set; }
        public DateTime EDate { get; set; }
        public string ClassName { get; set; }
        public int CStatus { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }

        public List<mClassSubVM> ClassDetail { get; set; }


        public mClassMainVM()
        {
            ClassDetail = new List<mClassSubVM>();
        }
    }
}
