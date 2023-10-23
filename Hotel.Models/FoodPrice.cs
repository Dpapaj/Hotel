using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class FoodPrice
    {
        public int Id { get; set; }
        public string Food { get; set; }
        public decimal Price { get; set; }
        public Kitchen Kitchen { get; set; }
        public Bill Bill { get; set; }
    }
}
