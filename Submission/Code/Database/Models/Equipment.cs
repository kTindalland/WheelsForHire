﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Equipment : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, Name : {Name}, Price : {Price:C2}, Stock left : {Stock}";
        }
    }
}
