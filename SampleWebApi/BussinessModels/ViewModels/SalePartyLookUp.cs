using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SalePartyLookUp
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Single CreditLimit { get; set; }
        public Single Receiveable { get; set; }
        public string WhatsAppNo { get; set; }
        public int AgentID { get; set; }
        SalePartyLookUp()
        { 
        }

    }
}
