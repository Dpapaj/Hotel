using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Adress { get; set; }
        public DateTime DOB { get; set; }
        public string Role { get; set; }
        public Department Department { get; set; }
        [NotMapped]
        public ICollection<Order> Orders { get; set; }
        [NotMapped]
        public ICollection<Payroll> Payrolls { get; set; }

    }
}

namespace Hotel.Models
{
    public enum Gender
    {
        Male,Female,Other
    }
}