using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class CodeCodingLookUpsVM
    {
        public IList<CodeCodingCategoryLookUpVM> categorylookup { get; set; }
        public IList<CodeCodingOptionsLookUpVM> optionslookup { get; set; }
        public IList<CodeCodingTypeLookUpVM> typelookup { get; set; }
        public IList<CodeCodingClassLookUpVM> classlookup { get; set; }
        public IList<CodeCodingGodownLookUpVM> godownlookup { get; set; }
        public CodeCodingLookUpsVM()
        {
            categorylookup = new List<CodeCodingCategoryLookUpVM>();
            optionslookup = new List<CodeCodingOptionsLookUpVM>();
            typelookup = new List<CodeCodingTypeLookUpVM>();
            classlookup = new List<CodeCodingClassLookUpVM>();
            godownlookup = new List<CodeCodingGodownLookUpVM>();
        }
    }
}
