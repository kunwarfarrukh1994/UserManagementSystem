using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class RBookSub
    {
		public int? id { get; set; }
		public Single CID { get; set; }
		public Single SaccId { get; set; }
		public string Narat { get; set; }
		public int EType { get; set; }
		public Single Amount { get; set; }
		public Single PCID { get; set; }
		public string ChqBank { get; set; }
		public string ChqNo { get; set; }
		public DateTime ChqDate { get; set; }
		public string TC { get; set; }
		public string TCBank { get; set; }
		public Single TCQty { get; set; }
		public Single TCRate { get; set; }
		public Single RecAgainst { get; set; }
		public int ChqSr { get; set; }
		public int ChqNoS { get; set; }
		public string Remarks { get; set; }
		public string T2 { get; set; }
		public Single N2 { get; set; }
		public int CompanyID { get; set; }
		public int BranchID { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }
	}
}
