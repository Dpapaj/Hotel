using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class CustomerReport
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        public ICollection<Room> Room { get; set; }
        public ApplicationUser Manager { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
