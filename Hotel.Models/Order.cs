namespace Hotel.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public ApplicationUser Manager { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}