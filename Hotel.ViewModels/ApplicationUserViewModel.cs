using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class ApplicationUserViewModel
    {
        public List<ApplicationUser> Manager { get; set; }=new List<ApplicationUser>();
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }
        public DateTime DOB { get; set; }
        public string Role { get; set; }
        public bool IsManager { get; set; }

        public ApplicationUserViewModel()
        {
            
        }
        public ApplicationUserViewModel(ApplicationUser applicationUser)
        {
            Name = applicationUser.Name;
            Gender = applicationUser.Gender;
            Country = applicationUser.Country;
            Adress = applicationUser.Adress;
            Role = applicationUser.Role;
            IsManager = applicationUser.IsManager;
            DOB=applicationUser.DOB;
            UserName = applicationUser.UserName;
            Email = applicationUser.Email;
        }
        public ApplicationUser ConvertViewModel(ApplicationUserViewModel model)
        {
            return new ApplicationUser
            {
                Name = model.Name,
                Gender = model.Gender,
                Country = model.Country,
                Adress = model.Adress,
                Role = model.Role,
                IsManager = model.IsManager,
                DOB=model.DOB,
                UserName = model.UserName,
                Email = model.Email
            };
        }
    }
}
