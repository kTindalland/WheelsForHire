using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class DamageDeposit : Entity
    {
        public decimal Price { get; set; }
        public bool Paid { get; set; }
        public bool Refunded { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, Price:{Price:C2}, Paid:{Paid}, Refunded:{Refunded}";
        }
    }
}
