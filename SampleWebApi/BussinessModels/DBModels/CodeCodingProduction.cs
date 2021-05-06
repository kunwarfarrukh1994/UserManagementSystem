using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class CodeCodingProduction
    {
        public int? ID { get; set; }
        public Single CID { get; set; }
        public Single CPID { get; set; }
        public Single Gatta { get; set; }
        public Single TitleMaterial { get; set; }
        public Single Astar { get; set; }
        public Single InnerMaterial { get; set; }
        public Single Pages { get; set; }
        public Single Printing { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
