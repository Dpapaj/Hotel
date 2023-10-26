using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Manager)).GetAwaiter().GetResult();
                /*
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName= "Admin@gmail.com",
                    Email="Admin@gmail.com"
                },"Admin#147").GetAwaiter().GetResult();

                var AppAdmin=_context.ApplicationUsers.FirstOrDefault(x=>x.Email== "Admin@gmail.com");

                if (AppAdmin != null)
                {
                    _userManager.AddToRoleAsync(AppAdmin, WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();
                }*/
            }
        }
    }
}
