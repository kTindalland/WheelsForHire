using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Booking : Entity
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public decimal AmountPaid { get; set; }
        public int DamageDepositId { get; set; }

        public override string ToString()
        {
            return $"BookingId:{Id}, CustomerId:{CustomerId}, VehicleId:{VehicleId}, StartDate:{StartDate.ToString()}, EndDate:{EndDate.ToString()}, Price:{Price:C2}, AmountPaid:{AmountPaid:C2}, DamageDepositId:{DamageDepositId}";
        }
    }
}
