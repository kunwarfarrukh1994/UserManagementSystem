using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class Ledger
    {
		public string SAccName { get; set; }
		public string SAccNameU { get; set; }
		public string LG_Narat { get; set; }
		public string LG_NaratU { get; set; }
		public DateTime LG_Date { get; set; }
		public string Folio { get; set; }
		public Single LGID { get; set; }
		public Single Dr { get; set; }
		public Single Cr { get; set; }
		public Int32 Acc_code { get; set; }
		public int branchid { get; set; }
		public Single packetqty { get; set; }
		public Single Rate { get; set; }
		public string LG_Type { get; set; }
		public Single DisRs { get; set; }
		public Single DisPer { get; set; }
		public string chqno { get; set; }
		public Single SID { get; set; }
		public Int16 OperatorID { get; set; }

	}
}
