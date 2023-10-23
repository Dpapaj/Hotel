using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class StockReport
    {
        public int Id { get; set; }
        public Supplier Supplier { get; set; }
        public Stock Stock { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Country { get; set; }
    }
}
