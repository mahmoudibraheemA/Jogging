using System.ComponentModel.DataAnnotations;

namespace MagicVilla.Models
{
    public class Jogging
    {
        public Guid ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Distance { get; set; }
    }
}
