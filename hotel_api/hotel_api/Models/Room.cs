using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_api.Models
{
    public class Room
    {
        // key 1
        public int HotelId { get; set; }

        // key 2
        public int RoomNumber { get; set; }

        [ForeignKey("Custumer")]
        public string CustomerId { get; set; }

        public decimal? Rate { get; set; }

        public int Phone { get; set; }

        public string Status { get; set; }

        public decimal? Price { get; set; }

        public Hotel Hotel { get; set; }

        public ApplicationUser Custumer { get; set; }

        public List<Amenity> Amenities { get; set; }
    }
}
