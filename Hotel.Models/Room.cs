using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int RoomPrice { get; set; }
        public string Type { get; set; }
        public StatusR StatusR { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public bool WIFI { get; set; }
        public bool AC { get; set; }
        public bool Bathroom { get; set; }
        public int HotelId { get; set; }
        public HotelInfo? Hotel { get; set; }
        [NotMapped]
        public ICollection<Order> Orders { get; set; }

    }
}

namespace Hotel.Models
{
    public enum StatusR
    {
        Available, Maintenance, Booked
    }
}