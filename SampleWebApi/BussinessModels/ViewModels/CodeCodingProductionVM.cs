using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class CodeCodingProductionVM
    {
        public Single Gatta { get; set; }
        public Single TitleMaterial { get; set; }
        public Single Astar { get; set; }
        public Single InnerMaterial { get; set; }
        public Single Pages { get; set; }
        public Single Printing { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }

        public CodeCodingProductionVM()
        {

        }

    }
}
