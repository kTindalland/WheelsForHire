using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Sale : Entity
    {
        public int EquipmentId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfSale { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, EquipmentId:{EquipmentId}, CustomerId:{CustomerId}, Quantity:{Quantity}, DateOfSale:{DateOfSale}";
        }
    }
}
