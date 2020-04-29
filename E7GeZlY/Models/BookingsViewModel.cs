using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E7GeZlY.Models
{
    public class BookingsViewModel
    {
        public string HallName { get; set; }
        public IEnumerable<MyBooking> Items { get; set; }
    }
}