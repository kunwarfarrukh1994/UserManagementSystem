using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleSubVm
    {
		public int ItemID { get; set; }
		public string ItemDescription { get; set; }
		public string Unit { get; set; }
		public Single Packet { get; set; }
		public Single PktQty { get; set; }
		public Single Qty { get; set; }
		public Single Rate { get; set; }
		public Single DisRS { get; set; }
		public Single DisPer { get; set; }
		public Single NetRate { get; set; }
		public Single Amount { get; set; }
		public string STRG { get; set; }
		public int CompanyID { get; set; }
		public int BranchID { get; set; }

		public IList<SaleSubWarehouseVM> SaleDetailWarehouse { get; set; }

		public SaleSubVm()
		{
			SaleDetailWarehouse = new List<SaleSubWarehouseVM>();
		}

	}
}
