using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class BrandLedger
    {
		public int? id { get; set; }
		public string LG_Type { get; set; }
		public Single LG_Code { get; set; }
		public DateTime LG_Date { get; set; }
		public Single BrancID { get; set; }
		public Single FinID { get; set; }
		public Single BrandId { get; set; }
		public Single QtyIn { get; set; }
		public Single QtyOut { get; set; }
		public Single Cost { get; set; }
		public Single SalePrice { get; set; }
		public Single ItemDiscount { get; set; }
		public Single PartyID { get; set; }
		public Single CommRS { get; set; }
		public Single CommPer { get; set; }
		public Single SaleManID { get; set; }
		public Single ManagerID { get; set; }
		public Single StoreID { get; set; }
		public Single BCID { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }
		public string Barcode { get; set; }
		public string Narat { get; set; }
		public int CompanyID { get; set; }

	}
}
