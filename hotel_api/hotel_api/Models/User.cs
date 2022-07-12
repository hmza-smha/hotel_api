using System.ComponentModel.DataAnnotations;

namespace hotel_api.Models
{
    public class User
    {
        //public int Id { get; set; }

        [Required]
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }
    }
}
