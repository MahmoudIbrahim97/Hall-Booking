using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E7GeZlY.Models
{
    public class Hall
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required]
        [DisplayName("Hall Name")]
        public string HallName { get; set; }

        [Required]
        [DisplayName("License Number")]
        public string License { get; set; }

        [Required]
        [DisplayName("County")]
        public string County { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [DisplayName("Detailed Address")]
        public string Address { get; set; }

        [DisplayName("Image")]
        public string Image { get; set; }

        [Required]
        [DisplayName("Price")]
        public int Price { get; set; }

        [Required]
        [DisplayName("Free Services")]
        public string Services { get; set; }

        [DisplayName("Additional Service")]
        public string AdditionalService { get; set; }

        [DisplayName(" ")]
        public string Service2 { get; set; }

        [DisplayName(" ")]
        public string Service3 { get; set; }

        [DisplayName(" ")]
        public string Service4 { get; set; }

        [DisplayName(" ")]
        public string Service5 { get; set; }

        [DisplayName(" ")]
        public string Service6 { get; set; }

        [DisplayName(" ")]
        public string Service7 { get; set; }

        [DisplayName(" ")]
        public string Service8 { get; set; }

        [DisplayName(" ")]
        public string Service9 { get; set; }




        [DisplayName("Hall Category")]
        public int CategoryId { get; set; }
        public virtual Category MyCategory { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}