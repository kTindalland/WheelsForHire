using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
