﻿using System;
using System.ComponentModel.DataAnnotations;
namespace NDC.Model
{
    public class Department
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
