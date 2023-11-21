using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class LesionSeatDetail
    {
        public int ID { get; set; }
        public int LesionSeatID { get; set; }
        [Required]
        public string Label { get; set; }
        public int Code { get; set; }
        public ICollection<VictimInformation>? VictimInformation { get; set; }
        public LesionSeat? LesionSeat { get; set; }
    }
}
