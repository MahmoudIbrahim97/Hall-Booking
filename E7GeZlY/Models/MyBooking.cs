using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E7GeZlY.Models
{
    public class MyBooking
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Booking Date")]
        public DateTime BookingDate { get; set; }

        [Required]
        [DisplayName("Start Time")]
        public string StartTime { get; set; }

        [Required]
        [DisplayName("End Time")]
        public string EndTime { get; set; }

        [DisplayName("Additional Services")]
        public string Services { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }



        public string UserId { get; set; }

        public int HallId { get; set; }

        
        public virtual ApplicationUser MyUser { get; set; }        
        public virtual Hall MyHall { get; set; }
        

    }
}