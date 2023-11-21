using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class MaterialAgentDetail
    {
        public int ID { get; set; }
        public int MaterialAgentID { get; set; }
        [Required]
        public string Label { get; set; }
        public int Code { get; set; }
        public ICollection<Accident>? Accidents { get; set; }
        public MaterialAgent? MaterialAgent { get; set; }
    }
}
