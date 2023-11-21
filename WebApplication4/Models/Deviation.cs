using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Deviation
    {
        public int ID { get; set; }
        [Required]
        public string Label { get; set; }
        public ICollection<DeviationDetail>? DeviationDetails { get; set; }
    }
}
