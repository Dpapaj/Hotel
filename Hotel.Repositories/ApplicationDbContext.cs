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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelInfo> HotelInfos { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<CustomerReport> CustomerReports { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FoodPrice> FoodPrices { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockOrder> StockOrders { get; set; }
        public DbSet<StockReport> StockReports { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

    }
}
