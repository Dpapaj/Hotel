using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Kitchen
    {
        public int Id { get; set; }
        public int NoW { get; set; }
        public string KitchenNumber { get; set; }
        public string Food { get; set; }
        public string Alergies { get; set; }
        public int Calories { get; set; }
        public int Orders { get; set; }
        public string FoodResult { get; set; }

    }
}
