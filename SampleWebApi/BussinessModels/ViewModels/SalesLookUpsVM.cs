using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class SalesLookUpsVM
    {
        public IList<SalePartyLookUp> salepartylookup { get; set; }
        public IList<SaleItemLookupVM> saleitemlookup { get; set; }
        public IList<SaleAddaLookUpVM> saleaddalookup { get; set; }
        public IList<SalePandiLookUpVM> salepandilookup { get; set; }
        public IList<SaleInoiceInvoiceLookUpVM> saleinoiceInvoiceLookUp { get; set; }
        public IList<CustomerMAgentLookUp> customerMagentlookup { get; set; }
        public IList<CustomerRAgentLookUp> customerRagentlookup { get; set; }
        

        public SalesLookUpsVM()     
        {
            salepartylookup = new List<SalePartyLookUp>();
            saleitemlookup = new List<SaleItemLookupVM>();
            saleaddalookup = new List<SaleAddaLookUpVM>();
            salepandilookup = new List<SalePandiLookUpVM>();
            saleinoiceInvoiceLookUp = new List<SaleInoiceInvoiceLookUpVM>();
            customerMagentlookup = new List<CustomerMAgentLookUp>();
            customerRagentlookup = new List<CustomerRAgentLookUp>();

        }
    }
}
