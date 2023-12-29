namespace CarsTARge22.Models.Cars
{
    public class CarCreateViewModel
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
    }
}
