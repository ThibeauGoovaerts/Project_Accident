namespace WebApplication4.Models
{
    public class OutsideFirm
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}
