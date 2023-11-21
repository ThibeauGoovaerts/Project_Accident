using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class DirectMesure
    {
        public int ID { get; set; }
        [Required]
        public string Label { get; set; }
        [DefaultValue(value:false)]
        public bool IsDefault { get; set; }
        public ICollection<Accident>? Accidents { get; set; }
    }
}
