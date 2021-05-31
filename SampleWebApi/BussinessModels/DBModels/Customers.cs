﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class Customers
    {
        public int? ID { get; set; }
        public int CID { get; set; }
        public DateTime EDate { get; set; }
        public string CustomerName { get; set; }
        public string? ContactPerson { get; set; }
        public string? CName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        
        public int MainGroupID { get; set; }
        public string WhatsappNo { get; set; }
        public int? CityID { get; set; }
        public string CustType { get; set; }
        public string MailAddress { get; set; }
        public int AgentID1 { get; set; }
        public int? AgentID2 { get; set; }
        public Single CreditLimit { get; set; }
        public Single OpBal { get; set; }
        public int? SAccID { get; set; }
        public int? LocationID { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }



    }
}
