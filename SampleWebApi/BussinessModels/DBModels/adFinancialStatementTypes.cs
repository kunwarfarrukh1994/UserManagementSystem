using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class adFinancialStatementTypes
    {
        public int FinStatementTypeID { get; set; }
        public DateTime EDate { get; set; }
        public int compID { get; set; }
        public int FinStatementCateID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int BranchID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
