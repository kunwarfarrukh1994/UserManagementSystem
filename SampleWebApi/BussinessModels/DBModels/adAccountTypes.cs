﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.DBModels
{
    public class adAccountTypes
    {
        public int AccTypeID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int compID { get; set; }
        public int Del { get; set; }
        public int Sync { get; set; }
    }
}
