using Hotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class HotelInfoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Type field is required.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "The City field is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The PinCode field is required.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Please enter a valid 5-digit Pin Code.")]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "The Country field is required.")]
        public string Country { get; set; }

        public HotelInfoViewModel()
        {
            
        }
        
        public HotelInfoViewModel(HotelInfo model)
        {
            Id = model.Id;
            Name = model.Name; 
            Type = model.Type;
            City = model.City;
            PinCode = model.PinCode;
            Country = model.Country;
        }
        public HotelInfo ConvertViewModel(HotelInfoViewModel model)
        {
            return new HotelInfo{
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                PinCode = model.PinCode,
                Country = model.Country,
            };
        }
    }
}
