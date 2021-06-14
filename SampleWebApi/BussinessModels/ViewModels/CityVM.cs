using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class CityVM
    {
        public int CityId { get; set; }
        public DateTime EDate { get; set; }
        public string CityName { get; set; }
        public string CityNameU { get; set; }
        public string CityCode { get; set; }
        public int CompanyID { get; set; }

    }
}
