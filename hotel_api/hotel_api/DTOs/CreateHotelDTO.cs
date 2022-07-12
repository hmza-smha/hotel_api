using System.ComponentModel.DataAnnotations;

namespace hotel_api.DTOs
{
    public class CreateHotelDTO
    {
        [Required]
        public string Name { get; set; }

        public string City { get; set; }

        public string Status { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }
    }
}
