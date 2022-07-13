using System.ComponentModel.DataAnnotations;

namespace hotel_api.DTOs
{
    public class CreateAmenityDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
