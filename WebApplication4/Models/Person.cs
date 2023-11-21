using Microsoft.AspNetCore.Identity;

namespace WebApplication4.Models
{
    public class Person
    {
        public int ID { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string? employementType { get; set; }
        public int? Role { get; set; }
        [PersonalData]
        public string? WorkingHours { get; set; }
        public int? OutsideFirmID { get; set; }
        public int? UserID { get; set; }
        public ICollection<VictimInformation>? VictimInformations { get; set; }
        public ICollection<Report>? Reports { get; set; }
        public OutsideFirm? OutsideFirm { get; set; }
        public User? user { get; set; }
    }
}
