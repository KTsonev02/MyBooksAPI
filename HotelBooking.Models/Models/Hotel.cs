using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingAPI.HotelBooking.Models.Models
{
    public class Hotel
    {
        public decimal PricePerDay { get; set; }

        public string Address { get; set; }

        public int LocationId { get; set; }

        public virtual User User { get; set; }
    }
}
