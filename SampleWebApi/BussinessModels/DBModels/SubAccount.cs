using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class SubAccount
    {
		public int? ID { get; set; }
		public int SAccID { get; set; }
		public string SAccName { get; set; }
		public int FinID { get; set; }
		public DateTime SAccDate { get; set; }
		public int AccCodeID { get; set; }
		public int AccCodeDr { get; set; }
		public int AccCodeCr { get; set; }
		public int CityID { get; set; }
		public string Address { get; set; }
		public string Tel { get; set; }
		public string Fax { get; set; }
		public string email { get; set; }
		public string url { get; set; }
		public string RegID { get; set; }
		public Single OpBal { get; set; }
		public string Baltype { get; set; }
		public short Active { get; set; }
		public int BranchID { get; set; }
		
		public string SAccNameU { get; set; }
		public string Area { get; set; }
		public string VendorCode { get; set; }
		public int AgentID { get; set; }

	}
}
