using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class CustomerMainNumberLookUpVM
    {
        public int CID { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNo { get; set; }
        public string WhatsappNo { get; set; }

        public CustomerMainNumberLookUpVM()
        {

        }
    }
}
