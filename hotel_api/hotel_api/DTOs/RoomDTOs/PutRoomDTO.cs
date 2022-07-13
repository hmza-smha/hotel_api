using System.Collections.Generic;

namespace hotel_api.DTOs
{
    public class PutRoomDTO
    {
        public int RoomNumber { get; set; }

        public decimal? Rate { get; set; }

        public int Phone { get; set; }

        public string Status { get; set; }

        public decimal? Price { get; set; }
    }
}
