using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Accident
    {
        public int ID { get; set; }
        [Required]
        public DateTime AccidentDateTime { get; set; }
        [Required]
        public string Reaction { get; set; }
        public string? LocationDetail { get; set; }
        public int Probability { get; set; }
        public int Gravity { get; set; }
        public bool isOpenToTestimony { get; set; } = true;
        public int LocationID { get; set; }
        public Location? Location { get; set; }
        public VictimInformation? VictimInformation { get; set; }
        public ICollection<DeviationDetail>? DeviationDetails { get; set; }
        public ICollection<MaterialAgentDetail>? MaterialAgentDetails { get; set; }
        public ICollection<DirectMesure>? DirectMesures { get; set; }
        public ICollection<ProposedMesureDetail>? ProposedMesureDetails { get; set; }
        public ICollection<FundamentaryCause>? FundamentaryCauses { get; set; }
        public ICollection<Report>? Reports { get; set; }
    }
}
