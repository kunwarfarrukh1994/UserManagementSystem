using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SalesMainVM
    {
		public int SMID { get; set; }
		public string BillNo { get; set; }
		public int SAccID { get; set; }
		public Single GSale { get; set; }
		public Single SReturn { get; set; }
		public Single DiscountUser { get; set; }
		public Single CashRece { get; set; }
		public Single ChangeReturn { get; set; }
		public int AgentID { get; set; }
		public string Goods { get; set; }
		public string ContactNo { get; set; }
		public string CashAddress { get; set; }
		public string Pandi { get; set; }
		public string Remarks { get; set; }
		public Single Packet { get; set; }
		public Single PKTQty { get; set; }
		public int CompanyID { get; set; }
		public int OperatorID { get; set; }
		public int BranchID { get; set; }
		public int LocationID { get; set; }


		public List<SaleSubVm> SaleDetail { get; set; }


		public SalesMainVM()
		{
			SaleDetail = new List<SaleSubVm>();
		}
	}
}
