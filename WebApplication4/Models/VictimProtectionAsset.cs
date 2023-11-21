namespace WebApplication4.Models
{
    public class VictimProtectionAsset
    {
        public int VictimInformationID { get; set; }
        public int ProtectionID { get; set; }
        public VictimInformation? VictimInformation { get; set; }
        public Protection? Protection { get; set; }
    }
}
