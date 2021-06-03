using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class mClassLookUpsVM
    {
        public IList<mClassClassTypeLookUpVM> mclassclasstypelookup { get; set; }

        public mClassLookUpsVM()
        {
            mclassclasstypelookup = new List<mClassClassTypeLookUpVM>();
        }
    }
}
