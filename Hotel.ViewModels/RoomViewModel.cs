using Hotel.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "RoomNumber is required.")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "RoomPrice is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "RoomPrice must be greater than 0.")]
        public int RoomPrice { get; set; }

        [Required(ErrorMessage = "The Type field is required.")]
        public string Type { get; set; }

        public StatusR StatusR { get; set; }

        [StringLength(255, ErrorMessage = "The Description field cannot exceed 255 characters.")]
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public bool WIFI { get; set; }
        public bool AC { get; set; }
        public bool Bathroom { get; set; }
        public int HotelInfoId { get; set; }
        public HotelInfo HotelInfo { get; set; }

        [Display(Name = "Room Picture")]
        [Required(ErrorMessage = "Please upload a room picture.")]
        public IFormFile RoomPictureFile { get; set; }

        public RoomViewModel()
        {

        }

        public RoomViewModel(Room model) 
        { 
            Id=model.Id;
            RoomNumber=model.RoomNumber;
            RoomPrice=model.RoomPrice;
            Type=model.Type;
            StatusR=model.StatusR;  
            Description=model.Description;
            PictureURL=model.PictureURL;
            WIFI = model.WIFI;
            AC = model.AC;     
            Bathroom = model.Bathroom;
            HotelInfoId = model.HotelId;
            HotelInfo = model.Hotel;
        }

        public Room ConvertViewModel(RoomViewModel model)
        {
            return new Room
            {
                Id = model.Id,
                RoomNumber = model.RoomNumber,
                RoomPrice = model.RoomPrice,
                Type = model.Type,
                StatusR = model.StatusR,
                Description = model.Description,
                PictureURL = model.PictureURL,
                WIFI = model.WIFI,
                AC = model.AC,
                Bathroom = model.Bathroom,
                HotelId= model.HotelInfoId,
                Hotel = model.HotelInfo,
        };
        }
    }
}
