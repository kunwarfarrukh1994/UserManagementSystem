using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class PandiVM
    {

        public int CID { get; set; }
        public DateTime EDate { get; set; }
        public string PandiName { get; set; }
        public string PhoneNo { get; set; }
        public Single PerPhaira { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }
        

        public PandiVM()
        {

        }
    }
}
