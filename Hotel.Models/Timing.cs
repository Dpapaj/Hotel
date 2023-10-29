using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Timing
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime MornigShiftStartTime { get; set; }
        public DateTime MornigShiftEndtTime { get; set; }
        public DateTime AfternoonShiftStartTime { get; set; }
        public DateTime AfternoonShiftEndTime { get; set; }
        public Status Status { get; set; }
    }
}

namespace Hotel.Models
{
    public enum Status
    {
        Available,Pending,Confirm
    }
}