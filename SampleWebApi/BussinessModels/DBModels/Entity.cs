﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BussinessModels
{
    public abstract class Entity
    {
        [Key]
        //[Required]
        [Display(Name = "Id")]
        public Guid? Id { get; set; }

        [DefaultValue(false)]
        [Display(Name = "IsDeleted")]
        public bool? IsDeleted { get; set; }

        [MaxLength(100, ErrorMessage = "Created by value must be 100 characters or less.")]
        [Display(Name = "CreatedBy")]
        public string? CreatedBy { get; set; }

        [Display(Name = "CreatedOn")]
        public DateTime? CreatedOn { get; set; }

        [MaxLength(100, ErrorMessage = "Deleted by value must be 100 characters or less.")]
        [Display(Name = "DeletedBy")]
        public string? DeletedBy { get; set; }

        [Display(Name = "DeleteOn")]
        public DateTime? DeleteOn { get; set; }

        [Timestamp]
        [Display(Name = "Timestamp")]
        public byte[] Timestamp { get; set; }

        [Display(Name = "UpdatedOn")]
        public DateTime? UpdatedOn { get; set; }

        [StringLength(100, ErrorMessage = "Deleted by value must be 100 characters or less.")]
        [Display(Name = "UpdatedBy")]
        public string? UpdatedBy { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
            Timestamp = new byte[1];
            CreatedBy = "";
            DeletedBy = "";
            IsDeleted = false;
        }

        
    }
}
