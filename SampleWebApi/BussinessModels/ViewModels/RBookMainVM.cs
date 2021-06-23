using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class RBookMainVM
    {
		public Single Cid { get; set; }
		public DateTime Edate { get; set; }
		public string BookSerial { get; set; }
		public Single BookNo { get; set; }
		public Single SAccId { get; set; }
		public string Descriptions { get; set; }
		public Single Cheques { get; set; }
		public Single Cash { get; set; }
		public Single Discount { get; set; }
		public string T1 { get; set; }
		public Single N2 { get; set; }
		public string CompanyID { get; set; }
		public int BranchID { get; set; }
		public string OperatorID { get; set; }

		public List<RBookSubVM> RBookDetail { get; set; }

		public RBookMainVM()
        {
			RBookDetail = new List<RBookSubVM>();
		}
    }
}
