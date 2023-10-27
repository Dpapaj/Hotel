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
        public ApplicationUser? ManagerId { get; set; }
        public DateTime Date { get; set; }
        public int MornigShiftStartTime { get; set; }
        public int MornigShiftEndtTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int Duration { get; set; }
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