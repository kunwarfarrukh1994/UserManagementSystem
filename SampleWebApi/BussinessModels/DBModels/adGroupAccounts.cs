using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class adGroupAccounts
    {
		public int GroupAccID { get; set; }
		public int CateAccID { get; set; }
		public int CtrlAccID { get; set; }
		public int MainGroupID { get; set; }
		public int CompID { get; set; }
		public string Code { get; set; }
		public string Title { get; set; }
		public int AccTypeID { get; set; }
		public bool isChild { get; set; }
		public int ParentID { get; set; }
		public bool isCoaItem { get; set; }
		public bool isActive { get; set; }
		public int BranchID { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }

	}
}
