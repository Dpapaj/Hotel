using Hotel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<HotelInfo> HotelInfos { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Timing> Timing { get; set; }
        public DbSet<Order> Orders { get; set; }
        /*
        
        
        
        
        
        */

    }
}
