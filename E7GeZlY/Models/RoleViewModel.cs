using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E7GeZlY.Models
{
    public class RoleViewModel
    {
        [Required]
        [DisplayName("Role Number")]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}