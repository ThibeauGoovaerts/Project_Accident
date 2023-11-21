namespace WebApplication4.Models
{
    public class Report
    {
        public int ID { get; set; }
        public DateTime DateTimeCreation { get; set; } = DateTime.Now;
        public bool WasPresent { get; set; } = true;
        public string Description { get; set; }
        public int AccidentID { get; set; }
        public int PersonID { get; set; }
        public bool isOpen { get; set; } = true;
        public Person? Person { get; set; }
        public Accident? Accident { get; set; }
    }
}
