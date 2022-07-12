using System.Collections.Generic;

namespace hotel_api.DTOs
{
    public class GetRoomDTO
    {
        public int RoomNumber { get; set; }

        public string HotelName { get; set; }

        public string Customer { get; set; }

        public decimal? Rate { get; set; }

        public int Phone { get; set; }

        public string Status { get; set; }

        public decimal? Price { get; set; }

        public List<GetAmenityDTO> Amenities { get; set; }
    }
}
