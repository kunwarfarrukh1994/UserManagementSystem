using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class mClassTypeVM
    {
        public int CID { get; set; }
        public DateTime EDate { get; set; }
        public string ClassType { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }
     

        public mClassTypeVM()
        {

        }
    }
}
