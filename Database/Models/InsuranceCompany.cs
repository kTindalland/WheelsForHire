using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class InsuranceCompany : Entity
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, ContactNumber:{ContactNumber}";
        }
    }
}
