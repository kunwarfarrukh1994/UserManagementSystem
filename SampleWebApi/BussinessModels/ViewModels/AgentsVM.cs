using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class AgentsVM
    {
        public int CID { get; set; }
        public DateTime EDate { get; set; }
        public string AgentName { get; set; }
        public int Category { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ReferBy { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IdCardNo { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }
    }
}
