using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class CustomerContacts
    {
        public int? ID { get; set; }
        public int CID { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string Designation { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
