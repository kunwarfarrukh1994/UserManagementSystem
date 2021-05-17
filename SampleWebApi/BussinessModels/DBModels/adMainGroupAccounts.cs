using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class adMainGroupAccounts
    {
		public int MainGroupID { get; set; }
		public int CateAccID { get; set; }
		public int CtrlAccID { get; set; }
		public int compID { get; set; }
		public string Code { get; set; }
		public string Title { get; set; }
		public int BranchID { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }
	}
}
