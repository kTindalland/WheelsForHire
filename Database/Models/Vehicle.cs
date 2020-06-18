using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Vehicle : Entity
    {
        public int VehicleTypeId { get; set; }
        public string Registration { get; set; }
    }
}
