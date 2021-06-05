using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class LedgerAllInputs
    {
        public int accountCode { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public int branchID { get; set; }
        public string lg_Type { get; set; }



        public LedgerAllInputs()
        {

        }
    }
}
