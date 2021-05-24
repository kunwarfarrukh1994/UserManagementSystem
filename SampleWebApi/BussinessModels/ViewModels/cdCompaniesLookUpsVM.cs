using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessModels.ViewModels
{
    public class cdCompaniesLookUpsVM
    {
        public IList<cdCompaniesBNVM> cdcompaniesBN { get; set; }
        public IList<cdCompaniesAllCompaniesLookUpVM> cdcompaniesallcompanieslookup { get; set; }

        public cdCompaniesLookUpsVM()
        {
            cdcompaniesBN = new List<cdCompaniesBNVM>();
            cdcompaniesallcompanieslookup = new List<cdCompaniesAllCompaniesLookUpVM>();
        }
    }
}
