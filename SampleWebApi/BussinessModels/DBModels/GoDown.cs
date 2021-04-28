using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class GoDown
    {
        public int id { get; set; }
        public int GoCid { get; set; }
        public string GoName { get; set; }
        public string GoType { get; set; }
        public int FinId { get; set; }
    }
}
