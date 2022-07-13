using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotel_api.DTOs
{
    public class GetAmenityDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<GetRoomDTO> Rooms { get; set; }
    }
}
