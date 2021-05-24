using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class adAccountsVM
    {
		public int AccID { get; set; }            //0
		public DateTime EDate { get; set; }
		public int CateAccID { get; set; }        //CateID wrt CtrlAccID
		public int CtrlAccID { get; set; }        // Dropdown
		public int MainGroupID { get; set; }      // 0
		public int GroupAccID { get; set; }		  //0
		public int compID { get; set; }			// 0
		public string Code { get; set; }          //""
		public string AccFlexCode { get; set; }   //""
		public string Title { get; set; }		//D.SAccName
		public string TitleU { get; set; }		//D.SAccNameU
		public int AccTypeID { get; set; }		//D.AccTypeID
		public int AccTransTypeID { get; set; } //D.AccTransTypeID
		public bool isDeptAcc { get; set; }		//Fasle
		public bool isLocationAcc { get; set; }  // False
		public bool isAutoOpenBal { get; set; } // true
		public bool isFreeze { get; set; }		//False
		public bool isActive { get; set; }		//true
		public int accCodeDr { get; set; }		//dropdown cntrlAccID
		public int accCodeCr { get; set; }      //dropdown cntrlAccID
		public int cityID { get; set; }         //dropdown City
		public int areaID { get; set; }			//0
		public string accAddress { get; set; }	//D.Address
		public string telephone { get; set; }	//D,Telephone
		public string stNumber { get; set; }	//D.STN
		public string ntNumber { get; set; }	//D.NTN
		public bool isNtnActive { get; set; }	//D.NTNACtive
		public Single accOpenBal { get; set; }	//D.opBAl
		public int opBalType { get; set; }		//D.BallType
		public Single accCreditLimit { get; set; }	//D.Credirlimit
		public string accURL { get; set; }			//D.URL
		public int BranchID { get; set; }			//D.BranchID
		
	}
}
