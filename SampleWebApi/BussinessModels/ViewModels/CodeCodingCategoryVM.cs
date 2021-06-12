using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class CodeCodingCategoryVM
    {
        public int? ID { get; set; }
        public int CateID { get; set; }
        public string Title { get; set; }
        public string TitleU { get; set; }
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int OperatorID { get; set; }
     
        public CodeCodingCategoryVM()
        {

        }
    }
}
