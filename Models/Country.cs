using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Jquery.Models
{
    public  class Country
    {
        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
    }
}
