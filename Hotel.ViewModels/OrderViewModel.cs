using Hotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
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
