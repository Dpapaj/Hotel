using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class HotelInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
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
