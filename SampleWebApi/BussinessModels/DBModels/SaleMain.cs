using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class SaleMain
    {
        public int ID { get; set; }
        public int SMID { get; set; }
        public DateTime EDate { get; set; }
        public string BillNo { get; set; }
        public int SAccID  { get; set; }
        public Single GSale { get; set; }
        public Single SReturn { get; set; }
        public Single DiscountUser { get; set; }
        public Single CashRece { get; set; }
        public string ChqRece { get; set; }
        public Single ChangeReturn { get; set; }
        public Single BiltyExp { get; set; }
        public Single FreightExp { get; set; }
        public Single OtherExp { get; set; }
        public Single CommissionExp { get; set; }
        public int CreditDays { get; set; }
        public int AgentID { get; set; }
        public int AgentID2 { get; set; }
        public int BiltyNo { get; set; }
        public string Goods { get; set; }
        public string ContactNo { get; set; }
        public string CashAddress { get; set; }
        public string Pandi { get; set; }
        public string Remarks { get; set; }
        public string txt1 { get; set; }
        public string txt2 { get; set; }
        public string txt3 { get; set; }
        public int N1 { get; set; }
        public int N2 { get; set; }
        public int N3 { get; set; }
        public Single Packet { get; set; }
        public Single PKTQty { get; set; }
        public int Post { get; set; }
        public int CompanyID { get; set; }
        public int OperatorID { get; set; }
        public Int32 BranchID { get; set; }
        public Int32 LocationID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }


    }



}
