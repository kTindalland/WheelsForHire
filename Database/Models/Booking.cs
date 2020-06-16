using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public decimal AmountPaid { get; set; }
        public int DamageDepositId { get; set; }
    }
}
