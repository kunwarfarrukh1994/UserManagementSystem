using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class adControlAccounts
    {
		public int CtrlAccID { get; set; }
		public DateTime EDate { get; set; }
		public int CateAccID { get; set; }
		public int CompID { get; set; }
		public string Code { get; set; }
		public string Title { get; set; }
		public int accCodeId { get; set; }
		public string accCodeName { get; set; }
		public int BranchID { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }
	}
}
