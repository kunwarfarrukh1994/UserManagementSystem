using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class LoginVM
    {
        public string corporateLogin { get; set; }
        public string corporatePWD { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID {get; set;}
        public LoginVM()
        {

        }
    }
}
