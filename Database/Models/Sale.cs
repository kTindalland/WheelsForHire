using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfSale { get; set; }
    }
}
