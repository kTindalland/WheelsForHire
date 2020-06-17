using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class DamageDeposit
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool Paid { get; set; }
        public bool Refunded { get; set; }
    }
}
