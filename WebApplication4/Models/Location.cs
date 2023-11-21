namespace WebApplication4.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public ICollection<Accident>? Accidents { get; set; }

    }
}
