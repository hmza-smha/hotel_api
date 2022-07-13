using System.ComponentModel.DataAnnotations;

namespace hotel_api.DTOs
{
    public class CreateRoomDTO
    {
        [Required]
        public int HotelID { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        public decimal? Price { get; set; }

        public string Status { get; set; }

        public decimal? Rate { get; set; }

        public int Phone { get; set; }
    }
}
