using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DailyCharge { get; set; }
        public decimal WeeklyCharge { get; set; }
    }
}
