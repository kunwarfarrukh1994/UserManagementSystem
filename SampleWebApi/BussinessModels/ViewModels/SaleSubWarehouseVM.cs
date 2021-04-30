using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SaleSubWarehouseVM
    {
		public int GodownID { get; set; }
		[Column(Order = 4)]
		public int ItemID { get; set; }
		public Single Packet { get; set; }
		public Single PktQty { get; set; }
		public Single Qty { get; set; }
		public int CompanyID { get; set; }
		public int BranchID { get; set; }
		
	}
}
