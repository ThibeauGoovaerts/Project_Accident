using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class MaterialAgent
    {
        public int ID { get; set; }
        [Required]
        public string Label { get; set; }
        public ICollection<MaterialAgentDetail>? MaterialAgentDetails { get; set; }
    }
}
