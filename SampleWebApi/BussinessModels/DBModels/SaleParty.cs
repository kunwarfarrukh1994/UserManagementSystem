using System;
using System.Collections.Generic;
using System.Text;


namespace BussinessModels.DBModels
{
    public class SaleParty
    {
		public int? ID { get; set; }
		public Single CID { get; set; }
		public DateTime EDate { get; set; }
		public string PartyName { get; set; }
		public string City { get; set; }
		public string Address { get; set; }
		public string PhoneNo { get; set; }
		public string MobileNo { get; set; }
		public string Fax { get; set; }
		public string Rank { get; set; }
		public int BranchID { get; set; }
		public int BCID { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }
		public string PartyConcate { get; set; }
		public string NTN { get; set; }
		public string STN { get; set; }
		public string Area { get; set; }
		public string EMail { get; set; }
		public string SaleMan { get; set; }
		public Single CreditLimit { get; set; }
		public string ContactName { get; set; }
		public Single ControlACCID { get; set; }
		public Single OPBal { get; set; }
		public string BalType { get; set; }
		public int OperatorID { get; set; }
		public short N1 { get; set; }
		public short N2 { get; set; }
		public short N3 { get; set; }
		public short N4 { get; set; }
		public int PartyType { get; set; }


		
	}
}
