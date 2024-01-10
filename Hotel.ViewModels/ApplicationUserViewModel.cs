using Hotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class ApplicationUserViewModel
    {
        public List<ApplicationUser> Manager { get; set; }=new List<ApplicationUser>();

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The Name field cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The UserName field is required.")]
        public string UserName { get; set; }
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "The Country field is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "The Address field is required.")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "The DOB field is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "The Role field is required.")]
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
