using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class NatureLesionDetail
    {
        public int ID { get; set; }
        public int NatureLesionID { get; set; }
        [Required]
        public string Label { get; set; }
        public int Code { get; set; }
        public ICollection<VictimInformation>? VictimInformation { get; set; }
        public NatureLesion? NatureLesion { get; set; }
    }
}
