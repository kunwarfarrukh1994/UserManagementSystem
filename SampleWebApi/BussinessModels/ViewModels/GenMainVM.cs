using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class GenMainVM
    {
        public int CID { get; set; }
        public DateTime EDate { get; set; }
        public int HeadID { get; set; }
        public string Narat { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OpertorID { get; set; }
        public List<GenSubVM> dayBookSub { get; set; }

        public GenMainVM()
        {
            dayBookSub = new List<GenSubVM>();
        }


    }
}
