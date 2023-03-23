using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Models
{
    public class UsersDTO
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public string Pasword { get; set; }
        
    }
}
