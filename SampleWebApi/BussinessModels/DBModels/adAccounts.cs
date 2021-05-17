using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class adAccounts
    {
		public int AccID { get; set; }
		public int CateAccID { get; set; }
		public int CtrlAccID { get; set; }
		public int MainGroupID { get; set; }
		public int GroupAccID { get; set; }
		public int compID { get; set; }
		public string Code { get; set; }
		public string AccFlexCode { get; set; }
		public string Title { get; set; }
		public int AccTypeID { get; set; }
		public int AccTransTypeID { get; set; }
		public bool isDeptAcc { get; set; }
		public bool isLocationAcc { get; set; }
		public bool isAutoOpenBal { get; set; }
		public bool isFreeze { get; set; }
		public bool isActive { get; set; }
		public int accCodeID { get; set; }
		public int accCodeDr { get; set; }
		public int accCodeCr { get; set; }
		public int cityID { get; set; }
		public int areaID { get; set; }
		public string accAddress { get; set; }
		public string telephone { get; set; }
		public string stNumber { get; set; }
		public string ntNumber { get; set; }
		public bool isNtnActive { get; set; }
		public Single accOpenBal { get; set; }
		public int opBalType { get; set; }
		public Single accCreditLimit { get; set; }
		public string accURL { get; set; }
		public int BranchID { get; set; }
		public int Del { get; set; }
		public int Sync { get; set; }
	}
}
