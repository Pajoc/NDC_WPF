using System;
using System.ComponentModel.DataAnnotations;

namespace Gest.Model
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(5)]
        public string Code { get; set; }

        public decimal Treshold { get; set; }
        [StringLength(50)]
        [EmailAddress]
        public string MainEmail { get; set; }

        public bool? IsActive { get; set; }

        public Guid? DepartmentId { get; set; }

        public Department DepartmentOfEmployee { get; set; }
    }
}
