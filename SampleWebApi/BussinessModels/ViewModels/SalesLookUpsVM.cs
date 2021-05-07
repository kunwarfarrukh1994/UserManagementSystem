﻿using System;
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

        public SalesLookUpsVM() 
        {
            salepartylookup = new List<SalePartyLookUp>();
            saleitemlookup = new List<SaleItemLookupVM>();
            saleaddalookup = new List<SaleAddaLookUpVM>();
            salepandilookup = new List<SalePandiLookUpVM>();

        }
    }
}