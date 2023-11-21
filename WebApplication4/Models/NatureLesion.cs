using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class NatureLesion
    {
        public int ID { get; set; }
        [Required]
        public string Label { get; set; }
        public ICollection<NatureLesionDetail>? NatureLesionDetail { get; set; }
    }
}
