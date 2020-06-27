using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class VehicleType : Entity
    {
        public string Name { get; set; }
        public decimal DailyCharge { get; set; }
        public decimal WeeklyCharge { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, DailyCharge:{DailyCharge:C2}, WeeklyCharge:{WeeklyCharge:C2}";
        }
    }
}
