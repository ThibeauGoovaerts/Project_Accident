using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class DeviationDetail
    {
        public int ID { get; set; }
        public int DeviationID { get; set; }
        [Required]
        public string Label { get; set; }
        public int Code { get; set; }
        public ICollection<Accident>? Accidents { get; set; }
        public Deviation? Deviation { get; set; }
    }
}
