using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BussinessModels
{
    public class Employee: NamedEntity
    {
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
