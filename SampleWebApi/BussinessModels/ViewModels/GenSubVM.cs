using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class GenSubVM
    {
        public int AccID { get; set; }
        public string AccDesc { get; set; }
        public string Narat { get; set; }
        public Single DrAmt { get; set; }
        public Single CrAmt { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OpertorID { get; set; }
       
    }
}
