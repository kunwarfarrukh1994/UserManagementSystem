using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class CodeCodingWarehouseVM
    {
        public int? GodownID { get; set; }
        public Single? Qty { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
    }
}
