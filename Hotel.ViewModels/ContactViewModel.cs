using Hotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The Name field cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Phone field is required.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Please enter a valid phone (9)number.")]
        public string Phone { get; set; }





        public ContactViewModel() 
        { 

        }
        public ContactViewModel(Contact model)
        {
            Id = model.Id;
            Name = model.Name;
            Email = model.Email;
            Phone = model.Phone;
        }
        public Contact ConvertViewModel(ContactViewModel model)
        {
            return new Contact
            {
                Id = model.Id,
                Name = model.Name,
                Email=model.Email,
                Phone=model.Phone,
            };
        }   

    }
}
