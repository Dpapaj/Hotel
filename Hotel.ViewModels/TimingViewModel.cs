using Hotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hotel.ViewModels
{
    public class TimingViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime MornigShiftStartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime MornigShiftEndtTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime AfternoonShiftStartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime AfternoonShiftEndTime { get; set; }
        public Status Status { get; set; }

        public TimingViewModel()
        {
            
        }
        public TimingViewModel(Timing model)
        {
            Id= model.Id;
            Date= model.Date;
            MornigShiftStartTime = model.MornigShiftStartTime;
            MornigShiftEndtTime= model.MornigShiftEndtTime;
            AfternoonShiftStartTime= model.AfternoonShiftStartTime;
            AfternoonShiftEndTime= model.AfternoonShiftEndTime;
            Status = model.Status;
            
        }
        public Timing ConvertViewModel(TimingViewModel model)
        {
            return new Timing
            {
                Id = model.Id,
                Date = model.Date,
                MornigShiftStartTime=model.MornigShiftStartTime,
                MornigShiftEndtTime=model.MornigShiftEndtTime,
                AfternoonShiftStartTime=model.AfternoonShiftStartTime,
                AfternoonShiftEndTime=model.AfternoonShiftEndTime,
                Status=model.Status, 
            };
        }

    }
}
