﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class CodeCodingProductType
    {
        public int? ID { get; set; }
        public int TypeID { get; set; }
        public string Title { get; set; }
        public string TitleU { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
