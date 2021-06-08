using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class CodeCodingMain
    {
		public int? ID { get; set; }
		public Single CID { get; set; }
		public DateTime EDate { get; set; }
		public string CodeName { get; set; }
		public int ClassID { get; set; }
		public int PCateID { get; set; }
		public int PTypeID { get; set; }
		public string Barcode { get; set; }
		public string? Code { get; set; }               //   ????????
		public Single? SaleRate { get; set; }
		public int? OptionsID { get; set; }
		public Single? CommRate { get; set; }
		public Single? CostRate { get; set; }
		public Single? BoxQty { get; set; }
		public Single? MinRate { get; set; }
		public Single? BoraQty { get; set; }
		public Single? AdminMinRate { get; set; }
		public Single? BundleQty { get; set; }
		public string? ItemDescription { get; set; }
		public int CompanyID { get; set; }
		public int BranchID { get; set; }
		public int OperatorID { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }



	}
}
