using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SchoolsVM
    {
        public int CID { get; set; }
        public DateTime EDate { get; set; }
        public string SchoolName { get; set; }
        public string? ContactPerson { get; set; }
        public string? Principal { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public int MainGroupID { get; set; }
        public string WhatsappNo { get; set; }
        public string MailAddress { get; set; }
        public int? CityID { get; set; }
        public string SchlType { get; set; }
        public int SchoolBranches { get; set; }
        public int SchoolStrength { get; set; }
        public string SessionStart { get; set; }
        public int AgentID1 { get; set; }
        public int? AgentID2 { get; set; }
        public Single OpBal { get; set; }
        public Single CreditLimit { get; set; }
        public int? SAccID { get; set; }
        public int? LocationID { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }



    }
}
