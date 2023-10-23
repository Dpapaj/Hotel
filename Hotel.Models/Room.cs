namespace Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int RoomPrice { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public bool WIFI { get; set; }
        public bool AC { get; set; }
        public bool Bathroom { get; set; }
        public int HospitalId { get; set; }
        public HotelInfo Hotel { get; set; }
        public CustomerReport CustomerReport { get; set; }

    }
}