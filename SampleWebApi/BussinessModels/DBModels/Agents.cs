using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class Agents
    {
        public int? ID { get; set; }
        public int CID { get; set; }
        public string AgentName { get; set; }
        public int Category { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ReferBy { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
