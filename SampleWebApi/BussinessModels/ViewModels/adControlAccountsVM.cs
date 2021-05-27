using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class adControlAccountsVM
    {
		public int CtrlAccID { get; set; }
		public DateTime EDate { get; set; }
		public int CateAccID { get; set; }
		public int CompID { get; set; }
		public string Code { get; set; }
		public string Title { get; set; }
		public string TitleU { get; set; }
		public int BranchID { get; set; }
		public int? tmpCateAccID { get; set; }
	}
}
