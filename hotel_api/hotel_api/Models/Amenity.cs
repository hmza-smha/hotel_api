using System.ComponentModel.DataAnnotations;

namespace hotel_api.Models
{
    public class Amenity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
