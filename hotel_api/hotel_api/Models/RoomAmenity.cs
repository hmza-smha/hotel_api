using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_api.Models
{
    public class RoomAmenity
    {
        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        public int AmenityId { get; set; }

        public string Status { get; set; }

        [ForeignKey("HotelId,RoomNumber")]
        public Room Room { get; set; }


        [ForeignKey("AmenityId")]
        public Amenity Amenity { get; set; }
    }
}
