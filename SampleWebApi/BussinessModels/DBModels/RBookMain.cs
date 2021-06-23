using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class RBookMain
    {
		public int? id { get; set; }
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
		public int CompanyID { get; set; }
		public int BranchID { get; set; }
		public int OperatorID { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }

	}
}
