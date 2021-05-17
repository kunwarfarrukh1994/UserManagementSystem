using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
	public class adCategoryAccounts
	{
		public int CateAccID { get; set; }
		public int FinStatementTypeID { get; set; }
		public int compID { get; set; }
		public string Title { get; set; }
		public string Code { get; set; }
		public int accHeadID { get; set; }
		public string accHeadName { get; set; }
		public int BranchID { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }
	}

	//FTID = 1  { 001,002,003,004,005}
	//FTID = 2  { 001,002,003,004}
	//FTID = 3  { 001,002,003,004}
}
