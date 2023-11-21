using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class ProposedMesureDetail
    {
        public int ID { get; set; }
        public int ProposedMesureID { get; set; }
        [Required]
        public string Label { get; set; }
        public int Code { get; set; }
        public ICollection<Accident>? Accidents { get; set; }
        public ProposedMesure? ProposedMesure { get; set; }
    }
}
