namespace Hotel.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public HotelInfo HotelInfo { get; set; }
        public string Email { get; set; } 
        public string Phone { get; set; }
    }
}