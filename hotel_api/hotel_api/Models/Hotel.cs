using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotel_api.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }

        public string Status { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
