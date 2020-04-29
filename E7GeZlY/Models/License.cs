using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E7GeZlY.Models
{
    public class License
    {
        public int Id { get; set; }

        [Required]
        public string LicenseNumber { get; set; }
    }
}