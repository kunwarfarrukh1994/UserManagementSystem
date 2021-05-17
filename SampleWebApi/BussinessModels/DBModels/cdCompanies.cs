using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class cdCompanies
    {
		public int companyID { get; set; }
		public string companyCode { get; set; }
		public string companyTitle { get; set; }
		public int businessNatureID { get; set; }
		public string corporateLogin { get; set; }
		public string corporatePWD { get; set; }
		public string companyLogo { get; set; }
		public string companySTN { get; set; }
		public string companyNTN { get; set; }
		public string companyAddress { get; set; }
		public string companyPhone { get; set; }
		public bool isActive { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }
	}
}
