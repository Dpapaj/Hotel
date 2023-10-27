using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
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
