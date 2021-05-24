using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class adAccountTransactionTypes
    {
        public int AccTransTypeID { get; set; }
        public DateTime EDate { get; set; }
        public string Title { get; set; }
        public int compID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }

    }
}
