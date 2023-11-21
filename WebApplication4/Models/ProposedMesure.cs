using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class ProposedMesure
    {
        public int ID { get; set; }
        [Required]
        public string Label { get; set; }
        public ICollection<ProposedMesureDetail>? ProposedMesureDetails { get; set; }
    }
}
