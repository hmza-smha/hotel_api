using System.Collections.Generic;

namespace hotel_api.DTOs
{
    public class GetHotelDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Status { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public List<GetRoomDTO> Rooms { get; set; }
    }
}
