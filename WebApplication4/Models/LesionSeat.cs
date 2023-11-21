using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class LesionSeat
    {
        public int ID { get; set; }
        [Required]
        public string Label { get; set; }
        public ICollection<LesionSeatDetail>? LesionSeatDetails { get; set; }
    }
}
