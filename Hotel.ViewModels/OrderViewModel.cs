using Hotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Order Number field is required.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "The Order Type field is required.")]
        public string Type { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "The Start Date field is required.")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "The End Date field is required.")]
        public DateTime EndDate { get; set; }

        [StringLength(255, ErrorMessage = "The Description field cannot exceed 255 characters.")]
        public string Description { get; set; }

        public OrderViewModel()
        {
                 
        }
        public OrderViewModel(Order model)
        {
            Id = model.Id;
            Number = model.Number;
            Type = model.Type;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            Description = model.Description;
        }
        public Order ConvertViewModel(OrderViewModel model)
        {
            return new Order
            {
                Id = model.Id,
                Number=model.Number,
                Type = model.Type,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Description = model.Description
            };
        }
    }
}
