using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BussinessModels
{
    public abstract class NamedEntity : Entity
    {
        public NamedEntity() : base()
        {
        }

        [MaxLength(100, ErrorMessage = "Name must be 100 characters or less.")]
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        [RegularExpression("^[A-Za-z0-9_. ]{3,100}$")] // Alphanumeric with Underscore and Dot only
        [Display(Name = "Name")]
        public string? Name { get; set; }
    }
}
