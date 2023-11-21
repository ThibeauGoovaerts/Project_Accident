using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class VictimInformation
    {
        public int ID { get; set; }
        public bool WorkStopped { get; set; } = false;
        public DateTime? DateTimeWorkStopped { get; set; }
        public int AccidentID { get; set; }
        public bool WorkResumed { get; set; } = false;
        public DateTime? DateTimeWorkResumed { get; set; }
        public bool UsualFunction { get; set; } = true;
        public string? ActivityDuringAccident { get; set; }
        public int? PersonID { get; set; }
        public Person? Person { get; set; }
        public ICollection<LesionSeatDetail>? LesionSeatDetails { get; set; }
        public ICollection<NatureLesionDetail>? NatureLesionDetails { get; set; }
        public ICollection<VictimProtectionAsset>? VictimProtectionAssets { get; set; }
        public Accident? Accident { get; set; }
        
    }
}
