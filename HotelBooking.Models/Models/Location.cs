using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingAPI.HotelBooking.Models.Models
{
    public class Location 
    {
        public ICollection<Hotel> Hotels { get; set; }
    }
}
