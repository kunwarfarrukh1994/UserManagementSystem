using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class City
    {
        public int? ID { get; set; }
        public int CityId { get; set; }
        public DateTime EDate { get; set; }
        public string CityName { get; set; }
        public string CityNameU { get; set; }
        public string CityCode { get; set; }
        public int CompanyID { get; set; }
        public int Del { get; set; }
        public int sync { get; set; }



    }
}
