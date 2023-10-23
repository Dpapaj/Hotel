namespace Hotel.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int BillNumber { get; set; }
        public ApplicationUser Customer { get; set; }
        public Plan Plan { get; set; }
        public decimal HotelCharge { get; set; }
        public decimal KitchenCharge { get; set; }
        public decimal ManagerCharge { get; set; }
        public decimal CleeninglCharge { get; set; }
        public int NoOfDays { get; set; }
        public decimal DamagesCharge { get; set; }
        public decimal AmenitiesCharge { get; set; }
        public decimal Advance { get; set; }
        public decimal TotalBill { get; set; }



    }
}